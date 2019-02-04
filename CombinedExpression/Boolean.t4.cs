using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CombinedExpression
{
	public static partial class ExpressionOperators
	{

		public static Expression<Func<T1, bool>> AndAlso<T1>(this LambdaExpression first, params LambdaExpression[] rest) {
			return (Expression<Func<T1, bool>>)AndAlso(first, rest);
		}

		public static Expression<Func<T1, bool>> AndAlso<T1>(this LambdaExpression first, IEnumerable<LambdaExpression> rest) {
			return (Expression<Func<T1, bool>>)AndAlso(first, rest);
		}

		public static Expression<Func<T1, T2, bool>> AndAlso<T1, T2>(this LambdaExpression first, params LambdaExpression[] rest) {
			return (Expression<Func<T1, T2, bool>>)AndAlso(first, rest);
		}

		public static Expression<Func<T1, T2, bool>> AndAlso<T1, T2>(this LambdaExpression first, IEnumerable<LambdaExpression> rest) {
			return (Expression<Func<T1, T2, bool>>)AndAlso(first, rest);
		}

		public static Expression<Func<T1, T2, T3, bool>> AndAlso<T1, T2, T3>(this LambdaExpression first, params LambdaExpression[] rest) {
			return (Expression<Func<T1, T2, T3, bool>>)AndAlso(first, rest);
		}

		public static Expression<Func<T1, T2, T3, bool>> AndAlso<T1, T2, T3>(this LambdaExpression first, IEnumerable<LambdaExpression> rest) {
			return (Expression<Func<T1, T2, T3, bool>>)AndAlso(first, rest);
		}

		public static Expression<Func<T1, T2, T3, T4, bool>> AndAlso<T1, T2, T3, T4>(this LambdaExpression first, params LambdaExpression[] rest) {
			return (Expression<Func<T1, T2, T3, T4, bool>>)AndAlso(first, rest);
		}

		public static Expression<Func<T1, T2, T3, T4, bool>> AndAlso<T1, T2, T3, T4>(this LambdaExpression first, IEnumerable<LambdaExpression> rest) {
			return (Expression<Func<T1, T2, T3, T4, bool>>)AndAlso(first, rest);
		}

		public static Expression<Func<T1, T2, T3, T4, T5, bool>> AndAlso<T1, T2, T3, T4, T5>(this LambdaExpression first, params LambdaExpression[] rest) {
			return (Expression<Func<T1, T2, T3, T4, T5, bool>>)AndAlso(first, rest);
		}

		public static Expression<Func<T1, T2, T3, T4, T5, bool>> AndAlso<T1, T2, T3, T4, T5>(this LambdaExpression first, IEnumerable<LambdaExpression> rest) {
			return (Expression<Func<T1, T2, T3, T4, T5, bool>>)AndAlso(first, rest);
		}

		public static Expression<Func<T1, T2, T3, T4, T5, T6, bool>> AndAlso<T1, T2, T3, T4, T5, T6>(this LambdaExpression first, params LambdaExpression[] rest) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, bool>>)AndAlso(first, rest);
		}

		public static Expression<Func<T1, T2, T3, T4, T5, T6, bool>> AndAlso<T1, T2, T3, T4, T5, T6>(this LambdaExpression first, IEnumerable<LambdaExpression> rest) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, bool>>)AndAlso(first, rest);
		}

		public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> AndAlso<T1, T2, T3, T4, T5, T6, T7>(this LambdaExpression first, params LambdaExpression[] rest) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>>)AndAlso(first, rest);
		}

		public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> AndAlso<T1, T2, T3, T4, T5, T6, T7>(this LambdaExpression first, IEnumerable<LambdaExpression> rest) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>>)AndAlso(first, rest);
		}

		public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> AndAlso<T1, T2, T3, T4, T5, T6, T7, T8>(this LambdaExpression first, params LambdaExpression[] rest) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>>)AndAlso(first, rest);
		}

		public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> AndAlso<T1, T2, T3, T4, T5, T6, T7, T8>(this LambdaExpression first, IEnumerable<LambdaExpression> rest) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>>)AndAlso(first, rest);
		}


		public static Expression<Func<T1, bool>> OrElse<T1>(this LambdaExpression first, params LambdaExpression[] rest) {
			return (Expression<Func<T1, bool>>)OrElse(first, rest);
		}

		public static Expression<Func<T1, bool>> OrElse<T1>(this LambdaExpression first, IEnumerable<LambdaExpression> rest) {
			return (Expression<Func<T1, bool>>)OrElse(first, rest);
		}

		public static Expression<Func<T1, T2, bool>> OrElse<T1, T2>(this LambdaExpression first, params LambdaExpression[] rest) {
			return (Expression<Func<T1, T2, bool>>)OrElse(first, rest);
		}

		public static Expression<Func<T1, T2, bool>> OrElse<T1, T2>(this LambdaExpression first, IEnumerable<LambdaExpression> rest) {
			return (Expression<Func<T1, T2, bool>>)OrElse(first, rest);
		}

		public static Expression<Func<T1, T2, T3, bool>> OrElse<T1, T2, T3>(this LambdaExpression first, params LambdaExpression[] rest) {
			return (Expression<Func<T1, T2, T3, bool>>)OrElse(first, rest);
		}

		public static Expression<Func<T1, T2, T3, bool>> OrElse<T1, T2, T3>(this LambdaExpression first, IEnumerable<LambdaExpression> rest) {
			return (Expression<Func<T1, T2, T3, bool>>)OrElse(first, rest);
		}

		public static Expression<Func<T1, T2, T3, T4, bool>> OrElse<T1, T2, T3, T4>(this LambdaExpression first, params LambdaExpression[] rest) {
			return (Expression<Func<T1, T2, T3, T4, bool>>)OrElse(first, rest);
		}

		public static Expression<Func<T1, T2, T3, T4, bool>> OrElse<T1, T2, T3, T4>(this LambdaExpression first, IEnumerable<LambdaExpression> rest) {
			return (Expression<Func<T1, T2, T3, T4, bool>>)OrElse(first, rest);
		}

		public static Expression<Func<T1, T2, T3, T4, T5, bool>> OrElse<T1, T2, T3, T4, T5>(this LambdaExpression first, params LambdaExpression[] rest) {
			return (Expression<Func<T1, T2, T3, T4, T5, bool>>)OrElse(first, rest);
		}

		public static Expression<Func<T1, T2, T3, T4, T5, bool>> OrElse<T1, T2, T3, T4, T5>(this LambdaExpression first, IEnumerable<LambdaExpression> rest) {
			return (Expression<Func<T1, T2, T3, T4, T5, bool>>)OrElse(first, rest);
		}

		public static Expression<Func<T1, T2, T3, T4, T5, T6, bool>> OrElse<T1, T2, T3, T4, T5, T6>(this LambdaExpression first, params LambdaExpression[] rest) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, bool>>)OrElse(first, rest);
		}

		public static Expression<Func<T1, T2, T3, T4, T5, T6, bool>> OrElse<T1, T2, T3, T4, T5, T6>(this LambdaExpression first, IEnumerable<LambdaExpression> rest) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, bool>>)OrElse(first, rest);
		}

		public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> OrElse<T1, T2, T3, T4, T5, T6, T7>(this LambdaExpression first, params LambdaExpression[] rest) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>>)OrElse(first, rest);
		}

		public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>> OrElse<T1, T2, T3, T4, T5, T6, T7>(this LambdaExpression first, IEnumerable<LambdaExpression> rest) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, T7, bool>>)OrElse(first, rest);
		}

		public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> OrElse<T1, T2, T3, T4, T5, T6, T7, T8>(this LambdaExpression first, params LambdaExpression[] rest) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>>)OrElse(first, rest);
		}

		public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>> OrElse<T1, T2, T3, T4, T5, T6, T7, T8>(this LambdaExpression first, IEnumerable<LambdaExpression> rest) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, bool>>)OrElse(first, rest);
		}


	}
}
