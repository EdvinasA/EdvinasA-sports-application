using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Services.WorkoutRoutineExerciseService;

namespace SaveApp.App.Workout.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/workout-routine-exercise")]
    public class WorkoutRoutineExerciseController
    {
        private readonly IWorkoutRoutineExerciseCommandService _commandService;

        public WorkoutRoutineExerciseController(
            IWorkoutRoutineExerciseCommandService commandService
        )
        {
            _commandService = commandService;
        }

        [HttpPost("{exerciseId}")]
        public WorkoutRoutineExercise CreateForWorkoutRoutine(int exerciseId)
        {
            return _commandService.CreateForWorkoutRoutine(exerciseId);
        }

        [HttpPut]
        public void Update(WorkoutRoutineExercise input)
        {
            _commandService.Update(input);
        }

        [HttpDelete("{workoutRoutineExerciseId}")]
        public void Delete(int workoutRoutineExerciseId)
        {
            _commandService.Delete(workoutRoutineExerciseId);
        }
    }
}
