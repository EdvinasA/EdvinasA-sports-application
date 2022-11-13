using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.ExerciseSetRepository
{
    public interface IExerciseSetCommandRepository
    {
         ExerciseSet Create(ExerciseSetCreateInput input);
         void Delete(int exerciseSetId);
    }
}