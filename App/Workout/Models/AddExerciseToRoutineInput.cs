namespace SaveApp.App.Workout.Models
{
    public class AddExerciseToRoutineInput
    {
        public int RoutineId { get; set; }
        public int ExerciseId { get; set; }
        public int RowNumber { get; set; }
    }
}