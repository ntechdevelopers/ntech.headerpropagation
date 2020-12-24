using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ntech.HeaderPropagation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("header")]
        public IHeaderDictionary GetHeader()
        {
            // Return all headers API received.
            return Request.Headers;
        }

        [HttpGet("header-propagation")]
        public async Task<IActionResult> GetHeaderPropagation()
        {
            var client = _clientFactory.CreateClient("externalapi-client");
            var apiResponse = await client.GetAsync("/externalapi");
            var apiResponseContent = await apiResponse.Content.ReadAsStringAsync();

            return Content(apiResponseContent, "application/json");
        }

        [HttpPost]
        public IHeaderDictionary Post([FromBody] string value)
        {
            var context = _httpContextAccessor.HttpContext;
            var request = context.Request;
            if (!string.IsNullOrWhiteSpace(value))
            {
                context.Request.Headers.Add("Ntech-Header", value);
            }

            return context.Request.Headers;
        }
    }
}
