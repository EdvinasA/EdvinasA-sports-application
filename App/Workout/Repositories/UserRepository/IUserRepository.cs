using SaveApp.App.Workout.Models;

namespace SaveApp.App.Workout.Repositories.UserRepository
{
    public interface IUserRepository
    {
         User Register(User user, string password);
         string Login(string username, string password);
         bool UserExists(string username);
    }
}