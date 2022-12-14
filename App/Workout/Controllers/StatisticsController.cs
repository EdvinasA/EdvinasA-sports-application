using Microsoft.AspNetCore.Mvc;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Services.StatisticsService;

namespace SaveApp.App.Workout.Controllers
{
    [ApiController]
    [Route("api/stats")]
    public class StatisticsController
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService) {
            _statisticsService = statisticsService;
        }
        
        [HttpGet]
        public OverallStatistics GetStatistics() {
            return _statisticsService.GetOverallStatistics();
        }
    }
}