using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.WorkoutRepository;
using SaveApp.App.Workout.Services.WorkoutService;

namespace SaveApp.App.Workout.Services.StatisticsService
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IWorkoutQueryService _workoutQueryService;

        public StatisticsService(IWorkoutQueryService workoutQueryService)
        {
            _workoutQueryService = workoutQueryService;
        }

        public OverallStatistics GetOverallStatistics()
        {
            List<WorkoutDetails> workoutsByUser = _workoutQueryService.GetAllByUserId();

            OverallStatistics stats = new OverallStatistics()
            {
                NumberOfWorkouts = workoutsByUser.Count,
                WorkoutDuration = GetListOfWorkoutDurations(workoutsByUser),
                Volume = GetListOfVolume(workoutsByUser),
                TotalSets = GetListOfTotalSets(workoutsByUser),
                TotalReps = GetListOfTotalReps(workoutsByUser),
                BodyWeight = GetListOfBodyweights(workoutsByUser)
            };

            return stats;
        }

        public List<ExerciseStatistics> GetExerciseStatisticsByExerciseId(int exerciseId)
        {
            List<WorkoutExercise> exercises = _workoutQueryService.GetWorkoutsByExerciseId(
                exerciseId
            );

            List<ExerciseStatistics> stats = new();

            exercises.ForEach(o =>
            {
                if (o.ExerciseSets != null && o.ExerciseSets.Count != 0)
                {
                    List<ExerciseSet> updateSets = o.ExerciseSets.OrderBy(p => p.Id).ToList();
                    updateSets.ForEach(e =>
                    {
                        stats.Add(new ExerciseStatistics() { Weight = e.Weight, Reps = e.Reps });
                    });
                }
            });
            return stats;
        }

        private static List<int> GetListOfWorkoutDurations(List<WorkoutDetails> workoutsByUser)
        {
            return workoutsByUser
                .OrderBy(p => p.Id)
                .Select(o =>
                {
                    if (o.StartTime != null && o.EndTime != null)
                    {
                        TimeSpan ts = (TimeSpan)(o.EndTime - o.StartTime);
                        return (int)ts.TotalMinutes;
                    }
                    return 0;
                })
                .ToList();
        }

        private static List<double> GetListOfBodyweights(List<WorkoutDetails> workoutsByUser)
        {
            return workoutsByUser
                .OrderBy(p => p.Id)
                .Select(o =>
                {
                    if (o.BodyWeight != null)
                    {
                        return (double)o.BodyWeight;
                    }
                    return 0;
                })
                .ToList();
        }

        private static List<double> GetListOfVolume(List<WorkoutDetails> workoutsByUser)
        {
            List<WorkoutDetails> workoutsByUserOrdered = workoutsByUser.OrderBy(p => p.Id).ToList();
            List<double> newListOfIntegers = new List<double>();

            workoutsByUserOrdered.ForEach(o =>
            {
                var volumeOfWorkout = 0.0;
                if (o.Exercises != null && o.Exercises.Count != 0)
                {
                    o.Exercises.ForEach(e =>
                    {
                        if (e.ExerciseSets != null && e.ExerciseSets.Count != 0)
                        {
                            e.ExerciseSets.ForEach(f =>
                            {
                                if (f.Weight != null)
                                {
                                    volumeOfWorkout += (double)f.Weight;
                                }
                            });
                        }
                    });
                }
                newListOfIntegers.Add(volumeOfWorkout);
                return;
            });

            return newListOfIntegers;
        }

        private static List<int> GetListOfTotalSets(List<WorkoutDetails> workoutsByUser)
        {
            List<WorkoutDetails> workoutsByUserOrdered = workoutsByUser.OrderBy(p => p.Id).ToList();
            List<int> newListOfIntegers = new List<int>();

            workoutsByUserOrdered.ForEach(o =>
            {
                var sets = 0;
                if (o.Exercises != null && o.Exercises.Count != 0)
                {
                    o.Exercises.ForEach(e =>
                    {
                        if (e.ExerciseSets != null)
                        {
                            sets += e.ExerciseSets.Count;
                        }
                    });
                }
                newListOfIntegers.Add(sets);
                return;
            });

            return newListOfIntegers;
        }

        private static List<int> GetListOfTotalReps(List<WorkoutDetails> workoutsByUser)
        {
            List<WorkoutDetails> workoutsByUserOrdered = workoutsByUser.OrderBy(p => p.Id).ToList();
            List<int> newListOfIntegers = new List<int>();

            workoutsByUserOrdered.ForEach(o =>
            {
                var repsOfWorkout = 0;
                if (o.Exercises != null && o.Exercises.Count != 0)
                {
                    o.Exercises.ForEach(e =>
                    {
                        if (e.ExerciseSets != null && e.ExerciseSets.Count != 0)
                        {
                            e.ExerciseSets.ForEach(f =>
                            {
                                if (f.Reps != null)
                                {
                                    repsOfWorkout += (int)f.Reps;
                                }
                            });
                        }
                    });
                }
                newListOfIntegers.Add(repsOfWorkout);
                return;
            });

            return newListOfIntegers;
        }
    }
}
