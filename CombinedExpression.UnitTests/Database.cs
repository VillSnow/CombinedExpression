using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CombinedExpression.UnitTests
{
	class BlogDbContext : DbContext
	{
		readonly string cxnStr;

		public DbSet<Auther> Authers { get; set; }
		public DbSet<Article> Articles { get; set; }

		public BlogDbContext(string name) {
			cxnStr = $"Data Source={name}";
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlite(cxnStr);
		}
	}

	class Auther
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Article> Articles { get; set; }
	}

	class Article
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public Auther Auther { get; set; }
		public int AutherId { get; set; }
		public string Content { get; set; }
	}


}
