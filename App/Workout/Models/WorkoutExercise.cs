namespace SaveApp.App.Workout.Models
{
    public class WorkoutExercise : ICloneable
    {
        public int? Id { get; set; }
        public Exercise? Exercise { get; set; }
        public List<ExerciseSet>? ExerciseSets { get; set; }
        public int RowNumber { get; set; }

        public object Clone()
        {
            return new WorkoutExercise
            {
                Id = null,
                Exercise = this.Exercise,
                ExerciseSets = new List<ExerciseSet>(),
                RowNumber = this.RowNumber,
            };
        }
    }
}
