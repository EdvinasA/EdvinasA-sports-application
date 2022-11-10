using Microsoft.EntityFrameworkCore;
using SaveApp.App.Weather.Repositories;
using SaveApp.App.Weather.Repositories.Context;
using SaveApp.App.Weather.Services;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.ExerciseRepository;
using SaveApp.App.Workout.Services;
using sports_application.App.Workout.Repositories.WorkoutRepository;
using sports_application.App.Workout.Services.WorkoutService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<WeatherContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<ExerciseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddTransient<IWorkoutCommandRepository, WorkoutCommandRepository>();
builder.Services.AddScoped<IWorkoutCommandService, WorkoutCommandService>();
builder.Services.AddScoped<IExerciseCommandService, ExerciseCommandService>();
builder.Services.AddTransient<IExerciseCommandRepository, ExerciseCommandRepository>();
builder.Services.AddScoped<IWorkoutQueryService, WorkoutQueryService>();
builder.Services.AddTransient<IWorkoutQueryRepository, WorkoutQueryRepository>();
builder.Services.AddTransient<IWeatherRepository, WeatherRepository>();
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

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("origins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
