using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            this._logger.LogInformation(ApplicationLogEvents.GetAll, "Succeeded {param1} {param2}", "Sample", "Get");
            return Ok(new { Message = "Sample: OK" });
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            //  template: old api
            this._logger.LogInformation(ApplicationLogEvents.GetById, "Succeeded for id: {param1}", id);

            //  new template interpolation of C# 6
            //  https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
            this._logger.LogInformation(ApplicationLogEvents.GetById, $"Succeeded for id: {id}");

            return Ok(new { Message = "Sample: OK", Id = id });
        }
    }
}
