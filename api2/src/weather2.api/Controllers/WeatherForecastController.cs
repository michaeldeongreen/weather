using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using weather2.core;
using weather2.core.Interfaces;
using weather2.core.Models;

namespace weather2.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IObjectLogger<WeatherForecastController> _logger;
        private readonly LogContext _logContext;

        public WeatherForecastController(IObjectLogger<WeatherForecastController> logger)
        {
            _logContext = new LogContext();
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformationObject(LogEventIds.WeatherForecast2ControllerGetEnterInformation, _logContext);

            var rng = new Random();

            _logger.LogInformationObject(LogEventIds.WeatherForecast2ControllerGetExitInformation, _logContext);
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
