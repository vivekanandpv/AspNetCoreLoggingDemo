using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AspNetCoreLoggingDemo.Services;

namespace AspNetCoreLoggingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly SampleService _service;

        public SampleController(ILoggerFactory factory, SampleService service)
        {
            _logger = factory.CreateLogger("Cat1");
            _service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            this._logger.LogInformation("Sample: Get: OK");
            return Ok(new {Message = _service.GetMessage()});
        }
    }
}
