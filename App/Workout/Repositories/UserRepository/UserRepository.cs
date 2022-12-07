using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.Entities;

namespace SaveApp.App.Workout.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ExerciseContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ExerciseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Login(string username, string password)
        {
            var user = _context.User
                .FirstOrDefault(u => u.Email.ToLower().Equals(username.ToLower()));

            if (user == null) {
                return 0;
            } else if (VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)) {
                return user.Id;
            }

            return 0;
        }

        public User Register(User user, string password)
        {
            if (UserExists(user.Email)) {
                return new User();
            }
            
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            UserEntity entity = _mapper.Map<UserEntity>(user);

            entity.PasswordHash = passwordHash;
            entity.PasswordSalt = passwordSalt;

            _context.User.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<User>(entity);
        }

        public bool UserExists(string username)
        {
            return _context.User.Any(o => o.Email.ToLower() == username.ToLower());
        }

        private static void CreatePasswordHash(
            string password,
            out byte[] passwordHash,
            out byte[] passwordSalt
        ) {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
         }

         private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) 
         {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
         }
    }
}
