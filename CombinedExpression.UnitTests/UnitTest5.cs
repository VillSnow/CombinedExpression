using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CombinedExpression.UnitTests
{
	[TestClass]
	public class UnitTest5
	{
		string dbName;
		public TestContext TestContext { get; set; }

		[TestInitialize]
		public void Init() {
			dbName = $"Blog.{Guid.NewGuid()}.sqlite";
			using (var db = new BlogDbContext(dbName)) {
				db.Database.EnsureDeleted();
				db.Database.EnsureCreated();

				var auther1 = new Auther { Name = "Auther1" };
				var auther2 = new Auther { Name = "Auther2" };

				db.Articles.Add(new Article {
					Title = "Article1",
					Auther = auther1,
					Content = "qwertyuiop"
				});

				db.Articles.Add(new Article {
					Title = "Article2",
					Auther = auther1,
					Content = "asdfghjkl"
				});

				db.Articles.Add(new Article {
					Title = "Article3",
					Auther = auther2,
					Content = "zxcvbnm"
				});

				db.SaveChanges();
			}
		}

		[TestCleanup]
		public void Cleanup() {
			using (var db = new BlogDbContext(dbName)) {
				db.Database.EnsureDeleted();
			}
		}

		[TestMethod]
		public void TestOfTest_Case01() {
			using (var db = new BlogDbContext(dbName)) {

				List<string> logs = new List<string>();
				var logger = new CommandExecutingLoggerProvider(logs.Add);
				logger.AddTo(db);

				var contents = db.Articles.OrderBy(x => x.Content).Select(x => x.Title).ToList();
				CollectionAssert.AreEqual(new[] { "Article2", "Article1", "Article3" }, contents);

				var log = logs.Single(x => x.Contains("SELECT"));
				var selecters = Regex.Match(log, @"SELECT\s+(.*?)\s+FROM").Groups[1].Value;
				Assert.IsFalse(selecters.Contains("Content"));
			}
		}

		[TestMethod]
		public void TestOfTest_Case02() {
			using (var db = new BlogDbContext(dbName)) {

				List<string> logs = new List<string>();
				var logger = new CommandExecutingLoggerProvider(logs.Add);
				logger.AddTo(db);

				// EF Core cannot parse Identity therefore it must select Content
				var contents = db.Articles.OrderBy(x => Identity(x.Content)).Select(x => x.Title).ToList();
				CollectionAssert.AreEqual(new[] { "Article2", "Article1", "Article3" }, contents);

				var log = logs.Single(x => x.Contains("SELECT"));
				var selecters = Regex.Match(log, @"SELECT\s+(.*?)\s+FROM").Groups[1].Value;
				Assert.IsTrue(selecters.Contains("Content"));
			}
		}

		public T Identity<T>(T quote) => quote;


		[TestMethod]
		public void Case01() {
			using (var db = new BlogDbContext(dbName)) {
				List<string> logs = new List<string>();
				var logger = new CommandExecutingLoggerProvider(logs.Add);
				logger.AddTo(db);

				var contentSelector = Thunk.Create((Article x) => x.Content);
				var titleSelector = Thunk.Create((Article x) => x.Title);

				var contents = db.Articles.OrderBy(contentSelector.Expression).Select(titleSelector.Expression).ToList();
				CollectionAssert.AreEqual(new[] { "Article2", "Article1", "Article3" }, contents);

				foreach (var item in logs) {
					TestContext.WriteLine(item);
					TestContext.WriteLine("");
				}

				var log = logs.Single(x => x.Contains("SELECT"));
				var selecters = Regex.Match(log, @"SELECT\s+(.*?)\s+FROM").Groups[1].Value;
				Assert.IsFalse(selecters.Contains("Content"));


			}
		}

		[TestMethod]
		public void Case02() {
			using (var db = new BlogDbContext(dbName)) {
				List<string> logs = new List<string>();
				var logger = new CommandExecutingLoggerProvider(logs.Add);
				logger.AddTo(db);

				var contentSelector = Thunk.Create((Article x) => x.Content);
				var resultSelector = Thunk.Create((Article x) => "XXX "+x.Title+" XXX");

				var contents = db.Articles.OrderBy(contentSelector.Expression).Select(resultSelector.Expression).ToList();
				CollectionAssert.AreEqual(new[] { "XXX Article2 XXX", "XXX Article1 XXX", "XXX Article3 XXX" }, contents);

				foreach (var item in logs) {
					TestContext.WriteLine(item);
					TestContext.WriteLine("");
				}

				var log = logs.Single(x => x.Contains("SELECT"));
				var selecters = Regex.Match(log, @"SELECT\s+(.*?)\s+FROM").Groups[1].Value;
				Assert.IsTrue(selecters.Contains("XXX"));


			}
		}

		[TestMethod]
		public void Case03() {
			using (var db = new BlogDbContext(dbName)) {
				List<string> logs = new List<string>();
				var logger = new CommandExecutingLoggerProvider(logs.Add);
				logger.AddTo(db);

				var articlesSelector = Thunk.Create<Auther, IEnumerable<Article>>(x => x.Articles);
				var articles = db.Authers.SelectMany(articlesSelector.Expression).Select(x => x.Title).ToList();
				CollectionAssert.AreEquivalent(new[] { "Article1", "Article2", "Article3" }, articles);

				foreach (var item in logs) {
					TestContext.WriteLine(item);
					TestContext.WriteLine("");
				}

				Assert.AreEqual(1, logs.Count(s => s.Contains("SELECT")));
			}
		}

		[TestMethod]
		public void Case04() {
			using (var db = new BlogDbContext(dbName)) {
				List<string> logs = new List<string>();
				var logger = new CommandExecutingLoggerProvider(logs.Add);
				logger.AddTo(db);

				var cond1 = Thunk.Create((Article x) => x.Content.Contains("qwe"));
				var cond2 = Thunk.Create((Article x) => x.Content.Contains("asd"));
				var cond = cond1.OrElse(cond2).WithParams((Article x) => default(bool));
				var articles = db.Articles.Where(cond.Expression).Select(x => x.Title).ToList();

				foreach (var item in logs) {
					TestContext.WriteLine(item);
					TestContext.WriteLine("");
				}

				CollectionAssert.AreEquivalent(new[] { "Article1", "Article2", }, articles);
				Assert.AreEqual(1, logs.Count(s => s.Contains("SELECT")));
			}
		}

		[TestMethod]
		public void Case05() {
			using (var db = new BlogDbContext(dbName)) {
				List<string> logs = new List<string>();
				var logger = new CommandExecutingLoggerProvider(logs.Add);
				logger.AddTo(db);

				var cond1 = Thunk.Create((Article x) => x.Content.Length<10);
				var cond2 = Thunk.Create((Article x) => x.Content.Length>8);
				var cond = cond1.AndAlso(cond2).WithParams((Article x) => default(bool));
				var articles = db.Articles.Where(cond.Expression).Select(x => x.Title).ToList();

				foreach (var item in logs) {
					TestContext.WriteLine(item);
					TestContext.WriteLine("");
				}

				CollectionAssert.AreEquivalent(new[] { "Article2", }, articles);
				Assert.AreEqual(1, logs.Count(s => s.Contains("SELECT")));
			}
		}
	}
}
