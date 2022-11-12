using Microsoft.AspNetCore.Mvc;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Entities;
using SaveApp.App.Workout.Services;

namespace SaveApp.App.Workout.Controllers;

[ApiController]
[Route("api/exercise/{userId}")]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseCommandService _commandService;

    public ExerciseController(IExerciseCommandService commandService) {
        _commandService = commandService;
    }

    [HttpPost("create-exercise")]
    public void CreateExercise(int userId, Exercise exercise) {
        _commandService.CreateExercise(userId, exercise);
    }

    [HttpPost("create-exercise-set")]
    public void CreateExerciseSet(int userId, Exercise exercise) {
        _commandService.CreateExercise(userId, exercise);
    }

    [HttpGet]
    public List<ExerciseEntity> GetExercises(int userId) {
        return _commandService.GetAllExercises(userId);
    }

    [HttpGet("set")]
    public List<ExerciseSet>? GetExerciseSets(int userId) {
        return null;
    }
}