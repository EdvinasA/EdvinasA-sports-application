namespace SaveApp.App.Workout.Models
{
    public class WorkoutRoutine
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Targets { get; set; } = String.Empty;
        public string? Notes { get; set; }
        public List<WorkoutRoutineExercise>? WorkoutRoutineExercises { get; set; }
    }
}