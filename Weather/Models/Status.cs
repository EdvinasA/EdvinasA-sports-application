using System.Text.Json.Serialization;

namespace SaveApp.Weather.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        APPROVED,
        DECLINED
    }
}