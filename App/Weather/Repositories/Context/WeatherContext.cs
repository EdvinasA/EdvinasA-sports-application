using Microsoft.EntityFrameworkCore;
using SaveApp.App.Weather.Models;

namespace SaveApp.App.Weather.Repositories.Context;

public class WeatherContext : DbContext 
{
    public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
    {
    }

    public DbSet<WeatherForecast> Weather { get; set; }
}