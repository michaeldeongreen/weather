using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using weather.core;
using weather.core.Interfaces;
using weather.core.Models;

namespace weather.api.Controllers
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
            //_logger.LogInformation(LogEventIds.WeatherForecastControllerGetEnterInformation, "Enter", _logContext);
             _logger.LogWarningObject(LogEventIds.WeatherForecastControllerGetEnterInformation, _logContext);
            /*using (_logger.BeginScope(
                new Dictionary<string, object> { {"PersonId", _logContext.UserId } }))
            {
                _logger.LogWarning("Hello");
                _logger.LogWarning("World");
            }*/
            var rng = new Random();
            //_logger.LogInformation(LogEventIds.WeatherForecastControllerGetExitInformation, "Exit", _logContext);
            _logger.LogWarningObject(LogEventIds.WeatherForecastControllerGetExitInformation, _logContext);

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
