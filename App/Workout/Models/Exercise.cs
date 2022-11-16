namespace SaveApp.App.Workout.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public ExerciseBodyPart ExerciseBodyPart { get; set; }
    }
}