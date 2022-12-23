using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.ExerciseSetService
{
    public interface IExerciseSetQueryService
    {
         List<ExerciseSet> GetHitoryOfExerciseSets(int workoutExerciseId, int exerciseId);
    }
}