using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.UserRepository;

namespace SaveApp.App.Workout.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository) 
        {
            _repository = repository;
        }

        public string Login(UserLoginRequest request)
        {
            return _repository.Login(request.Email, request.Password);
        }

        public User Register(User user)
        {
            return _repository.Register(user, user.Password);
        }
    }
}