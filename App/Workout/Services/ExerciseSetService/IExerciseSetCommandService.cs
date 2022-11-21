using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.ExerciseSetService
{
    public interface IExerciseSetCommandService
    {
        ExerciseSet Create(ExerciseSetCreateInput input);
        void Delete(int ExerciseSetId);
        void Update(int userId, ExerciseSet exerciseSet);
    }
}