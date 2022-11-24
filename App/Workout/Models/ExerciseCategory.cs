namespace SaveApp.App.Workout.Models
{
    public class ExerciseCategory
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public ExerciseType ExerciseType { get; set; }
        public Boolean IsSinglePartExercise { get; set; }
        public List<Exercise>? Exercise { get; set; }
    }
}