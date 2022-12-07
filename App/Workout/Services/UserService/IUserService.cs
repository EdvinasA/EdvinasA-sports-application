using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.UserService
{
    public interface IUserService
    {
        User Register(User user);
        int Login(UserLoginRequest request);
    }
}