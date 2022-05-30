using Microsoft.AspNetCore.Mvc;

namespace TodoApi3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase, ITextWriter 
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController()
        {
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet(Name = "GetWeatherForecastString")]
        public string GetText()
        {
            string result = "";

            for (int i = 0; i < 5; i++)
            {
                result += "Date: " + DateTime.Now.AddDays(i).ToShortDateString() + ", ";
                result += "Temperature: " + Random.Shared.Next(-20, 55) + " degrees C, summary: ";
                result += "Summary: " + Summaries[new Random().Next() % Summaries.Length] + "\n";
            }

            return result;
        }
    }
}