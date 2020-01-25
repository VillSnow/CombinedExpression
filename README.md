# CombinedExpression

Simple Library to combine System.Linq.Expressions.LambdaExpression.
Useful for Entity Framework or others.

## Usage

Composite expressions of function.

	var f1 = Thunk.Create((int x) => x + 1);
	var f2 = Thunk.Create((int y) => y - 1);
	var g = Thunk.Create((int xi, int eta) => xi * eta);
	var c = g.Compose(f1, f2); // (int x, int y) => (x + 1) * (y - 1)

Same parameters are reduced into single parameter.

	var f1 = Thunk.Create((int x) => x + 1);
	var f2 = Thunk.Create((int x) => x - 1);
	var g = Thunk.Create((int x, int y) => x * y);
	var c = g.Compose(f1, f2); // (int x) => (x + 1) * (x - 1)

You can build 'or' query easily.

    using CombinedExpression;
    
    IQueryable<string> articles;
    string[] words;

    var conditions =
        from word in words
        select Thunk.Create( (string article) => article.Contains(word) );

    var componentCondition = ExpressionOperators.OrElse(conditions).WithParams( (string)=>default(bool) );
    var results = articles.Where(componentCondition).ToList();

