using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.ExerciseSetRepository
{
    public interface IExerciseSetCommandRepository
    {
        ExerciseSet Create(ExerciseSet input, int exerciseId, int workoutExerciseId);
        void CreateSetForRoutine(ExerciseSet set, int exerciseId, int workoutExerciseId);
        ExerciseSet CopySet(int setId);
        void Delete(int exerciseSetId);
        void Update(ExerciseSet exerciseSet);
    }
}
