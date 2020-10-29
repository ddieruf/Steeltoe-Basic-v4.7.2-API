using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3.App_Start;

namespace WebApplication3.Controllers {
	public class ValuesController : ApiController {
		private ILogger<ValuesController> _logger;
		public ValuesController() {
			_logger = LoggingConfig.LoggerFactory.CreateLogger<ValuesController>();
		}
		// GET api/values
		public IEnumerable<string> Get() {
			var minlvl = GetMinLogLevel(_logger);
			Console.WriteLine($"Minimum level set on _logger: {minlvl}");
			Debug.WriteLine($"Minimum level set on _logger: {minlvl}");
			_logger.LogTrace("This is a {LogLevel} log", LogLevel.Trace.ToString());
			_logger.LogDebug("This is a {LogLevel} log", LogLevel.Debug.ToString());
			_logger.LogInformation("This is a {LogLevel} log", LogLevel.Information.ToString());
			_logger.LogWarning("This is a {LogLevel} log", LogLevel.Warning.ToString());
			_logger.LogError("This is a {LogLevel} log", LogLevel.Error.ToString());
			_logger.LogCritical("This is a {LogLevel} log", LogLevel.Critical.ToString());

			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		public string Get(int id) {
			return "value";
		}

		// POST api/values
		public void Post([FromBody] string value) {
		}

		// PUT api/values/5
		public void Put(int id, [FromBody] string value) {
		}

		// DELETE api/values/5
		public void Delete(int id) {
		}
		private LogLevel GetMinLogLevel(ILogger logger) {
			for (var i = 0; i < 6; i++) {
				var level = (LogLevel)Enum.ToObject(typeof(LogLevel), i);
				if (logger.IsEnabled(level)) {
					return level;
				}
			}

			return LogLevel.None;
		}
	}
}
