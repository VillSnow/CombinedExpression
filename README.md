# CombinedExpression

Simple Library to combine System.Linq.Expressions.LambdaExpression.
Useful for Entity Framework or others.

## Usage

Composite expressions of function.

    using CombinedExpression;
    
    Expression<Func<int, int>> f1 = x => x + 1;
    Expression<Func<int, int>> f2 = y => y - 1;
    Expression<Func<int, int, int>> g = (xi, eta) => xi * eta;
    var c = g.Composite<int, int, int>(f1, f2); // (int x, int y) => (x + 1) * (x - 1)

Same parameters are reduced into single parameter.

    Expression<Func<int, int>> f1 = x => x + 1;
    Expression<Func<int, int>> f2 = x => x - 1;
    Expression<Func<int, int, int>> g = (x, y) => x * y;
    var c = g.Composite<int, int>(f1, f2); // (int x) => (x + 1) * (x - 1)

You can build 'or' query easily.

    IQueryable<string> articles;
    string[] words;

    var conditions =
        from word in words
        select (Expression<Func<string, bool>>)( (string article) => article.Contains(word) );

    var componentCondition = (Expression<Func<string, bool>>)ExpressionOperators.OrElse(conditions);
    var results = articles.Where(componentCondition).ToList();

