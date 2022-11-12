using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.ExerciseSetRepository
{
    public interface IExerciseSetCommandRepository
    {
        void Create(WorkoutDetailsCreateInput input);
    }
}