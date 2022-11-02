using System.Numerics;

namespace SaveApp.App.Workout.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public int? BodyWeight { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public String? Notes { get; set; }
        public List<Exercise>? Exercises { get; set; }
    }
}