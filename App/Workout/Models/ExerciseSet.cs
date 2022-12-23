using System.Numerics;
using Newtonsoft.Json;

namespace SaveApp.App.Workout.Models
{
    public class ExerciseSet
    {
        public int Id { get; set; }
        public double? Weight { get; set; }
        public int? Reps { get; set; }
        public String? Notes { get; set; }
        public ExerciseSetPreviousValues? ExerciseSetPreviousValues { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
