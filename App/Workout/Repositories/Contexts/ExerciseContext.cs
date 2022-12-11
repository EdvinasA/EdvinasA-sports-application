using Microsoft.EntityFrameworkCore;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.Contexts;

public class ExerciseContext : DbContext
{
    public ExerciseContext(DbContextOptions<ExerciseContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<ExerciseEntity>()
            .Property(e => e.ExerciseType)
            .HasConversion(
                v => v.ToString(),
                v => (ExerciseType)Enum.Parse(typeof(ExerciseType), v)
            );
            
        modelBuilder
            .Entity<WorkoutEntity>()
                .HasMany(b => b.Exercises)
                .WithOne(o => o.WorkoutEntity)
                .OnDelete(DeleteBehavior.ClientCascade);

        modelBuilder
            .Entity<WorkoutExerciseEntity>()
                .HasMany(b => b.ExerciseSets)
                .WithOne(o => o.WorkoutExerciseEntity)
                .OnDelete(DeleteBehavior.ClientCascade);

        modelBuilder
            .Entity<WorkoutRoutineEntity>()
                .HasMany(b => b.WorkoutRoutineExercises)
                .WithOne(o => o.WorkoutRoutineEntity)
                .OnDelete(DeleteBehavior.ClientCascade);        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    public DbSet<ExerciseEntity>? Exercise { get; set; }
    public DbSet<ExerciseSetEntity>? ExerciseSet { get; set; }
    public DbSet<UserEntity>? User { get; set; }
    public DbSet<WorkoutEntity>? Workout { get; set; }
    public DbSet<WorkoutExerciseEntity>? WorkoutExercise { get; set; }
    public DbSet<ExerciseCategoryEntity>? ExerciseCategories { get; set; }
    public DbSet<WorkoutRoutineEntity>? WorkoutRoutine { get; set; }
    public DbSet<WorkoutRoutineExerciseEntity>? WorkoutRoutineExercise { get; set; }
}
