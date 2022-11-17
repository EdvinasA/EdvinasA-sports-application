namespace SaveApp.App.Workout.Repositories.Entities
{
    public class WorkoutExerciseEntity
    {
        public int Id { get; set; }
        public ExerciseEntity? Exercise { get; set; }
        public List<ExerciseSetEntity>? ExerciseSets { get; set; }
        public int RowNumber { get; set; }
        public UserEntity? User { get; set; }
    }
}