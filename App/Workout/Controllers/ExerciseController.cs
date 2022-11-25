using Microsoft.AspNetCore.Mvc;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Services;
using SaveApp.App.Workout.Services.ExerciseService;

namespace SaveApp.App.Workout.Controllers;

[ApiController]
[Route("api/exercise/{userId}")]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseCommandService _commandService;
    private readonly IExerciseQueryService _queryService;

    public ExerciseController(IExerciseCommandService commandService, IExerciseQueryService queryService) {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpPost]
    public Exercise CreateExercise(int userId, ExerciseCreateInput exercise) {
        return _commandService.CreateExercise(userId, exercise);
    }

    [HttpPut]
    public void UpdateExercise(int userId, Exercise exercise) {
        _commandService.UpdateExercise(userId, exercise);
    }

    [HttpGet]
    public List<Exercise> GetExercises(int userId) {
        return _queryService.GetAllExercises(userId);
    }
}