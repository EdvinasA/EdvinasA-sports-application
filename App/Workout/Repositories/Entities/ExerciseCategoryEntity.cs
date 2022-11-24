using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.Entities
{
    public class ExerciseCategoryEntity
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public Boolean IsSinglePartExercise { get; set; }
        public List<ExerciseEntity>? Exercise { get; set; }
        public UserEntity? User { get; set; }
    }
}