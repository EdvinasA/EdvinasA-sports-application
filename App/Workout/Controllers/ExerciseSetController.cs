using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Services.ExerciseSetService;

namespace SaveApp.App.Workout.Controllers;

[Authorize]
[ApiController]
[Route("api/exercise-set")]
public class ExerciseSetController
{
    private readonly IExerciseSetCommandService _commandService;
    private readonly IExerciseSetQueryService _queryService;

    public ExerciseSetController(IExerciseSetCommandService commandService, IExerciseSetQueryService queryService)
    {
        _commandService = commandService;
        _queryService = queryService;
    }

    [HttpPost]
    public ExerciseSet Create(ExerciseSetCreateInput input)
    {
        return _commandService.Create(input);
    }

    [HttpPost("{setId}")]
    public ExerciseSet CopySet(int setId)
    {
        return _commandService.CopySet(setId);
    }

    [HttpDelete("{exerciseSetId}")]
    public void Delete(int exerciseSetId)
    {
        _commandService.Delete(exerciseSetId);
    }

    [HttpPut]
    public void UpdateSet(ExerciseSet exerciseSet)
    {
        _commandService.Update(exerciseSet);
    }

    [HttpGet]
    public List<ExerciseSet> GetHitoryOfExerciseSets(int workoutExerciseId, int exerciseId)
    {
        return _queryService.GetHitoryOfExerciseSets(workoutExerciseId, exerciseId);
    }
}
