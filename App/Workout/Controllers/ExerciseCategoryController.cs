using Microsoft.AspNetCore.Mvc;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Services.ExerciseCategoryService;

namespace SaveApp.App.Workout.Controllers;

[ApiController]
[Route("api/exercise-category/{userId}")]
public class ExerciseCategoryController
{
    private readonly IExerciseCategoryCommandService _commandService;
    private readonly IExerciseCategoryQueryService _queryService;

    public ExerciseCategoryController(
        IExerciseCategoryCommandService commandService,
        IExerciseCategoryQueryService queryService
    )
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpPost]
    public ExerciseCategory Create(int userId, ExerciseCategory input)
    {
        return _commandService.Create(userId, input);
    }

    [HttpPut]
    public void Update(int userId, ExerciseCategory input)
    {
        _commandService.Update(userId, input);
    }

    [HttpGet]
    public List<ExerciseCategory> GetByUserId(int userId)
    {
        return _queryService.GetByUserId(userId);
    }

    [HttpDelete("{categoryId}")]
    public void Delete(int userId, int categoryId)
    {
        _commandService.Delete(userId, categoryId);
    }
}
