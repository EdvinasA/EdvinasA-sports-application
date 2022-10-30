using SaveApp.Weather.Models;

namespace SaveApp.Weather.Repositories
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly WeatherContext _context;

        public WeatherRepository(WeatherContext context) {
            _context = context;
        }

        public List<WeatherForecast> GetAll() {
            return _context.Weather.ToList();
        }

        public void SaveWeather() {
            WeatherForecast forecast = new WeatherForecast();
            forecast.TemperatureC = 123;

            _context.Weather.Add(forecast);
            _context.SaveChanges();
        }
    }
}