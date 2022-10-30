using SaveApp.App.Weather.Repositories;
using SaveApp.App.Weather.Models;

namespace SaveApp.App.Weather.Services
{
    public class WeatherService : IWeatherService
    {

        private readonly IWeatherRepository _queryRepository;
        
        public WeatherService(IWeatherRepository queryRepository) 
        {
            _queryRepository = queryRepository;
        }

        public List<WeatherForecast> GetAllForecasts() {
            return _queryRepository.GetAll();
        }

        public void SaveWeather() {
            _queryRepository.SaveWeather();
        }

        public void UpdateWeather(WeatherForecast weatherForecast) {
            _queryRepository.UpdateWeather(weatherForecast);
        }

        public void DeleteWeather(int id) {
            _queryRepository.DeleteWeather(id);
        }
    }
}