using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CombinedExpression.UnitTests
{
	[TestClass]
	public class UnitTest6
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		public void Case01()
		{
			var random = new Random();
			foreach (var _ in Enumerable.Range(0, 10))
			{
				int a = random.Next(-100, 100);
				TestContext.WriteLine($"a={a}");

				var expr1 = Thunk.Create((int x) => x - 1);
				var expr2 = Thunk.Create((int x) => x / 2);

				var expr3 = expr1.Then(expr2);
				var expr4 = expr2.Then(expr1);

				TestContext.WriteLine(expr3.Expression.ToString());

				Assert.AreEqual((a - 1) / 2, expr3.ExpressionWithParams((int x) => default(int)).Compile().Invoke(a));
				Assert.AreEqual(a / 2 - 1, expr4.ExpressionWithParams((int x) => default(int)).Compile().Invoke(a));
			}
		}
	}
}
