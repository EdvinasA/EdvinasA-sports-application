namespace SaveApp.Weather.Services
{
    public interface IWeatherService
    {
        public List<WeatherForecast> GetAllForecasts();
    }
}