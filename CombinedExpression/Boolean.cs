using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CombinedExpression
{
	public static partial class ExpressionOperators
	{
		public static LambdaExpression AndAlso(this LambdaExpression first, params LambdaExpression[] rest) {
			return AndAlsoImpl(first, rest);
		}

		public static LambdaExpression AndAlso(this LambdaExpression first, IEnumerable<LambdaExpression> rest) {
			return AndAlsoImpl(first, rest);
		}

		public static LambdaExpression AndAlso(params LambdaExpression[] conditions) {
			return AndAlsoImpl((Expression<Func<bool>>)(() => true), conditions);
		}

		public static LambdaExpression AndAlso(IEnumerable<LambdaExpression> conditions) {
			return AndAlsoImpl((Expression<Func<bool>>)(() => true), conditions);
		}

		static LambdaExpression AndAlsoImpl(LambdaExpression first, IEnumerable<LambdaExpression> rest) {

			LambdaExpression acc = first;

			foreach (var item in rest) {
				var ps = acc.Parameters.Concat(item.Parameters).ToList();
				var dups = Helper.DuplicatedParameters(ps);
				if (dups.Any()) {
					throw new ArgumentException($"Some parameters are same name buf differ type: {dups.First().First().Name}");
				}

				var visitor = new MyVisitor(acc.Parameters.Concat(item.Parameters));
				acc = Expression.Lambda(
					Expression.AndAlso(
						visitor.Visit(acc.Body),
						visitor.Visit(item.Body)
					),
					 ps.Select(visitor.Selector).MyDistinct()
				);
			}

			return acc;
		}

		public static LambdaExpression OrElse(this LambdaExpression first, params LambdaExpression[] rest) {
			return OrElseImpl(first, rest);
		}

		public static LambdaExpression OrElse(this LambdaExpression first, IEnumerable<LambdaExpression> rest) {
			return OrElseImpl(first, rest);
		}

		public static LambdaExpression OrElse(params LambdaExpression[] conditions) {
			return OrElseImpl((Expression<Func<bool>>)(() => false), conditions);
		}

		public static LambdaExpression OrElse(IEnumerable<LambdaExpression> conditions) {
			return OrElseImpl((Expression<Func<bool>>)(() => false), conditions);
		}

		static LambdaExpression OrElseImpl(LambdaExpression first, IEnumerable<LambdaExpression> rest) {

			LambdaExpression acc = first;
			foreach (var item in rest) {
				var ps = acc.Parameters.Concat(item.Parameters).ToList();
				var dups = Helper.DuplicatedParameters(ps);
				if (dups.Any()) {
					throw new ArgumentException($"Some parameters are same name buf differ type: {dups.First().First().Name}");
				}

				var visitor = new MyVisitor(ps);
				acc = Expression.Lambda(
					Expression.OrElse(
						visitor.Visit(acc.Body),
						visitor.Visit(item.Body)
					),
					ps.Select(visitor.Selector).MyDistinct()
				);
			}

			return acc;
		}

		public static Thunk AndAlso(this Thunk lhs, Thunk rhs) {
			return Thunk.Create((bool x, bool y) => x && y).Compose(lhs, rhs);
		}

		public static Thunk AndAlso(params Thunk[] conditions) {
			return conditions.Aggregate(AndAlso);
		}

		public static Thunk AndAlso(this IEnumerable<Thunk> conditions) {
			return conditions.Aggregate(AndAlso);
		}

		public static Thunk OrElse(this Thunk lhs, Thunk rhs) {
			return Thunk.Create((bool x, bool y) => x || y).Compose(lhs, rhs);
		}

		public static Thunk OrElse(params Thunk[] conditions) {
			return conditions.Aggregate(AndAlso);
		}

		public static Thunk OrElse(this IEnumerable<Thunk> conditions) {
			return conditions.Aggregate(AndAlso);
		}
	}
}
