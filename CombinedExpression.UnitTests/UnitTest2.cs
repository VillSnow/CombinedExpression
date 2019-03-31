using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CombinedExpression.UnitTests
{
	[TestClass]
	public class UnitTest2
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		public void TestMethod1() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 10)) {
				int a = random.Next(-100, 100);
				TestContext.WriteLine($"a={a}");
				Expression<Func<int, int, int>> expr1 = (x, y) => x + y;
				var expr2 = (Expression<Func<int, int>>)expr1.ChangeParameterName("y", "x");

				Assert.AreEqual(2*a, expr2.Compile().Invoke(a));
			}
		}

		[TestMethod]
		[Obsolete]
		public void TestMethod2() {
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 10)) {
				int a = random.Next(-100, 100);
				TestContext.WriteLine($"a={a}");
				Expression<Func<int, int>> expr1 = x => x + 1;
				Expression<Func<int, int>> expr2 = y => y - 1;
				Expression<Func<int, int, int>> expr3 = (x, y) => (x + 10) * y;
				var expr4 = expr3.Composite<int, int>(expr1, expr2.ChangeParameterName("y", "x"));

				Assert.AreEqual((a + 11) * (a - 1), expr4.Compile().Invoke(a));
			}
		}
	}
}
