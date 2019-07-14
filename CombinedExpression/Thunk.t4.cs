using System;
using System.Linq.Expressions;

namespace CombinedExpression
{
	public partial class Thunk
	{
		public static Thunk<TResult> Create<TResult>(Expression<Func<TResult>> lambda) => new Thunk<TResult>(lambda);
		public static Thunk<T1, TResult> Create<T1, TResult>(Expression<Func<T1, TResult>> lambda) => new Thunk<T1, TResult>(lambda);
		public static Thunk<T1, T2, TResult> Create<T1, T2, TResult>(Expression<Func<T1, T2, TResult>> lambda) => new Thunk<T1, T2, TResult>(lambda);
		public static Thunk<T1, T2, T3, TResult> Create<T1, T2, T3, TResult>(Expression<Func<T1, T2, T3, TResult>> lambda) => new Thunk<T1, T2, T3, TResult>(lambda);
		public static Thunk<T1, T2, T3, T4, TResult> Create<T1, T2, T3, T4, TResult>(Expression<Func<T1, T2, T3, T4, TResult>> lambda) => new Thunk<T1, T2, T3, T4, TResult>(lambda);
		public static Thunk<T1, T2, T3, T4, T5, TResult> Create<T1, T2, T3, T4, T5, TResult>(Expression<Func<T1, T2, T3, T4, T5, TResult>> lambda) => new Thunk<T1, T2, T3, T4, T5, TResult>(lambda);
		public static Thunk<T1, T2, T3, T4, T5, T6, TResult> Create<T1, T2, T3, T4, T5, T6, TResult>(Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> lambda) => new Thunk<T1, T2, T3, T4, T5, T6, TResult>(lambda);
		public static Thunk<T1, T2, T3, T4, T5, T6, T7, TResult> Create<T1, T2, T3, T4, T5, T6, T7, TResult>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> lambda) => new Thunk<T1, T2, T3, T4, T5, T6, T7, TResult>(lambda);
		public static Thunk<T1, T2, T3, T4, T5, T6, T7, T8, TResult> Create<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> lambda) => new Thunk<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(lambda);

		public Func<TResult> Compile<TResult>() => ((Expression<Func<TResult>>)lambda).Compile();
		public Func<T1, TResult> Compile<T1, TResult>() => ((Expression<Func<T1, TResult>>)lambda).Compile();
		public Func<T1, T2, TResult> Compile<T1, T2, TResult>() => ((Expression<Func<T1, T2, TResult>>)lambda).Compile();
		public Func<T1, T2, T3, TResult> Compile<T1, T2, T3, TResult>() => ((Expression<Func<T1, T2, T3, TResult>>)lambda).Compile();
		public Func<T1, T2, T3, T4, TResult> Compile<T1, T2, T3, T4, TResult>() => ((Expression<Func<T1, T2, T3, T4, TResult>>)lambda).Compile();
		public Func<T1, T2, T3, T4, T5, TResult> Compile<T1, T2, T3, T4, T5, TResult>() => ((Expression<Func<T1, T2, T3, T4, T5, TResult>>)lambda).Compile();
		public Func<T1, T2, T3, T4, T5, T6, TResult> Compile<T1, T2, T3, T4, T5, T6, TResult>() => ((Expression<Func<T1, T2, T3, T4, T5, T6, TResult>>)lambda).Compile();
		public Func<T1, T2, T3, T4, T5, T6, T7, TResult> Compile<T1, T2, T3, T4, T5, T6, T7, TResult>() => ((Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>>)lambda).Compile();
		public Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> Compile<T1, T2, T3, T4, T5, T6, T7, T8, TResult>() => ((Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>)lambda).Compile();

		public Thunk<TResult> WithParams<TResult>(Expression<Func<TResult>> prototype, WithParamsFlag flags = WithParamsFlag.AssertOnly) {
			return new Thunk<TResult>((Expression<Func<TResult>>)WithParamsImpl(prototype, flags).lambda);
		}
		public Thunk<T1, TResult> WithParams<T1, TResult>(Expression<Func<T1, TResult>> prototype, WithParamsFlag flags = WithParamsFlag.AssertOnly) {
			return new Thunk<T1, TResult>((Expression<Func<T1, TResult>>)WithParamsImpl(prototype, flags).lambda);
		}
		public Thunk<T1, T2, TResult> WithParams<T1, T2, TResult>(Expression<Func<T1, T2, TResult>> prototype, WithParamsFlag flags = WithParamsFlag.AssertOnly) {
			return new Thunk<T1, T2, TResult>((Expression<Func<T1, T2, TResult>>)WithParamsImpl(prototype, flags).lambda);
		}
		public Thunk<T1, T2, T3, TResult> WithParams<T1, T2, T3, TResult>(Expression<Func<T1, T2, T3, TResult>> prototype, WithParamsFlag flags = WithParamsFlag.AssertOnly) {
			return new Thunk<T1, T2, T3, TResult>((Expression<Func<T1, T2, T3, TResult>>)WithParamsImpl(prototype, flags).lambda);
		}
		public Thunk<T1, T2, T3, T4, TResult> WithParams<T1, T2, T3, T4, TResult>(Expression<Func<T1, T2, T3, T4, TResult>> prototype, WithParamsFlag flags = WithParamsFlag.AssertOnly) {
			return new Thunk<T1, T2, T3, T4, TResult>((Expression<Func<T1, T2, T3, T4, TResult>>)WithParamsImpl(prototype, flags).lambda);
		}
		public Thunk<T1, T2, T3, T4, T5, TResult> WithParams<T1, T2, T3, T4, T5, TResult>(Expression<Func<T1, T2, T3, T4, T5, TResult>> prototype, WithParamsFlag flags = WithParamsFlag.AssertOnly) {
			return new Thunk<T1, T2, T3, T4, T5, TResult>((Expression<Func<T1, T2, T3, T4, T5, TResult>>)WithParamsImpl(prototype, flags).lambda);
		}
		public Thunk<T1, T2, T3, T4, T5, T6, TResult> WithParams<T1, T2, T3, T4, T5, T6, TResult>(Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> prototype, WithParamsFlag flags = WithParamsFlag.AssertOnly) {
			return new Thunk<T1, T2, T3, T4, T5, T6, TResult>((Expression<Func<T1, T2, T3, T4, T5, T6, TResult>>)WithParamsImpl(prototype, flags).lambda);
		}
		public Thunk<T1, T2, T3, T4, T5, T6, T7, TResult> WithParams<T1, T2, T3, T4, T5, T6, T7, TResult>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> prototype, WithParamsFlag flags = WithParamsFlag.AssertOnly) {
			return new Thunk<T1, T2, T3, T4, T5, T6, T7, TResult>((Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>>)WithParamsImpl(prototype, flags).lambda);
		}
		public Thunk<T1, T2, T3, T4, T5, T6, T7, T8, TResult> WithParams<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> prototype, WithParamsFlag flags = WithParamsFlag.AssertOnly) {
			return new Thunk<T1, T2, T3, T4, T5, T6, T7, T8, TResult>((Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>)WithParamsImpl(prototype, flags).lambda);
		}

		public Expression<Func<TResult>> ExpressionWithParams<TResult>(Expression<Func<TResult>> prototype, WithParamsFlag flags = WithParamsFlag.AssertOnly) {
			return (Expression<Func<TResult>>)WithParamsImpl(prototype, flags).lambda;
		}
		public Expression<Func<T1, TResult>> ExpressionWithParams<T1, TResult>(Expression<Func<T1, TResult>> prototype, WithParamsFlag flags = WithParamsFlag.AssertOnly) {
			return (Expression<Func<T1, TResult>>)WithParamsImpl(prototype, flags).lambda;
		}
		public Expression<Func<T1, T2, TResult>> ExpressionWithParams<T1, T2, TResult>(Expression<Func<T1, T2, TResult>> prototype, WithParamsFlag flags = WithParamsFlag.AssertOnly) {
			return (Expression<Func<T1, T2, TResult>>)WithParamsImpl(prototype, flags).lambda;
		}
		public Expression<Func<T1, T2, T3, TResult>> ExpressionWithParams<T1, T2, T3, TResult>(Expression<Func<T1, T2, T3, TResult>> prototype, WithParamsFlag flags = WithParamsFlag.AssertOnly) {
			return (Expression<Func<T1, T2, T3, TResult>>)WithParamsImpl(prototype, flags).lambda;
		}
		public Expression<Func<T1, T2, T3, T4, TResult>> ExpressionWithParams<T1, T2, T3, T4, TResult>(Expression<Func<T1, T2, T3, T4, TResult>> prototype, WithParamsFlag flags = WithParamsFlag.AssertOnly) {
			return (Expression<Func<T1, T2, T3, T4, TResult>>)WithParamsImpl(prototype, flags).lambda;
		}
		public Expression<Func<T1, T2, T3, T4, T5, TResult>> ExpressionWithParams<T1, T2, T3, T4, T5, TResult>(Expression<Func<T1, T2, T3, T4, T5, TResult>> prototype, WithParamsFlag flags = WithParamsFlag.AssertOnly) {
			return (Expression<Func<T1, T2, T3, T4, T5, TResult>>)WithParamsImpl(prototype, flags).lambda;
		}
		public Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> ExpressionWithParams<T1, T2, T3, T4, T5, T6, TResult>(Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> prototype, WithParamsFlag flags = WithParamsFlag.AssertOnly) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, TResult>>)WithParamsImpl(prototype, flags).lambda;
		}
		public Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> ExpressionWithParams<T1, T2, T3, T4, T5, T6, T7, TResult>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> prototype, WithParamsFlag flags = WithParamsFlag.AssertOnly) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>>)WithParamsImpl(prototype, flags).lambda;
		}
		public Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> ExpressionWithParams<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> prototype, WithParamsFlag flags = WithParamsFlag.AssertOnly) {
			return (Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>)WithParamsImpl(prototype, flags).lambda;
		}

	}

	public class Thunk<TResult> : Thunk
	{
		public Thunk(Expression<Func<TResult>> lambda) : base(lambda) { }
		public new Expression<Func<TResult>> Expression => (Expression<Func<TResult>>)base.Expression;
		public Func<TResult> Compile() => ((Expression<Func<TResult>>)lambda).Compile();
	}
	public class Thunk<T1, TResult> : Thunk
	{
		public Thunk(Expression<Func<T1, TResult>> lambda) : base(lambda) { }
		public new Expression<Func<T1, TResult>> Expression => (Expression<Func<T1, TResult>>)base.Expression;
		public Func<T1, TResult> Compile() => ((Expression<Func<T1, TResult>>)lambda).Compile();
	}
	public class Thunk<T1, T2, TResult> : Thunk
	{
		public Thunk(Expression<Func<T1, T2, TResult>> lambda) : base(lambda) { }
		public new Expression<Func<T1, T2, TResult>> Expression => (Expression<Func<T1, T2, TResult>>)base.Expression;
		public Func<T1, T2, TResult> Compile() => ((Expression<Func<T1, T2, TResult>>)lambda).Compile();
	}
	public class Thunk<T1, T2, T3, TResult> : Thunk
	{
		public Thunk(Expression<Func<T1, T2, T3, TResult>> lambda) : base(lambda) { }
		public new Expression<Func<T1, T2, T3, TResult>> Expression => (Expression<Func<T1, T2, T3, TResult>>)base.Expression;
		public Func<T1, T2, T3, TResult> Compile() => ((Expression<Func<T1, T2, T3, TResult>>)lambda).Compile();
	}
	public class Thunk<T1, T2, T3, T4, TResult> : Thunk
	{
		public Thunk(Expression<Func<T1, T2, T3, T4, TResult>> lambda) : base(lambda) { }
		public new Expression<Func<T1, T2, T3, T4, TResult>> Expression => (Expression<Func<T1, T2, T3, T4, TResult>>)base.Expression;
		public Func<T1, T2, T3, T4, TResult> Compile() => ((Expression<Func<T1, T2, T3, T4, TResult>>)lambda).Compile();
	}
	public class Thunk<T1, T2, T3, T4, T5, TResult> : Thunk
	{
		public Thunk(Expression<Func<T1, T2, T3, T4, T5, TResult>> lambda) : base(lambda) { }
		public new Expression<Func<T1, T2, T3, T4, T5, TResult>> Expression => (Expression<Func<T1, T2, T3, T4, T5, TResult>>)base.Expression;
		public Func<T1, T2, T3, T4, T5, TResult> Compile() => ((Expression<Func<T1, T2, T3, T4, T5, TResult>>)lambda).Compile();
	}
	public class Thunk<T1, T2, T3, T4, T5, T6, TResult> : Thunk
	{
		public Thunk(Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> lambda) : base(lambda) { }
		public new Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> Expression => (Expression<Func<T1, T2, T3, T4, T5, T6, TResult>>)base.Expression;
		public Func<T1, T2, T3, T4, T5, T6, TResult> Compile() => ((Expression<Func<T1, T2, T3, T4, T5, T6, TResult>>)lambda).Compile();
	}
	public class Thunk<T1, T2, T3, T4, T5, T6, T7, TResult> : Thunk
	{
		public Thunk(Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> lambda) : base(lambda) { }
		public new Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> Expression => (Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>>)base.Expression;
		public Func<T1, T2, T3, T4, T5, T6, T7, TResult> Compile() => ((Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>>)lambda).Compile();
	}
	public class Thunk<T1, T2, T3, T4, T5, T6, T7, T8, TResult> : Thunk
	{
		public Thunk(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> lambda) : base(lambda) { }
		public new Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> Expression => (Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>)base.Expression;
		public Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> Compile() => ((Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>>)lambda).Compile();
	}


}