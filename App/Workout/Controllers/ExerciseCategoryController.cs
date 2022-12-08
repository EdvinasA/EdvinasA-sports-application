using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Services.ExerciseCategoryService;

namespace SaveApp.App.Workout.Controllers;

[Authorize]
[ApiController]
[Route("api/exercise-category")]
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
    public ExerciseCategory Create(ExerciseCategory input)
    {
        return _commandService.Create(input);
    }

    [HttpPut]
    public void Update(ExerciseCategory input)
    {
        _commandService.Update(input);
    }

    [HttpGet]
    public List<ExerciseCategory> GetByUserId()
    {
        return _queryService.GetByUserId();
    }

    [HttpDelete("{categoryId}")]
    public void Delete(int categoryId)
    {
        _commandService.Delete(categoryId);
    }
}
