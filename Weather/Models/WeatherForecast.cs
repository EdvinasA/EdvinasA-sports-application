using System.Numerics;

namespace SaveApp;

public class WeatherForecast
{

    public int Id { get; set; }
    public DateTime? Date { get; set; }

    public Double? TemperatureC { get; set; }

    public Double? TemperatureF => 32.0 + (TemperatureC / 0.5556);

    public String? Summary { get; set; }
}
