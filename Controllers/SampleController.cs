using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreLoggingDemo.Configuration;
using AspNetCoreLoggingDemo.LoggingProviders;
using Microsoft.Extensions.Logging;

namespace AspNetCoreLoggingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly CustomLogger _customLogger;

        public SampleController(CustomLogger customLogger)
        {
            _customLogger = customLogger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            this._customLogger.LogThreadInformation(Thread.CurrentThread.ManagedThreadId);
            return Ok(new {Message = "Sample: OK"});
        }
    }
}
