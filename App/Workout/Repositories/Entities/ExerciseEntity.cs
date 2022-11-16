using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.Entities
{
    public class ExerciseEntity
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public ExerciseBodyPart ExerciseBodyPart { get; set; }
        public UserEntity? User { get; set; }
    }
}