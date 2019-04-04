using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;

namespace CombinedExpression.UnitTests
{
	public class CommandExecutingLoggerProvider : ILoggerProvider
	{
		readonly Action<string> log;

		public CommandExecutingLoggerProvider(Action<string> log) {
			this.log = log;
		}

		public ILogger CreateLogger(string categoryName) {
			if(categoryName == DbLoggerCategory.Database.Command.Name) {
				return new Logger(this);
			}
			return NullLogger.Instance;
		}

		public void AddTo(DbContext dbContext) {
			dbContext.GetInfrastructure()
				.GetService<ILoggerFactory>()
				.AddProvider(this);
		}

		public void Dispose() {
			// do nothing
		}

		class Logger : ILogger
		{
			readonly CommandExecutingLoggerProvider provider;

			public Logger(CommandExecutingLoggerProvider provider) {
				this.provider = provider;
			}

			public IDisposable BeginScope<TState>(TState state) => null;
			public bool IsEnabled(LogLevel logLevel) => true;

			public void Log<TState>(
				LogLevel logLevel, EventId eventId,
				TState state, Exception exception,
				Func<TState, Exception, string> formatter
			) {
				if(
					eventId == RelationalEventId.CommandExecuting
				) {
					provider.log(formatter(state, exception));
				}
			}
		}
	}
}
