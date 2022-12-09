namespace SaveApp.App.Workout.Repositories.Entities
{
    public class WorkoutRoutineEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Targets { get; set; } = String.Empty;
        public string? Notes { get; set; }
        public List<WorkoutRoutineExerciseEntity>? WorkoutRoutineExercises { get; set; }
        public UserEntity? User { get; set; }
    }
}