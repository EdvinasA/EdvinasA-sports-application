using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SaveApp.App.Weather.Repositories;
using SaveApp.App.Weather.Repositories.Context;
using SaveApp.App.Weather.Services;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.ExerciseRepository;
using SaveApp.App.Workout.Services;
using SaveApp.App.Workout.Repositories.WorkoutRepository;
using SaveApp.App.Workout.Services.WorkoutService;
using SaveApp.App.Workout.Services.ExerciseSetService;
using SaveApp.App.Workout.Repositories.ExerciseSetRepository;
using SaveApp.App.Workout.Services.ExerciseService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<WeatherContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<ExerciseContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddTransient<IWorkoutCommandRepository, WorkoutCommandRepository>();
builder.Services.AddScoped<IWorkoutCommandService, WorkoutCommandService>();
builder.Services.AddTransient<IExerciseQueryRepository, ExerciseQueryRepository>();
builder.Services.AddScoped<IExerciseQueryService, ExerciseQueryService>();
builder.Services.AddScoped<IExerciseCommandService, ExerciseCommandService>();
builder.Services.AddTransient<IExerciseCommandRepository, ExerciseCommandRepository>();
builder.Services.AddScoped<IWorkoutQueryService, WorkoutQueryService>();
builder.Services.AddTransient<IWorkoutQueryRepository, WorkoutQueryRepository>();
builder.Services.AddTransient<IWeatherRepository, WeatherRepository>();
builder.Services.AddScoped<IExerciseSetCommandService, ExerciseSetCommandService>();
builder.Services.AddTransient<IExerciseSetCommandRepository, ExerciseSetCommandRepository>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "origins",
    policy =>
                      {
                          policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                      });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("origins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
