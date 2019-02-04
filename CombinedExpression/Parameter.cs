using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CombinedExpression
{
	public partial class ExpressionOperators
	{



		class MyVisitor : ExpressionVisitor
		{
			public Func<ParameterExpression, ParameterExpression> Selector { get; } = p => p;

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
