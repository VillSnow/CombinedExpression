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
		public static Expression<Func<T1, TResult>> Composite<T1, TResult>(this LambdaExpression g, params LambdaExpression[] fs) {
			return (Expression<Func<T1, TResult>>)CompositeImpl(g, fs);
		}
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="fs">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, T2, TResult>> Composite<T1, T2, TResult>(this LambdaExpression g, params LambdaExpression[] fs) {
			return (Expression<Func<T1, T2, TResult>>)CompositeImpl(g, fs);
		}
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="fs">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, T2, T3, TResult>> Composite<T1, T2, T3, TResult>(this LambdaExpression g, params LambdaExpression[] fs) {
			return (Expression<Func<T1, T2, T3, TResult>>)CompositeImpl(g, fs);
		}
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="fs">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, T2, T3, T4, TResult>> Composite<T1, T2, T3, T4, TResult>(this LambdaExpression g, params LambdaExpression[] fs) {
			return (Expression<Func<T1, T2, T3, T4, TResult>>)CompositeImpl(g, fs);
		}
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="fs">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, T2, T3, T4, T5, TResult>> Composite<T1, T2, T3, T4, T5, TResult>(this LambdaExpression g, params LambdaExpression[] fs) {
			return (Expression<Func<T1, T2, T3, T4, T5, TResult>>)CompositeImpl(g, fs);
		}
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="fs">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> Composite<T1, T2, T3, T4, T5, T6, TResult>(this LambdaExpression g, params LambdaExpression[] fs) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, TResult>>)CompositeImpl(g, fs);
		}
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="fs">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> Composite<T1, T2, T3, T4, T5, T6, T7, TResult>(this LambdaExpression g, params LambdaExpression[] fs) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>>)CompositeImpl(g, fs);
		}
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="fs">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> Composite<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this LambdaExpression g, params LambdaExpression[] fs) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>)CompositeImpl(g, fs);
		}

		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="fs">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, TResult>> Composite<T1, TResult>(this LambdaExpression g, IEnumerable<LambdaExpression> fs) {
			return (Expression<Func<T1, TResult>>)CompositeImpl(g, fs);
		}
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="fs">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, T2, TResult>> Composite<T1, T2, TResult>(this LambdaExpression g, IEnumerable<LambdaExpression> fs) {
			return (Expression<Func<T1, T2, TResult>>)CompositeImpl(g, fs);
		}
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="fs">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, T2, T3, TResult>> Composite<T1, T2, T3, TResult>(this LambdaExpression g, IEnumerable<LambdaExpression> fs) {
			return (Expression<Func<T1, T2, T3, TResult>>)CompositeImpl(g, fs);
		}
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="fs">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, T2, T3, T4, TResult>> Composite<T1, T2, T3, T4, TResult>(this LambdaExpression g, IEnumerable<LambdaExpression> fs) {
			return (Expression<Func<T1, T2, T3, T4, TResult>>)CompositeImpl(g, fs);
		}
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="fs">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, T2, T3, T4, T5, TResult>> Composite<T1, T2, T3, T4, T5, TResult>(this LambdaExpression g, IEnumerable<LambdaExpression> fs) {
			return (Expression<Func<T1, T2, T3, T4, T5, TResult>>)CompositeImpl(g, fs);
		}
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="fs">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> Composite<T1, T2, T3, T4, T5, T6, TResult>(this LambdaExpression g, IEnumerable<LambdaExpression> fs) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, TResult>>)CompositeImpl(g, fs);
		}
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="fs">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> Composite<T1, T2, T3, T4, T5, T6, T7, TResult>(this LambdaExpression g, IEnumerable<LambdaExpression> fs) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>>)CompositeImpl(g, fs);
		}
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="fs">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> Composite<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this LambdaExpression g, IEnumerable<LambdaExpression> fs) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>)CompositeImpl(g, fs);
		}

		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="f">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, TResult>> Then<T1, TResult>(this LambdaExpression f, LambdaExpression g) {
			return (Expression<Func<T1, TResult>>)Then(f, g);
		}
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="f">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, T2, TResult>> Then<T1, T2, TResult>(this LambdaExpression f, LambdaExpression g) {
			return (Expression<Func<T1, T2, TResult>>)Then(f, g);
		}
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="f">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, T2, T3, TResult>> Then<T1, T2, T3, TResult>(this LambdaExpression f, LambdaExpression g) {
			return (Expression<Func<T1, T2, T3, TResult>>)Then(f, g);
		}
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="f">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, T2, T3, T4, TResult>> Then<T1, T2, T3, T4, TResult>(this LambdaExpression f, LambdaExpression g) {
			return (Expression<Func<T1, T2, T3, T4, TResult>>)Then(f, g);
		}
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="f">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, T2, T3, T4, T5, TResult>> Then<T1, T2, T3, T4, T5, TResult>(this LambdaExpression f, LambdaExpression g) {
			return (Expression<Func<T1, T2, T3, T4, T5, TResult>>)Then(f, g);
		}
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="f">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> Then<T1, T2, T3, T4, T5, T6, TResult>(this LambdaExpression f, LambdaExpression g) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, TResult>>)Then(f, g);
		}
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="f">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> Then<T1, T2, T3, T4, T5, T6, T7, TResult>(this LambdaExpression f, LambdaExpression g) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>>)Then(f, g);
		}
		/// <summary>
		/// Composite function expressions
		/// </summary>
		/// <param name="f">to be applied first</param>
		/// <param name="g">to be applied second</param>
		public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> Then<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(this LambdaExpression f, LambdaExpression g) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>)Then(f, g);
		}
	}
}