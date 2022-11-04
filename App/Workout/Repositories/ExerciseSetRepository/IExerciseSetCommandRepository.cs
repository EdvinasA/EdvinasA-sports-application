using SaveApp.App.Workout.Models;

namespace sports_application.App.Workout.Repositories.ExerciseSetRepository
{
    public interface IExerciseSetCommandRepository
    {
        void Create(WorkoutDetailsCreateInput input);
    }
}