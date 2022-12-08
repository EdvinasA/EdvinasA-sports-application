using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using SaveApp.App.Workout.Models;
using SaveApp.App.Workout.Repositories.Contexts;
using SaveApp.App.Workout.Repositories.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace SaveApp.App.Workout.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ExerciseContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserRepository(ExerciseContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        public string Login(string username, string password)
        {
            var user = _context.User.FirstOrDefault(
                u => u.Email.ToLower().Equals(username.ToLower())
            );

            if (user == null)
            {
                return "";
            }
            else if (VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return CreateToken(user);
            }

            return "";
        }

        public User Register(User user, string password)
        {
            if (UserExists(user.Email))
            {
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
        )
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(
            string password,
            byte[] passwordHash,
            byte[] passwordSalt
        )
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(UserEntity user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            };

            SymmetricSecurityKey key = new(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(365),
                SigningCredentials = credentials
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
