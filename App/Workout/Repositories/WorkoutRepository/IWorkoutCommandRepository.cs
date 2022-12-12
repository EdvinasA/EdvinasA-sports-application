using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.WorkoutRepository
{
    public interface IWorkoutCommandRepository
    {
        int Create(WorkoutDetailsCreateInput input);
        int CreateFromRoutine(WorkoutDetails details);
        WorkoutExercise AddExerciseToWorkout(AddExerciseToWorkoutInput exercise);
        void Update(WorkoutDetailsUpdateInput workoutDetails);
        void UpdateExercises(List<WorkoutExercise> exercises);
        void DeleteWorkoutExercise(int workoutExerciseId);
        void DeleteWorkout(int workoutId);
    }
}
