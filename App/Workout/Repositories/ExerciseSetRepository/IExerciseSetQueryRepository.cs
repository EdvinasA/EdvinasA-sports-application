using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.ExerciseSetRepository
{
    public interface IExerciseSetQueryRepository
    {
         List<ExerciseSet> GetHitoryOfExerciseSets(int workoutExerciseId, int exerciseId);
    }
}