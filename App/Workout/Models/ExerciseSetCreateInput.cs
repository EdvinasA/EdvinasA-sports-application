using SaveApp.App.Workout.Models;

namespace sports_application.App.Workout.Models
{
    public class ExerciseSetCreateInput
    {
        public int? Weigth { get; set; }
        public int? Reps { get; set; }
        public String? Notes { get; set; }
        public ExerciseType? ExerciseType { get; set; }
        public int ExerciseId { get; set; }
        public int WorkoutId { get; set; }
    }
}