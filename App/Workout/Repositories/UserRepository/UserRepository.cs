using System.Reflection;
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

            List<ExerciseCategoryEntity> categoryEntities = DefaultListOfCategories();
            categoryEntities.ForEach(o => o.User = entity);

            _context.AddRange(categoryEntities);
            _context.SaveChanges();

            List<ExerciseEntity> absExercises = DefaultListOfAbsExercises();
            absExercises.ForEach(o => { o.User = entity; o.ExerciseCategory = categoryEntities.Where(o => o.Name == "Abs").Single(); });
            List<ExerciseEntity> backExercises = DefaultListOfBackExercises();
            backExercises.ForEach(o => { o.User = entity; o.ExerciseCategory = categoryEntities.Where(o => o.Name == "Back").Single(); });
            List<ExerciseEntity> bicepsExercises = DefaultListOfBicepExercises();
            bicepsExercises.ForEach(o => { o.User = entity; o.ExerciseCategory = categoryEntities.Where(o => o.Name == "Biceps").Single(); });
            List<ExerciseEntity> cardioExercises = DefaultListOfCardioExercises();
            cardioExercises.ForEach(o => { o.User = entity; o.ExerciseCategory = categoryEntities.Where(o => o.Name == "Cardio").Single(); });
            List<ExerciseEntity> chestExercises = DefaultListOfChestExercises();
            chestExercises.ForEach(o => { o.User = entity; o.ExerciseCategory = categoryEntities.Where(o => o.Name == "Chest").Single(); });
            List<ExerciseEntity> legsExercises = DefaultListOfLegsExercises();
            legsExercises.ForEach(o => { o.User = entity; o.ExerciseCategory = categoryEntities.Where(o => o.Name == "Legs").Single(); });
            List<ExerciseEntity> shouldersExercises = DefaultListOfShouldersExercises();
            shouldersExercises.ForEach(o => { o.User = entity; o.ExerciseCategory = categoryEntities.Where(o => o.Name == "Shoulders").Single(); });
            List<ExerciseEntity> tricepsExercises = DefaultListOfTricepsExercises();
            tricepsExercises.ForEach(o => { o.User = entity; o.ExerciseCategory = categoryEntities.Where(o => o.Name == "Triceps").Single(); });

            _context.AddRange(absExercises);
            _context.AddRange(backExercises);
            _context.AddRange(bicepsExercises);
            _context.AddRange(cardioExercises);
            _context.AddRange(chestExercises);
            _context.AddRange(legsExercises);
            _context.AddRange(shouldersExercises);
            _context.AddRange(tricepsExercises);
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

        private static List<ExerciseCategoryEntity> DefaultListOfCategories() {
            return new List<ExerciseCategoryEntity> {
                new ExerciseCategoryEntity { Name = "Abs" },
                new ExerciseCategoryEntity { Name = "Back" },
                new ExerciseCategoryEntity { Name = "Biceps" },
                new ExerciseCategoryEntity { Name = "Cardio" },
                new ExerciseCategoryEntity { Name = "Chest" },
                new ExerciseCategoryEntity { Name = "Legs" },
                new ExerciseCategoryEntity { Name = "Shoulders" },
                new ExerciseCategoryEntity { Name = "Triceps" }
            };
        }

        private static List<ExerciseEntity> DefaultListOfAbsExercises() {
            return new List<ExerciseEntity> {
                new ExerciseEntity { Name = "Crunches", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Leg Raises", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false }
            };
        }

        private static List<ExerciseEntity> DefaultListOfBackExercises() {
            return new List<ExerciseEntity> {
                new ExerciseEntity { Name = "Assisted Chin Up", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Assisted Pull Up", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Barbell Row", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Cable Row", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Chin Up", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Deadlift", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Dumbbell Row", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Hyperextensions", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Pull Up", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Pulldowns", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
            };
        }

        private static List<ExerciseEntity> DefaultListOfBicepExercises() {
            return new List<ExerciseEntity> {
                new ExerciseEntity { Name = "Barbell Bicep Curl", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Concentration Curl", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Dumbbell Bicep Curl", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Hammer Curl", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false }
            };
        }

        private static List<ExerciseEntity> DefaultListOfCardioExercises() {
            return new List<ExerciseEntity> {
                new ExerciseEntity { Name = "Cycling", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Eliptical Trainer", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Rowing Machine", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Running", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Treadmill", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Walking", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false }
            };
        }

        private static List<ExerciseEntity> DefaultListOfChestExercises() {
            return new List<ExerciseEntity> {
                new ExerciseEntity { Name = "Bench Press", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Cable Crossovers", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Dumbbell Flies", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Dumbbell Press", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Incline Bench Press", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Incline Dumbbell Press", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false }
            };
        }

        private static List<ExerciseEntity> DefaultListOfLegsExercises() {
            return new List<ExerciseEntity> {
                new ExerciseEntity { Name = "Calf Raises", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Front Squat", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Leg Curls", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Leg Extensions", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Leg Press", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Lunges", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Seated Calf Raises", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Squat", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Straight Leg Deadlifts", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false }
            };
        }

        private static List<ExerciseEntity> DefaultListOfShouldersExercises() {
            return new List<ExerciseEntity> {
                new ExerciseEntity { Name = "Dumbbell Lateral Raises", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Military Press", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Shoulder Dumbbell Press", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Upright Rows", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false }
            };
        }

        private static List<ExerciseEntity> DefaultListOfTricepsExercises() {
            return new List<ExerciseEntity> {
                new ExerciseEntity { Name = "Assisted Dips", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Close Grip Bench Press", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Dips", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Pushdowns", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false },
                new ExerciseEntity { Name = "Triceps Extensions", Note = "", ExerciseType = ExerciseType.STRENGTH_WEIGHT_REPS, IsSingleBodyPartExercise = false }
            };
        }
    }
}
