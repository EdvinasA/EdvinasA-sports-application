using System.Numerics;
using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.Entities
{
    public class ExerciseSetEntity
    {
        public int Id { get; set; }
        public double? Weight { get; set; }
        public int? Reps { get; set; }
        public String? Notes { get; set; }
        public ExerciseEntity? ExerciseEntity { get; set; }
        public WorkoutExerciseEntity? WorkoutExerciseEntity { get; set; }
        public UserEntity? UserEntity { get; set; }
    }
}