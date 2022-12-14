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

        [HttpPost]
        public WorkoutRoutineExercise CreateForWorkoutRoutine(AddExerciseToRoutineInput input)
        {
            return _commandService.CreateForWorkoutRoutine(input);
        }

        [HttpPut]
        public void Update(WorkoutRoutineExercise input)
        {
            _commandService.Update(input);
        }

        [HttpPut("all")]
        public void UpdateExercisesInRoutine(List<WorkoutRoutineExercise> input)
        {
            _commandService.UpdateExercisesInRoutine(input);
        }

        [HttpDelete("{workoutRoutineExerciseId}")]
        public void Delete(int workoutRoutineExerciseId)
        {
            _commandService.Delete(workoutRoutineExerciseId);
        }
    }
}
