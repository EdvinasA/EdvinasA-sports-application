using SaveApp.App.Weather.Models;

namespace SaveApp.App.Weather.Services
{
    public interface IWeatherService
    {
        List<WeatherForecast> GetAllForecasts();
        void SaveWeather();
        void UpdateWeather(WeatherForecast weatherForecast);
        void DeleteWeather(int id);
    }
}