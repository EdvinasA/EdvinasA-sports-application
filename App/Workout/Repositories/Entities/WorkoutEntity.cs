using System.Numerics;

namespace SaveApp.App.Workout.Repositories.Entities
{
    public class WorkoutEntity
    {
        public int Id { get; set; }
        public ExerciseEntity ExerciseEntity { get; set; }
        public String? ExerciseName { get; set; }
        public int? BodyWeight { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public String? Notes { get; set; }
        public int RowNumber { get; set; }
    }
}