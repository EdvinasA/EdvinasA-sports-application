using SaveApp.App.Weather.Repositories.Context;
using SaveApp.App.Weather.Models;

namespace SaveApp.App.Weather.Repositories
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

        public void UpdateWeather(WeatherForecast weatherForecast) {

            try {

                var weather = _context.Weather.FirstOrDefault<WeatherForecast>(entity => entity.Id == weatherForecast.Id);

                weather!.Date = weatherForecast.Date;
                weather!.TemperatureC = weatherForecast.TemperatureC;
                weather!.Summary = weatherForecast.Summary;

                _context.SaveChanges();

            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        public void DeleteWeather(int id) {
            try {

                WeatherForecast weatherForecast = _context.Weather.First<WeatherForecast>(entity => entity.Id == id);

                _context.Weather.Remove(weatherForecast);
                _context.SaveChanges();
            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }
    }
}