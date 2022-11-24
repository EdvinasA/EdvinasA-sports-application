using Microsoft.EntityFrameworkCore;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.Contexts;
public class ExerciseContext : DbContext
{
    public ExerciseContext(DbContextOptions<ExerciseContext> options) : base(options)
    {
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder
            .Entity<ExerciseEntity>()
            .Property(e => e.ExerciseType)
            .HasConversion(
                v => v.ToString(),
                v => (ExerciseType)Enum.Parse(typeof(ExerciseType), v)
            );
    }

    public DbSet<ExerciseEntity>? Exercise { get; set; }
    public DbSet<ExerciseSetEntity>? ExerciseSet { get; set; }
    public DbSet<UserEntity>? User { get; set; }
    public DbSet<WorkoutEntity>? Workout { get; set; }
    public DbSet<WorkoutExerciseEntity>? WorkoutExercise { get; set; }
    public DbSet<ExerciseCategoryEntity>? ExerciseCategories { get; set; }
}