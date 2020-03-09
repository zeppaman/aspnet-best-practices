using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MultitenantSimple.Controllers
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

        private readonly IMongoDatabase client;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMongoDatabase client)
        {
            this._logger = logger;
            this.client = client;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var weather = this.client.GetCollection<WeatherForecast>("weater");
            if (weather.AsQueryable().Count() == 0)
            {
                GenerateFakeData(weather);
            }

            return weather.AsQueryable().ToEnumerable();
        }

        private void GenerateFakeData(IMongoCollection<WeatherForecast> weather)
        {
            Random r = new Random();
            for (int i = 0; i < 1000; i++)
            {
                weather.InsertOne(new WeatherForecast()
                {
                    
                    Date = DateTime.Now.AddHours(i),
                    Summary = "Test",
                    TemperatureC = 22 + r.Next(0, 10)
                }); ;
            }
        }
    }
}
