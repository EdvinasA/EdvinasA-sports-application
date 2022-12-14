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
            CreateMap<WorkoutEntity, WorkoutDetails>();
            CreateMap<WorkoutDetailsCreateInput, WorkoutEntity>();
            CreateMap<WorkoutExercise, WorkoutExerciseEntity>();
            CreateMap<WorkoutExerciseEntity, WorkoutExercise>();
            CreateMap<ExerciseSetCreateInput, ExerciseSetEntity>();
            CreateMap<ExerciseSetEntity, ExerciseSetCreateInput>();
            CreateMap<ExerciseCategory, ExerciseCategoryEntity>();
            CreateMap<ExerciseCategoryEntity, ExerciseCategory>();
            CreateMap<ExerciseCreateInput, ExerciseEntity>();
            CreateMap<ExerciseEntity, ExerciseCreateInput>();
            CreateMap<ExerciseSet, ExerciseSetPreviousValues>();
            CreateMap<WorkoutDetails, WorkoutDetailsCreateInput>();
            CreateMap<WorkoutDetails, WorkoutEntity>();
            CreateMap<WorkoutRoutineEntity, WorkoutRoutine>();
            CreateMap<WorkoutRoutine, WorkoutRoutineEntity>();
            CreateMap<WorkoutRoutineExerciseEntity, WorkoutRoutineExercise>();
            CreateMap<WorkoutRoutineExercise, WorkoutRoutineExerciseEntity>();
        }
    }
}