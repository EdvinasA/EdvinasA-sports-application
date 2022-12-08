using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.WorkoutService
{
    public interface IWorkoutCommandService
    {
        int Create();
        WorkoutExercise AddExerciseToWorkout(AddExerciseToWorkoutInput exercise);
        void Update(WorkoutDetailsUpdateInput workoutDetails);
        void DeleteWorkoutExercise(int workoutExerciseId);
        void DeleteWorkout(int workoutId);
        int RepeatWorkout(int workoutId);
    }
}
