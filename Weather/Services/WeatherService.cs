using SaveApp.Weather.Models;
using SaveApp.Weather.Repositories;

namespace SaveApp.Weather.Services
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
    }
}