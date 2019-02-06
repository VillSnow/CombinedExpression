using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CombinedExpression
{
	public partial class ExpressionOperators
	{

		public static LambdaExpression ChangeParameterName(this LambdaExpression expression, string before, string after) {
			return ChangeParameterNameImpl(expression, s => s == before ? after : s);
		}

		public static LambdaExpression ChangeParameterNameImpl(LambdaExpression expression, Func<string,string> selector) {
			var list = new List<KeyValuePair<ParameterExpression, ParameterExpression>>();
			var ps = new List<ParameterExpression>();
			foreach (var item in expression.Parameters) {
				var after = selector(item.Name);
				var exist = list.Where(pair => pair.Value.Name == after).Select(pair => pair.Value).FirstOrDefault();
				if (exist != null) {
					if (item.Type != exist.Type) {
						throw new ArgumentException("");
					}
					list.Add(new KeyValuePair<ParameterExpression, ParameterExpression>(item, exist));
				} else {
					var p = Expression.Parameter(item.Type, after);
					list.Add(new KeyValuePair<ParameterExpression, ParameterExpression>(item, p));
					ps.Add(p);
				}
			}
			var visitor = new MyVisitor();
			visitor.Selector = p => list.Where(pair => pair.Key == p).Select(pair => pair.Value).Single();
			return Expression.Lambda(visitor.Visit(expression.Body), ps);
		}

		class MyVisitor : ExpressionVisitor
		{
			public Func<ParameterExpression, ParameterExpression> Selector { get; set; } 

			public MyVisitor() {
				Selector = p => p;
			}

			public MyVisitor(IEnumerable<ParameterExpression> parameters) {
				if (!(parameters is IReadOnlyList<ParameterExpression>)) {
					parameters = parameters.ToArray();
				}
				Selector = p => parameters.FirstOrDefault(x => x.Name == p.Name) ?? p;
			}
			protected override Expression VisitParameter(ParameterExpression node) => Selector(node);
		}
	}

}
