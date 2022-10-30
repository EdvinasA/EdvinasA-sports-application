using Microsoft.AspNetCore.Mvc;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Services;

namespace SaveApp.App.Workout.Controllers;

[ApiController]
[Route("api/exercise")]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseCommandService _commandService;

    public ExerciseController(IExerciseCommandService commandService) {
        _commandService = commandService;
    }

    [HttpPost("create")]
    public void Create(Exercise exercise) {
        _commandService.CreateExercise(exercise);
    }
}