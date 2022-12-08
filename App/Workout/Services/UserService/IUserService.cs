using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Services.UserService
{
    public interface IUserService
    {
        User Register(User user);
        string Login(UserLoginRequest request);
    }
}