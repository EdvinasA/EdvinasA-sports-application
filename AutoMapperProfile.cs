using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Exercise, ExerciseEntity>();
            CreateMap<ExerciseEntity, Exercise>();
            CreateMap<ExerciseSetEntity, ExerciseSet>();
            CreateMap<ExerciseSet, ExerciseSetEntity>();
            CreateMap<UserEntity, User>();
            CreateMap<User, UserEntity>();
            CreateMap<WorkoutEntity, Workout>();
            CreateMap<Workout, WorkoutEntity>();
        }
    }
}