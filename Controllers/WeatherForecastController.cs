using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace weatherforecast.Controllers
{
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    //[RoutePrefix("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Provinces = new[]
        {
            "NL", "PE", "NS", "NB", "QC", "ON", "MB", "SK", "AB", "BC", "YT", "NT", "NU"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("[controller]/provinces")]
        public IEnumerable<WeatherForecast> All()
        {
            var rng = new Random();
            return Provinces.Select(prov => new WeatherForecast()
            {
                Date = DateTime.Now,
                TemperatureC = rng.Next(-20, 55),
                Province = prov
            });
        }

        [HttpGet]
        [Route("[controller]/provinces/{province}")]
        public WeatherForecast Get(string province)
        {
            var rng = new Random();
            return new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = rng.Next(-20, 55),
                Province = province
            };
        }
    }
}
