using Microsoft.EntityFrameworkCore;
using SaveApp.App.Weather.Repositories.Context;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.ExerciseRepository;
using SaveApp.App.Weather.Repositories;
using SaveApp.App.Weather.Services;
using SaveApp.App.Workout.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<WeatherContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<ExerciseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IExerciseCommandService, ExerciseCommandService>();
builder.Services.AddTransient<IExerciseCommandRepository, ExerciseCommandRepository>();
builder.Services.AddTransient<IWeatherRepository, WeatherRepository>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
