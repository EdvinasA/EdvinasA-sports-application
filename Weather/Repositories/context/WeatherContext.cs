using Microsoft.EntityFrameworkCore;

namespace SaveApp.Weather.Models;

public class WeatherContext : DbContext 
{
    public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
    {
        
    }

    public DbSet<WeatherForecast> WeatherSave { get; set; }
}