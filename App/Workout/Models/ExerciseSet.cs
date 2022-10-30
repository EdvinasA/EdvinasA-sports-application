using System.Numerics;

namespace SaveApp.App.Workout.Models
{
    public class ExerciseSet
    {
        public int Id { get; set; }
        public int? Weigth { get; set; }
        public int? Reps { get; set; }
        public String? Notes { get; set; }
        public ExerciseType ExerciseType { get; set; } = ExerciseType.NORMAL;
    }
}