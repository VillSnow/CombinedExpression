using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using static CombinedExpression.ExpressionOperators;

namespace CombinedExpression
{
	public partial class Thunk
	{
		readonly internal LambdaExpression lambda;

		internal Thunk(LambdaExpression lambda) {
			this.lambda = lambda;
		}

		public LambdaExpression Expression => lambda;

		public Thunk Compose(IEnumerable<Thunk> fs) => ComposeImpl(fs);
		public Thunk Compose(params Thunk[] fs) => ComposeImpl(fs);

		public Thunk Then(Thunk g) => g.Compose(this);

		public Thunk<TResult> WithParams<TResult>(Expression<TResult> prototype, WithParamsFlag flags = WithParamsFlag.AssertOnly) {
			return new Thunk<TResult>((Expression<Func<TResult>>)WithParamsImpl(prototype, flags).lambda);
		}


		Thunk ComposeImpl(IEnumerable<Thunk> fs) {
			fs = (fs is IReadOnlyList<LambdaExpression>) ? fs : fs?.ToArray(); // ensure is evaluated

			if (fs == null) { throw new ArgumentNullException(nameof(fs)); }
			if (fs.Any(f => f is null)) { throw new ArgumentException(nameof(fs)); }

			var ps = fs.SelectMany(f => f.lambda.Parameters).ToList();

			ParameterExpression parameterSelector(ParameterExpression p) {
				return ps.FirstOrDefault(x => x.Name == p.Name) ?? p;
			}

			var dups = Helper.DuplicatedParameters(ps);
			if (dups.Any()) {
				throw new ArgumentException($"Some parameters are same name buf differ type: {dups.First().First().Name}");
			}

			var visitor = new MyVisitor(p => {
				var pos = lambda.Parameters.IndexOf(p);
				if (pos != -1) {
					return fs.ElementAt(pos).lambda.Body;
				} else {
					return parameterSelector(p);
				}
			});

			return new Thunk(
				System.Linq.Expressions.Expression.Lambda(
					visitor.Visit(lambda.Body),
					ps.Select(parameterSelector).MyDistinct()
				)
			);
		}

		Thunk WithParamsImpl(LambdaExpression prototype, WithParamsFlag flags) {
			if (prototype is null) { throw new ArgumentNullException(nameof(prototype)); }
			if (flags.HasFlag(WithParamsFlag.AllowChangingName) && flags.HasFlag(WithParamsFlag.AllowChangingOrder)) {
				throw new ArgumentException("Cannot change name and order in same time");
			}

			ThunkHelper.AssertPrototypes(lambda, prototype, flags);

			var prevPs = lambda.Parameters.ToList();
			var postPs = prototype.Parameters.Select(p => System.Linq.Expressions.Expression.Parameter(p.Type, p.Name)).ToList();
			MyVisitor visitor;
			if (flags.HasFlag(WithParamsFlag.AllowChangingOrder)) {
				visitor = new MyVisitor(postPs);
			} else {
				visitor = new MyVisitor {
					Selector = p => {
						int pos = prevPs.IndexOf(p);
						return (pos != -1) ? postPs[pos] : p;
					}
				};
			}
			return new Thunk((LambdaExpression)visitor.Visit(lambda));
		}

	}

	static class ThunkHelper
	{
		public static void AssertPrototypes(LambdaExpression before, LambdaExpression after, WithParamsFlag flags) {
			bool pred(ParameterExpression p1, ParameterExpression p2) {
				if (p1.Type != p2.Type) { return false; }
				if (!flags.HasFlag(WithParamsFlag.AllowChangingName)) {
					if (p1.Name != p2.Name) { return false; }
				}
				return true;
			}

			if (flags.HasFlag(WithParamsFlag.AllowChangingOrder)) {
				var seq1 =
					from p1 in before.Parameters
					select (
						from p2 in after.Parameters
						where pred(p1, p2)
						select p2
					).Count();
				var seq2 =
					from p2 in after.Parameters
					select (
						from p1 in before.Parameters
						where pred(p1, p2)
						select p1
					).Count();
				if (seq1.Any(x => x != 1) | seq2.Any(x => x != 1)) {
					throw new InvalidOperationException($"Any parameters are Mismatched");
				}
			} else {
				var seq = Enumerable.Zip(
					before.Parameters,
					after.Parameters,
					pred
				);
				if (seq.Any(x => !x)) {
					throw new InvalidOperationException($"Any parameters are Mismatched");
				}
			}

		}
	}


	[Flags]
	public enum WithParamsFlag
	{
		AssertOnly = 0x00,
		AllowChangingName = 0x01,
		AllowChangingOrder = 0x02,
	}

	class MyVisitor : ExpressionVisitor
	{
		public Func<ParameterExpression, Expression> Selector { get; set; }

		public MyVisitor() {
			Selector = p => p;
		}

		public MyVisitor(Func<ParameterExpression, Expression> selector) {
			Selector = selector;
		}

		public MyVisitor(IEnumerable<ParameterExpression> parameters) {
			if (!(parameters is IReadOnlyList<ParameterExpression>)) {
				parameters = parameters.ToArray();
			}
			Selector = p => parameters.FirstOrDefault(x => x.Name == p.Name) ?? p;
		}

		protected override Expression VisitParameter(ParameterExpression node) => Selector(node);

		protected override Expression VisitLambda<T>(Expression<T> node) {
			var convertedPs = node.Parameters.Select(Selector).ToList();
			convertedPs.OfType<ParameterExpression>();
			var minor = new MyVisitor(Selector);
			return Expression.Lambda(
				minor.Visit(node.Body),
				node.Parameters.Select(Selector).OfType<ParameterExpression>()
			);
		}
	}
}
