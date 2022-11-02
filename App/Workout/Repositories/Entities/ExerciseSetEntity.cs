using System.Numerics;
using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.Entities
{
    public class ExerciseSetEntity
    {
        public int Id { get; set; }
        public int? Weigth { get; set; }
        public int? Reps { get; set; }
        public String? Notes { get; set; }
        public ExerciseType ExerciseType { get; set; } = ExerciseType.NORMAL;
        public ExerciseEntity? ExerciseEntity { get; set; }
        public UserEntity? UserEntity { get; set; }
    }
}