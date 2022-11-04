namespace SaveApp.App.Workout.Models
{
    public class WorkoutDetailsCreateInput
    {
        public String? Name { get; set; }
        public int? BodyWeight { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public String? Notes { get; set; }
    }
}