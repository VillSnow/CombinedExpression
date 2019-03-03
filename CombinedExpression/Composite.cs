using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CombinedExpression
{
	public static partial class ExpressionOperators
	{
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="fs">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static LambdaExpression Composite(this LambdaExpression g, params LambdaExpression[] fs) {
			return CompositeImpl(g, fs);
		}

		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="fs">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static LambdaExpression Composite(this LambdaExpression g, IEnumerable<LambdaExpression> fs) {
			return CompositeImpl(g, fs);
		}

		static LambdaExpression CompositeImpl(this LambdaExpression g, IEnumerable<LambdaExpression> fs) {
			if (g == null) { throw new ArgumentNullException(nameof(g)); }
			if (fs == null) { throw new ArgumentNullException(nameof(fs)); }
			if (fs.Any(f => f == null)) { throw new ArgumentException(nameof(fs)); }

			if (!(fs is IReadOnlyList<LambdaExpression>)) {
				fs = fs.ToArray();
			}

			var ps = fs.SelectMany(e => e.Parameters).ToList();

			var dups = Helper.DuplicatedParameters(ps);
			if (dups.Any()) {
				throw new ArgumentException($"Some parameters are same name buf differ type: {dups.First().First().Name}");
			}

			var visitor = new MyVisitor(ps);
			return Expression.Lambda(
				Expression.Invoke(
					g,
					fs.Select(f =>
						Expression.Invoke(
							visitor.Visit(f),
							f.Parameters.Select(visitor.Selector)
						)
					)
				),
				ps.Select(visitor.Selector).MyDistinct()
			);

			
		}



		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="f">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static LambdaExpression Then(this LambdaExpression f, LambdaExpression g) {
			return Composite(g, f);
		}




		static KeyValuePair<TKey, TValue> CreateKeyValuePair<TKey, TValue>(TKey key, TValue value) {
			return new KeyValuePair<TKey, TValue>(key, value);
		}



	}
}
