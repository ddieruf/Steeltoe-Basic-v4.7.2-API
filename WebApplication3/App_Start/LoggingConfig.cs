using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Steeltoe.Extensions.Logging;

namespace WebApplication3.App_Start {
	public static class LoggingConfig {
		public static ILoggerFactory LoggerFactory { get; set; }
		public static ILoggerProvider LoggerProvider { get; set; }
    public static void Configure(IConfiguration configuration) {
      IServiceCollection serviceCollection = new ServiceCollection();
      serviceCollection.AddLogging(builder => {
        builder
            .SetMinimumLevel(LogLevel.Trace)
            .AddConfiguration(configuration)
            .AddDynamicConsole();
      });

      LoggerFactory = serviceCollection.BuildServiceProvider().GetService<ILoggerFactory>();
    }
  }
}