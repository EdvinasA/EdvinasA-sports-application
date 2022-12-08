using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Services;
using SaveApp.App.Workout.Services.ExerciseService;

namespace SaveApp.App.Workout.Controllers;

[Authorize]
[ApiController]
[Route("api/exercise")]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseCommandService _commandService;
    private readonly IExerciseQueryService _queryService;

    public ExerciseController(
        IExerciseCommandService commandService,
        IExerciseQueryService queryService
    )
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpPost]
    public Exercise CreateExercise(ExerciseCreateInput exercise)
    {
        return _commandService.CreateExercise(exercise);
    }

    [HttpPut]
    public void UpdateExercise(Exercise exercise)
    {
        _commandService.UpdateExercise(exercise);
    }

    [HttpGet]
    public List<Exercise> GetExercises()
    {
        return _queryService.GetAllExercises();
    }

    [HttpGet("category/{categoryId}")]
    public List<Exercise> GetExercisesByCategory(int categoryId)
    {
        return _queryService.GetExercisesByCategory(categoryId);
    }

    [HttpDelete("{exerciseId}")]
    public void DeleteExercise(int exerciseId)
    {
        _commandService.Delete(exerciseId);
    }
}
