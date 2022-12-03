using System.Numerics;

namespace SaveApp.App.Workout.Models
{
    public class ExerciseSet
    {
        public int Id { get; set; }
        public int? Weight { get; set; }
        public int? Reps { get; set; }
        public String? Notes { get; set; }
        public ExerciseSetPreviousValues? ExerciseSetPreviousValues { get; set; }
        
    }
}