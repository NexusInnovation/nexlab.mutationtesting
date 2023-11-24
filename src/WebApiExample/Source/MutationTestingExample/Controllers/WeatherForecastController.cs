using Microsoft.AspNetCore.Mvc;
using MutationTestingExample.Services;

namespace MutationTestingExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogging _logging;

        public WeatherForecastController(ILogging logging) => _logging = logging;

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logging.Log("Test logging");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55)
            })
            .ToArray();
        }

        public void SendLog(string message)
        {
            _logging.Log(message);
        }
    }
}