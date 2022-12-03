namespace SaveApp.App.Workout.Repositories.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? Email { get; set; }
        public List<ExerciseEntity>? ExerciseEntity { get; set; }
        public List<ExerciseSetEntity>? ExerciseSetEntity { get; set; }
        public List<WorkoutEntity>? WorkoutEntity { get; set; }
    }
}
