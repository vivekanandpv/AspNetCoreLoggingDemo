using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreLoggingDemo.Services
{
    public class SampleService
    {
        private readonly ILogger _logger;

        public SampleService(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger("Cat1");
            _logger.LogInformation("Service created");
        }

        public string GetMessage()
        {
            _logger.LogInformation("Service GetMessage()");
            return "Good afternoon";
        }
    }
}
