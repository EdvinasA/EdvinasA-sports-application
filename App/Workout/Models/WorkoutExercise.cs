namespace SaveApp.App.Workout.Models
{
    public class WorkoutExercise {
        public int Id { get; set; }
        public Exercise Exercise { get; set; }
        public List<ExerciseSet>? ExerciseSets { get; set; }
        public int RowNumber { get; set; }
    }
}