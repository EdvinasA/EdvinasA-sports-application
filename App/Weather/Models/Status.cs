using System.Text.Json.Serialization;

namespace SaveApp.App.Weather.Models;
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Status
    {
        APPROVED,
        DECLINED
    }
}