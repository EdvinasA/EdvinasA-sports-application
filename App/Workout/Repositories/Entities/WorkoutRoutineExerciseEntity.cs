using System.Text;

namespace SaveApp.App.Workout.Repositories.Entities
{
    public class WorkoutRoutineExerciseEntity
    {
        public int Id { get; set; }
        public ExerciseEntity? Exercise { get; set; }
        public string? Notes { get; set; } = string.Empty;
        public int NumberOfSets { get; set; }
    }
}