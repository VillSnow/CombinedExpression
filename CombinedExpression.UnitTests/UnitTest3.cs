using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CombinedExpression.UnitTests
{
	[TestClass]
	public class UnitTest3
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		public void TestMethod1() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 10)) {
				int a = random.Next(-100, 100);
				int b = random.Next(-100, 199);

				TestContext.WriteLine($"a={a}");
				TestContext.WriteLine($"b={b}");
				Expression<Func<int, bool>> expr1 = x => x % 2 == 0;
				Expression<Func<int, bool>> expr2 = y => y % 3 == 0;

				var expr3 = (Expression<Func<int, int, bool>>)expr1.AndAlso(expr2);

				Assert.AreEqual(a % 2 == 0 && b % 3 == 0, expr3.Compile().Invoke(a, b));
			}

		}

		[TestMethod]
		public void TestMethod2() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 10)) {
				int a = random.Next(-100, 100);
				int b = random.Next(-100, 199);

				TestContext.WriteLine($"a={a}");
				TestContext.WriteLine($"b={b}");
				Expression<Func<int, bool>> expr1 = x => x % 2 == 0;
				Expression<Func<int, bool>> expr2 = y => y % 3 == 0;

				var expr3 = (Expression<Func<int, int, bool>>)expr1.OrElse(expr2);

				Assert.AreEqual(a % 2 == 0 || b % 3 == 0, expr3.Compile().Invoke(a, b));
			}

		}

		[TestMethod]
		public void TestMethod3() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 10)) {
				int a = random.Next(-1, 2);

				TestContext.WriteLine($"a={a}");
				Expression<Func<int, bool>> expr1 = x => x % 2 == 0;
				Expression<Func<int, bool>> expr2 = x => x % 3 == 0;

				var expr3 = (Expression<Func<int, bool>>)expr1.AndAlso(expr2);

				Assert.AreEqual(a % 2 == 0 && a % 3 == 0, expr3.Compile().Invoke(a));
			}

		}

		[TestMethod]
		public void TestMethod4() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 10)) {
				int a = random.Next(-1, 2);

				TestContext.WriteLine($"a={a}");
				Expression<Func<int, bool>> expr1 = x => x % 2 == 0;
				Expression<Func<int, bool>> expr2 = x => x % 3 == 0;

				var expr3 = (Expression<Func<int, bool>>)expr1.OrElse(expr2);

				Assert.AreEqual(a % 2 == 0 || a % 3 == 0, expr3.Compile().Invoke(a));
			}

		}
	}
}
