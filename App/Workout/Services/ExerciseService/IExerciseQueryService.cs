using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.ExerciseService
{
    public interface IExerciseQueryService
    {
        List<Exercise> GetAllExercises(int userId);
        List<Exercise> GetExercisesByBodyPart(int userId, ExerciseBodyPart exerciseBodyPart);
    }
}