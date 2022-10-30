using System.Text.Json.Serialization;

namespace SaveApp.App.Workout.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ExerciseType
    {
        NORMAL = 1,
        WARMUP = 2,
        DROPSET = 3
    }
}