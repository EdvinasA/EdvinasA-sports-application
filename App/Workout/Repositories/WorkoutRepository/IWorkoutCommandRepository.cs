using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.WorkoutRepository
{
    public interface IWorkoutCommandRepository
    {
        int Create(WorkoutDetailsCreateInput input);
        WorkoutExercise AddExerciseToWorkout(AddExerciseToWorkoutInput exercise);
        void Update(WorkoutDetailsUpdateInput workoutDetails);
        void DeleteWorkoutExercise(int workoutExerciseId);
        void DeleteWorkout(int workoutId);
    }
}
