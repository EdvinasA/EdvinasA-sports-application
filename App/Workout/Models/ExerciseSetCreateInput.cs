namespace SaveApp.App.Workout.Models
{
    public class ExerciseSetCreateInput
    {
        public int Id { get; set; }
        public int? Weight { get; set; }
        public int? Reps { get; set; }
        public String? Notes { get; set; }
        public ExerciseType? ExerciseType { get; set; }
        public int ExerciseId { get; set; }
        public int WorkoutExerciseId { get; set; }
        public int UserId { get; set; }
    }
}