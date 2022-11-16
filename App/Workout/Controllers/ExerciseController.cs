using Microsoft.AspNetCore.Mvc;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Entities;
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

    [HttpGet("body-part")]
    public List<Exercise> GetExercisesByBodyPart(int userId, ExerciseBodyPart exerciseBodyPart) {
        return _queryService.GetExercisesByBodyPart(userId, exerciseBodyPart);
    }
}