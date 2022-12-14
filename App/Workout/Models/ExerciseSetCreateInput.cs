namespace SaveApp.App.Workout.Models
{
    public class ExerciseSetCreateInput
    {
        public double? Weight { get; set; }
        public int? Reps { get; set; }
        public String? Notes { get; set; } = String.Empty;
        public int ExerciseId { get; set; }
        public int WorkoutExerciseId { get; set; }
        public int UserId { get; set; }
        public int IndexOfSet { get; set; }
    }
}