using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ntech.ExternalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExternalApiController : ControllerBase
    {
        private readonly ILogger<ExternalApiController> _logger;

        public ExternalApiController(ILogger<ExternalApiController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IHeaderDictionary Get()
        {
            // Return all headers API received.
            Request.Headers.Add("Ntech-Header", "ExternalApi");
            return Request.Headers;
        }
    }
}
