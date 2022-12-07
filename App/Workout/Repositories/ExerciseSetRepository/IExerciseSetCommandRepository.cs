using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.ExerciseSetRepository
{
    public interface IExerciseSetCommandRepository
    {
        ExerciseSet Create(ExerciseSet input, int exerciseId, int workoutExerciseId, int userId);
        void Delete(int exerciseSetId);
        void Update(int userId, ExerciseSet exerciseSet);
    }
}
