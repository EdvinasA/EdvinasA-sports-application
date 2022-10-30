namespace SaveApp.Weather.Repositories
{
    public interface IWeatherRepository
    {
         public List<WeatherForecast> GetAll();
         void SaveWeather();
    }
}