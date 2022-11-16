using System.Text.Json.Serialization;

namespace SaveApp.App.Workout.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ExerciseBodyPart
    {
        ABS,
        BACK,
        BICEPS,
        CARDIO, 
        CHEST,
        LEGS,
        SHOULDERS,
        TRICEPS
    }
}