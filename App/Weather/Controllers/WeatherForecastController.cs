using Microsoft.AspNetCore.Mvc;
using SaveApp.App.Weather.Services;
using SaveApp.App.Weather.Models;

namespace SaveApp.App.Weather;

[ApiController]
[Route("api/weather")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherService _weatherService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
    {
        _logger = logger;
        _weatherService = weatherService;
    }

    [HttpGet("get-all")]
    public List<WeatherForecast> Other() 
    {
        return _weatherService.GetAllForecasts();
    }

    [HttpPost("create")]
    public void Create() {
        _weatherService.SaveWeather();
    }

    [HttpPut("update")]
    public void Update(WeatherForecast weatherForecast) {
        _weatherService.UpdateWeather(weatherForecast);
    }

    [HttpDelete("{id}")]
    public void Delete(int id) {
        _weatherService.DeleteWeather(id);
    }
}
