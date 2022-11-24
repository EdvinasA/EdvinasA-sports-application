using System.Text.Json.Serialization;

namespace SaveApp.App.Workout.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ExerciseType
    {
        STRENGTH_WEIGHT_REPS
    }
}