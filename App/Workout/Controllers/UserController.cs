using Microsoft.AspNetCore.Mvc;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Services.UserService;

namespace SaveApp.App.Workout.Repositories.UserRepository
{
    [ApiController]
    [Route("api/user")]
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) {
            _userService = userService;
        }

        [HttpPost("register")]
        public User Register(User user) 
        {
            User createdUser = _userService.Register(user);

            return createdUser;
        }

        [HttpPost("login")]
        public User Login(UserLoginRequest request) 
        {
            int id = _userService.Login(request);

            return new User() { Id = id };
        }
        
    }
}