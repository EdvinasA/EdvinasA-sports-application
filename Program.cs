using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.ExerciseRepository;
using SaveApp.App.Workout.Services;
using SaveApp.App.Workout.Repositories.WorkoutRepository;
using SaveApp.App.Workout.Services.WorkoutService;
using SaveApp.App.Workout.Services.ExerciseSetService;
using SaveApp.App.Workout.Repositories.ExerciseSetRepository;
using SaveApp.App.Workout.Services.ExerciseService;
using SaveApp.App.Workout.Services.ExerciseCategoryService;
using SaveApp.App.Workout.Repositories.ExerciseCategoryRepository;
using SaveApp.App.Workout.Repositories.UserRepository;
using SaveApp.App.Workout.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.OpenApi.Models;
using SaveApp.App.Workout.Repositories.WorkoutRoutineRepository;
using SaveApp.App.Workout.Repositories.WorkoutRoutineExerciseRepository;
using SaveApp.App.Workout.Services.WorkoutRoutineService;
using SaveApp.App.Workout.Services.WorkoutRoutineExerciseService;
using SaveApp.App.Workout.Services.StatisticsService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ExerciseContext>(options =>
    {
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
builder.Services
    .AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme {
        Description = "Standard Authorization header isomg the Bearer scheme, e.g. \"bearer {token} \"",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => { 
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

builder.Services.AddTransient<IWorkoutCommandRepository, WorkoutCommandRepository>();
builder.Services.AddScoped<IWorkoutCommandService, WorkoutCommandService>();

builder.Services.AddTransient<IExerciseQueryRepository, ExerciseQueryRepository>();
builder.Services.AddScoped<IExerciseQueryService, ExerciseQueryService>();

builder.Services.AddScoped<IExerciseCommandService, ExerciseCommandService>();
builder.Services.AddTransient<IExerciseCommandRepository, ExerciseCommandRepository>();

builder.Services.AddScoped<IWorkoutQueryService, WorkoutQueryService>();
builder.Services.AddTransient<IWorkoutQueryRepository, WorkoutQueryRepository>();

builder.Services.AddScoped<IExerciseSetCommandService, ExerciseSetCommandService>();
builder.Services.AddTransient<IExerciseSetCommandRepository, ExerciseSetCommandRepository>();

builder.Services.AddScoped<IExerciseCategoryCommandService, ExerciseCategoryCommandService>();
builder.Services.AddTransient<
    IExerciseCategoryCommandRepository,
    ExerciseCategoryCommandRepository
>();

builder.Services.AddScoped<IExerciseCategoryQueryService, ExerciseCategoryQueryService>();
builder.Services.AddTransient<IExerciseCategoryQueryRepository, ExerciseCategoryQueryRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddScoped<IWorkoutRoutineCommandService, WorkoutRoutineCommandService>();
builder.Services.AddTransient<IWorkoutRoutineCommandRepository, WorkoutRoutineCommandRepository>();

builder.Services.AddScoped<IWorkoutRoutineExerciseCommandService, WorkoutRoutineExerciseCommandService>();
builder.Services.AddScoped<IWorkoutRoutineExerciseCommandRepository, WorkoutRoutineExerciseCommandRepository>();

builder.Services.AddScoped<IWorkoutRoutineQueryService, WorkoutRoutineQueryService>();
builder.Services.AddTransient<IWorkoutRoutineQueryRepository, WorkoutRoutineQueryRepository>();

builder.Services.AddScoped<IStatisticsService, StatisticsService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "origins",
        policy =>
        {
            policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
        }
    );
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
