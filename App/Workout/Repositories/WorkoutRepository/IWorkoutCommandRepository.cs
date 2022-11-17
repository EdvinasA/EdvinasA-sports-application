using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.WorkoutRepository
{
    public interface IWorkoutCommandRepository
    {
         void Create(int userId, WorkoutDetailsCreateInput input);
         WorkoutExercise AddExerciseToWorkout(int userId, AddExerciseToWorkoutInput exercise);
    }
}