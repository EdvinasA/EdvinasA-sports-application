using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.WorkoutRepository
{
    public interface IWorkoutCommandRepository
    {
        int Create(int userId, WorkoutDetailsCreateInput input);
        WorkoutExercise AddExerciseToWorkout(int userId, AddExerciseToWorkoutInput exercise);
        void Update(int userId, WorkoutDetailsUpdateInput workoutDetails);
        void DeleteWorkoutExercise(int userId, int workoutExerciseId);
        void DeleteWorkout(int userId, int workoutId);
    }
}
