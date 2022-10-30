namespace SaveApp.Weather.Services
{
    public interface IWeatherService
    {
        public List<WeatherForecast> GetAllForecasts();
        public void SaveWeather();
        void UpdateWeather(WeatherForecast weatherForecast);
        public void DeleteWeather(int id);
    }
}