using Microsoft.IdentityModel.Tokens;

namespace SaveApp.App.Workout.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public List<ExerciseSet>? ExerciseSets { get; set; }
        public User User { get; set; }
    }
}