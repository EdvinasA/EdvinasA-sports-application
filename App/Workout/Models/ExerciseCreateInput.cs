namespace SaveApp.App.Workout.Models
{
    public class ExerciseCreateInput
    {
        public String? Name { get; set; }
        public String? Note { get; set; }
        public int ExerciseCategoryId { get; set; }
        public Boolean IsSingleBodyPartExercise { get; set; }
        public ExerciseType ExerciseType { get; set; }
    }
}