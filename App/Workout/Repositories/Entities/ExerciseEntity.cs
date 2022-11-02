namespace SaveApp.App.Workout.Repositories.Entities
{
    public class ExerciseEntity
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public int RowNumber { get; set; }
        public List<ExerciseSetEntity>? ExerciseSetsEntities { get; set; }
        public List<WorkoutEntity>? WorkoutEntity { get; set; }
        public UserEntity? User { get; set; }
    }
}