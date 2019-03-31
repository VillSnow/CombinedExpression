using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CombinedExpression;
using System.Linq;

namespace CombinedExpression.UnitTests
{
	[TestClass]
	public class UnitTest1
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		[Obsolete]
		public void Case01() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 10)) {
				int a = random.Next(-100, 100);
				TestContext.WriteLine($"a={a}");

				Expression<Func<int, int>> expr1 = x => x - 1;
				Expression<Func<int, int>> expr2 = x => x / 2;

				var expr3 = ExpressionOperators.Then<int, int>(expr1, expr2);
				var expr4 = ExpressionOperators.Then<int, int>(expr2, expr1);

				Assert.AreEqual((a - 1) / 2, expr3.Compile().Invoke(a));
				Assert.AreEqual(a / 2 - 1, expr4.Compile().Invoke(a));
			}
		}

		[TestMethod]
		[Obsolete]
		public void Case02() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 10)) {
				int a = random.Next(-100, 100);
				int b = random.Next(-100, 100);
				TestContext.WriteLine($"a={a}, b={b}");

				Expression<Func<int, int, int>> expr1 = (x, y) => x - y;
				Expression<Func<int, int>> expr2 = x => x / 2;

				var expr3 = ExpressionOperators.Then<int, int, int>(expr1, expr2);

				Assert.AreEqual((a - b) / 2, expr3.Compile().Invoke(a, b));
			}
		}

		[TestMethod]
		[Obsolete]
		public void Case03() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 10)) {
				int a = random.Next(-100, 100);
				int b = random.Next(-100, 100);
				TestContext.WriteLine($"a={a}, b={b}");

				Expression<Func<int, int, int>> expr1 = (x, y) => x + 3 * y;
				Expression<Func<int, int, int>> expr2 = (x, y) => 2 * x + y;

				var expr3 = (Expression<Func<int, int, int>>)expr1.Composite(expr2, expr2);

				Assert.AreEqual(4 * (2 * a + b), expr3.Compile().Invoke(a, b));
			}
		}

		[TestMethod]
		[Obsolete]
		public void Case04() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 10)) {
				int a = random.Next(-100, 100);
				int b = random.Next(-100, 100);
				TestContext.WriteLine($"a={a}, b={b}");

				Expression<Func<long, long, long>> expr1 = (x, y) => x + 3 * y;
				Expression<Func<int, int, long>> expr2 = (x, y) => 2 * x + y;

				var expr3 = expr1.Composite<int, int, long>(expr2, expr2);

				Assert.AreEqual(4 * (2 * a + b), expr3.Compile().Invoke(a, b));
			}
		}

		[TestMethod]
		[Obsolete]
		[ExpectedException(typeof(ArgumentException))]
		public void Case05() {
			try {
				Expression<Func<int, long, long>> expr1 = (x, y) => x + y;
				Expression<Func<int, int, int>> expr2 = (x, y) => x + y;
				Expression<Func<long, long, long>> expr3 = (x, y) => x + y;
				expr1.Composite(expr2, expr3);
			} catch (Exception ex) {
				TestContext.WriteLine(ex.Message);
				throw;
			}
		}

		[TestMethod]
		[Obsolete]
		public void Case06() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 10)) {
				int a = random.Next(-100, 100);
				int b = random.Next(-100, 100);
				int c = random.Next(-100, 100);
				TestContext.WriteLine($"a={a}, b={b}, c={c}");

				Expression<Func<int, int, int>> expr1 = (x, y) => x + 3 * y;
				Expression<Func<int, int, int>> expr2 = (x, y) => 2 * x + y;
				Expression<Func<int, int, int>> expr3 = (x, z) => 2 * x - z;

				var expr4 = expr1.Composite<int, int, int, int>(expr2, expr3);

				Assert.AreEqual((2 * a + b) + 3 * (2 * a - c), expr4.Compile().Invoke(a, b, c));
			}
		}

		[TestMethod]
		[Obsolete]
		public void Case07() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 10)) {
				int a = random.Next(-100, 100);
				int b = random.Next(-100, 100);
				int c = random.Next(-100, 100);
				TestContext.WriteLine($"a={a}, b={b}, c={c}");

				Expression<Func<int, int, int>> expr1 = (x, y) => x + 3 * y;
				Expression<Func<int, int, int>> expr2 = (x, y) => 2 * x + y;
				Expression<Func<int, int, int>> expr3 = (x, z) => 2 * x - z;

				var expr4 = expr1.Composite<int, int, int, int>(expr3, expr2);

				Assert.AreEqual((2 * a - c) + 3 * (2 * a + b), expr4.Compile().Invoke(a, c, b));
			}
		}

		[TestMethod]
		public void Case08() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 100)) {
				int a = random.Next(-100, 100);
				int b = random.Next(-100, 100);
				TestContext.WriteLine($"a={a}, b={b}");

				Expression<Func<int, bool>> expr1 = x => x % 2 == 0;
				Expression<Func<int, bool>> expr2 = y => y % 3 == 0;

				var expr4 = (Expression<Func<int, int, bool>>)ExpressionOperators.AndAlso(expr1, expr2);

				Assert.AreEqual(a % 2 == 0 && b % 3 == 0, expr4.Compile().Invoke(a, b));
			}
		}

		[TestMethod]
		public void Case09() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 100)) {
				int a = random.Next(-100, 100);
				int b = random.Next(-100, 100);
				int c = random.Next(-100, 100);
				TestContext.WriteLine($"a={a}, b={b}, c={c}");

				Expression<Func<int, bool>> expr1 = x => x % 2 == 0;
				Expression<Func<int, bool>> expr2 = y => y % 3 == 0;
				Expression<Func<int, bool>> expr3 = z => z % 5 == 0;

				var expr4 = (Expression<Func<int, int, int, bool>>)ExpressionOperators.AndAlso(expr1, expr2, expr3);

				Assert.AreEqual(a % 2 == 0 && b % 3 == 0 && c % 5 == 0, expr4.Compile().Invoke(a, b, c));
			}
		}

		[TestMethod]
		public void Case10() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 100)) {
				int a = random.Next(-100, 100);
				int b = random.Next(-100, 100);
				TestContext.WriteLine($"a={a}, b={b}");

				var sideEffect = new SideEffetHolder();

				Expression<Func<int, bool>> expr1 = x => x % 2 == 0;
				Expression<Func<int, bool>> expr2 = y => y % (sideEffect.Update(3)) == 0;

				var expr4 = (Expression<Func<int, int, bool>>)ExpressionOperators.AndAlso(expr1, expr2);

				Assert.AreEqual(a % 2 == 0 && b % 3 == 0, expr4.Compile().Invoke(a, b));
				if (a % 2 == 0) {
					Assert.AreEqual(3, sideEffect.Value);
				} else {
					Assert.AreEqual(0, sideEffect.Value);
				}
			}
		}

		[TestMethod]
		public void Case11() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 100)) {
				int a = random.Next(-100, 100);
				int b = random.Next(-100, 100);
				TestContext.WriteLine($"a={a}, b={b}");

				Expression<Func<int, bool>> expr1 = x => x % 2 == 0;
				Expression<Func<int, bool>> expr2 = y => y % 3 == 0;

				var expr4 = (Expression<Func<int, int, bool>>)ExpressionOperators.OrElse(expr1, expr2);

				Assert.AreEqual(a % 2 == 0 || b % 3 == 0, expr4.Compile().Invoke(a, b));
			}
		}

		[TestMethod]
		public void Case12() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 100)) {
				int a = random.Next(-100, 100);
				int b = random.Next(-100, 100);
				int c = random.Next(-100, 100);
				TestContext.WriteLine($"a={a}, b={b}, c={c}");

				Expression<Func<int, bool>> expr1 = x => x % 2 == 0;
				Expression<Func<int, bool>> expr2 = y => y % 3 == 0;
				Expression<Func<int, bool>> expr3 = z => z % 5 == 0;

				var expr4 = (Expression<Func<int, int, int, bool>>)ExpressionOperators.OrElse(expr1, expr2, expr3);

				Assert.AreEqual(a % 2 == 0 || b % 3 == 0 || c % 5 == 0, expr4.Compile().Invoke(a, b, c));
			}
		}

		[TestMethod]
		public void Case13() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 100)) {
				int a = random.Next(-100, 100);
				int b = random.Next(-100, 100);
				TestContext.WriteLine($"a={a}, b={b}");

				var sideEffect = new SideEffetHolder();

				Expression<Func<int, bool>> expr1 = x => x % 2 == 0;
				Expression<Func<int, bool>> expr2 = y => y % (sideEffect.Update(3)) == 0;

				var expr4 = (Expression<Func<int, int, bool>>)ExpressionOperators.OrElse(expr1, expr2);

				Assert.AreEqual(a % 2 == 0 || b % 3 == 0, expr4.Compile().Invoke(a, b));
				if (a % 2 != 0) {
					Assert.AreEqual(3, sideEffect.Value);
				} else {
					Assert.AreEqual(0, sideEffect.Value);
				}
			}
		}

		class SideEffetHolder
		{
			public int Value { get; set; } = 0;
			public int Update(int quote) {
				Value = quote;
				return quote;
			}
		}

	}


}
