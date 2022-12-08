using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.ExerciseSetRepository
{
    public interface IExerciseSetCommandRepository
    {
        ExerciseSet Create(ExerciseSet input, int exerciseId, int workoutExerciseId);
        void Delete(int exerciseSetId);
        void Update(ExerciseSet exerciseSet);
    }
}
