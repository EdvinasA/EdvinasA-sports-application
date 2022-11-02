using Microsoft.EntityFrameworkCore;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.Contexts;
public class ExerciseContext : DbContext
{
    public ExerciseContext(DbContextOptions<ExerciseContext> options) : base(options)
    {
    }
    public DbSet<ExerciseEntity>? Exercise { get; set; }
    public DbSet<ExerciseSetEntity>? ExerciseSet { get; set; }
    public DbSet<UserEntity>? User { get; set; }
    public DbSet<WorkoutEntity>? Workout { get; set; }
}