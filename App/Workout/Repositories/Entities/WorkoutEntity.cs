namespace SaveApp.App.Workout.Repositories.Entities
{
    public class WorkoutEntity
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public int? BodyWeight { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public String? Notes { get; set; }
        public List<WorkoutExerciseEntity>? Exercises { get; set; }
        public UserEntity? UserEntity { get; set; }
    }
}
