using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace AspNetCoreLoggingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly ILogger _logger1;
        private readonly ILogger _logger2;

        public DemoController(ILoggerFactory factory)
        {
            _logger1 = factory.CreateLogger("Cat1");
            _logger2 = factory.CreateLogger("Cat2");

            this._logger2.LogInformation("Demo Constructor");
        }
        [HttpGet]
        public IActionResult Get()
        {
            this._logger1.LogInformation("Demo: Get: OK");
            return Ok(new {Message = "Demo: OK"});
        }
    }
}
