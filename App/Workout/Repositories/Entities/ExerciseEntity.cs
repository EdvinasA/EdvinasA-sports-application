using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.Entities
{
    public class ExerciseEntity
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public ExerciseCategoryEntity? ExerciseCategory { get; set; }
        public String? Note { get; set; }
        public ExerciseType ExerciseType { get; set; } = ExerciseType.STRENGTH_WEIGHT_REPS;
        public Boolean IsSingleBodyPartExercise { get; set; }
        public UserEntity? User { get; set; }
    }
}