using Microsoft.AspNetCore.Mvc;
using SaveApp.Weather.Services;

namespace SaveApp.Controllers;

[ApiController]
[Route("weather")]
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

    [HttpGet("other")]
    public List<WeatherForecast> Other() 
    {
        return _weatherService.GetAllForecasts();
    }

    [HttpPost("create")]
    public void Create() {
        _weatherService.SaveWeather();
    }
}
