namespace SaveApp.App.Workout.Models
{
    public class WorkoutRoutineExercise
    {
        public int Id { get; set; }
        public Exercise? Exercise { get; set; }
        public string? Notes { get; set; } = string.Empty;
        public int RowNumber { get; set; }
        public int NumberOfSets { get; set; }
    }
}