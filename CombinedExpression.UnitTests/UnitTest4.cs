using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CombinedExpression;
using System.Linq;

namespace CombinedExpression.UnitTests
{
	[TestClass]
	public class UnitTest4
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		public void Case01() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 10)) {
				int a = random.Next(-100, 100);
				TestContext.WriteLine($"a={a}");

				var expr1 = Thunk.Create((int x) => x - 1);
				var expr2 = Thunk.Create((int x) => x / 2);

				var expr3 = expr1.Then(expr2).WithParams((int x) => default(int));
				var expr4 = expr2.Then(expr1).WithParams((int x) => default(int));

				TestContext.WriteLine(expr3.Expression.ToString());

				Assert.AreEqual((a - 1) / 2, expr3.Compile().Invoke(a));
				Assert.AreEqual(a / 2 - 1, expr4.Compile().Invoke(a));
			}
		}

		[TestMethod]
		public void Case02() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 10)) {
				int a = random.Next(-100, 100);
				int b = random.Next(-100, 100);
				TestContext.WriteLine($"a={a}, b={b}");

				var expr1 = Thunk.Create((int x, int y) => x - y);
				var expr2 = Thunk.Create((int x) => x / 2);

				var expr3 = expr1.Then(expr2).WithParams((int x, int y) => default(int));

				Assert.AreEqual((a - b) / 2, expr3.Compile().Invoke(a, b));
			}
		}

		[TestMethod]
		public void Case03() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 10)) {
				int a = random.Next(-100, 100);
				int b = random.Next(-100, 100);
				TestContext.WriteLine($"a={a}, b={b}");

				var expr1 = Thunk.Create((int x, int y) => x + 3 * y);
				var expr2 = Thunk.Create((int x, int y) => 2 * x + y);

				var expr3 = expr1.Compose(expr2, expr2).WithParams((int x, int y) => default(int));

				Assert.AreEqual(4 * (2 * a + b), expr3.Compile().Invoke(a, b));
			}
		}

		[TestMethod]
		public void Case04() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 10)) {
				int a = random.Next(-100, 100);
				int b = random.Next(-100, 100);
				TestContext.WriteLine($"a={a}, b={b}");

				var expr1 = Thunk.Create((long x, long y) => x + 3 * y);
				var expr2 = Thunk.Create((int x, int y) => (long)(2 * x + y));

				var expr3 = expr1.Compose(expr2, expr2).WithParams((int x, int y) => default(long));

				Assert.AreEqual(4 * (2 * a + b), expr3.Compile().Invoke(a, b));
			}
		}

		[TestMethod]
		[ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
		public void Case05() {
			try {
				var expr1 = Thunk.Create((int x, long y) => x + y);
				var expr2 = Thunk.Create((int x, int y) => x + y);
				var expr3 = Thunk.Create((long x, long y) => x + y);
				expr1.Compose(expr2, expr3);
			} catch (Exception ex) {
				TestContext.WriteLine(ex.Message);
				throw;
			}
		}

		[TestMethod]
		public void Case06() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 10)) {
				int a = random.Next(-100, 100);
				int b = random.Next(-100, 100);
				int c = random.Next(-100, 100);
				TestContext.WriteLine($"a={a}, b={b}, c={c}");

				var expr1 = Thunk.Create((int x, int y) => x + 3 * y);
				var expr2 = Thunk.Create((int x, int y) => 2 * x + y);
				var expr3 = Thunk.Create((int x, int z) => 2 * x - z);

				var expr4 = expr1.Compose(expr2, expr3).WithParams((int x, int y, int z) => default(int));
				
				Assert.AreEqual((2 * a + b) + 3 * (2 * a - c), expr4.Compile().Invoke(a, b, c));
			}
		}

		[TestMethod]
		public void Case07() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 10)) {
				int a = random.Next(-100, 100);
				int b = random.Next(-100, 100);
				int c = random.Next(-100, 100);
				TestContext.WriteLine($"a={a}, b={b}, c={c}");

				var expr1 = Thunk.Create((int x, int y) => x + 3 * y);
				var expr2 = Thunk.Create((int x, int y) => 2 * x + y);
				var expr3 = Thunk.Create((int x, int z) => 2 * x - z);

				var expr4 = expr1.Compose(expr3, expr2).WithParams((int x, int z, int y) => default(int));
				TestContext.WriteLine(expr4.Expression.ToString());
				Assert.AreEqual((2 * a - c) + 3 * (2 * a + b), expr4.Compile().Invoke(a, c, b));
			}
		}

	}


}
