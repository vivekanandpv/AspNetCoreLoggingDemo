using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreLoggingDemo.Configuration;
using Microsoft.Extensions.Logging;

namespace AspNetCoreLoggingDemo.LoggingProviders
{
    public class CustomLogger
    {
        private readonly ILogger _logger;

        public CustomLogger(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger("Wrapper");
        }

        public void LogThreadInformation(int threadId)
        {
            this._logger.LogInformation(ApplicationLogEvents.GetAll, "Current Thread: ({thread})", threadId);
        }
    }
}
