using Microsoft.EntityFrameworkCore.Internal;

namespace SaveApp.App.Workout.Models
{
    public class OverallStatistics
    {
        public int NumberOfWorkouts { get; set; }
        public List<int>? WorkoutDuration { get; set; }
        public List<int>? Volume { get; set; }
        public List<int>? TotalSets { get; set; }
        public List<int>? TotalReps { get; set; }
        public List<double>? BodyWeight { get; set; }
    }
}