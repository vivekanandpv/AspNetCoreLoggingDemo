using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreLoggingDemo.Configuration;
using Microsoft.Extensions.Logging;

namespace AspNetCoreLoggingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ILogger _logger;

        public SampleController(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger("Cat1");
        }
        [HttpGet]
        public IActionResult Get()
        {
            this._logger.LogWarning(ApplicationLogEvents.GetAll, "Succeeded {param1} {param2} Current Thread: ({thread})", "Sample", "Get", Thread.CurrentThread.ManagedThreadId);
            return Ok(new {Message = "Sample: OK"});
        }
    }
}
