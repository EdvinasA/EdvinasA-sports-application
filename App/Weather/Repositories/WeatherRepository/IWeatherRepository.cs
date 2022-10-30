using SaveApp.App.Weather.Models;

namespace SaveApp.App.Weather.Repositories
{
    public interface IWeatherRepository
    {
         List<WeatherForecast> GetAll();
         void SaveWeather();
         void UpdateWeather(WeatherForecast weatherForecast);
         void DeleteWeather(int id);
    }
}