using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.ExerciseSetService
{
    public interface IExerciseSetCommandService
    {
        ExerciseSet Create(ExerciseSetCreateInput input);
        void CreateSetForRoutine(int exerciseId, int workoutExerciseId);
        void Delete(int ExerciseSetId);
        void Update(ExerciseSet exerciseSet);
    }
}
