namespace SaveApp.App.Workout.Models
{
    public class ExerciseSetCreateInput
    {
        public int? Weight { get; set; }
        public int? Reps { get; set; }
        public String? Notes { get; set; } = String.Empty;
        public ExerciseType? ExerciseType { get; set; } = Models.ExerciseType.STRENGTH_WEIGHT_REPS;
        public int ExerciseId { get; set; }
        public int WorkoutExerciseId { get; set; }
        public int UserId { get; set; }
    }
}