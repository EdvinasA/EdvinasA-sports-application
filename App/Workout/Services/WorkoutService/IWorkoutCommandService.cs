using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.WorkoutService
{
    public interface IWorkoutCommandService
    {
        int Create();
        int CreateFromRoutine(WorkoutDetails routine);
        WorkoutExercise AddExerciseToWorkout(AddExerciseToWorkoutInput exercise);
        void Update(WorkoutDetailsUpdateInput workoutDetails);
        void UpdateExercises(List<WorkoutExercise> exercises);
        void DeleteWorkoutExercise(int workoutExerciseId);
        void DeleteWorkout(int workoutId);
        int RepeatWorkout(int workoutId);
    }
}
