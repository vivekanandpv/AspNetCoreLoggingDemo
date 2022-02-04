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
        private readonly ILogger<SampleController> _logger;

        public SampleController(ILogger<SampleController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Get()
        {
            //   AspNetCoreLoggingDemo.Controllers.SampleController[2] -> [2] is eventId (GetAll=2), default is 0
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
