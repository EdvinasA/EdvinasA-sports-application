using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.StatisticsService
{
    public interface IStatisticsService
    {
         public OverallStatistics GetOverallStatistics();
    }
}