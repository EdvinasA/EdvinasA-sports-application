using System.Numerics;

namespace SaveApp.App.Workout.Models
{
    public class Workout
    {
        public string Id { get; set; }
        public Exercise Exercise { get; set; }
        public String? ExerciseName { get; set; }
        public int? BodyWeight { get; set; }
        public DateOnly? Date { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public String? Notes { get; set; }
        public int RowNumber { get; set; }
    }
}