using AutoMapper;
using MVC_CS_API.Data.Entities;
using MVC_CS_API.Data.Repositories;
using MVC_CS_API.DTO;
using System.Security.Cryptography;
using System.Text;

namespace MVC_CS_API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepostiory;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthService(IUserRepository userRepostiory, ITokenService tokenService, IMapper mapper)
        {
            this._userRepostiory = userRepostiory;
            this._tokenService = tokenService;
            this._mapper = mapper;
        }

        public Dictionary<string, string> Login(AuthUserDTO authUser)
        {
            authUser.Username = authUser.Username.ToLower();
            var current = _userRepostiory.GetUser(authUser.Username);

            if (current == null)
                throw new UnauthorizedAccessException();

            using (var hmac = new HMACSHA512(current.PasswordSalt))
            {
                var hashedPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(authUser.Password));
                for (int i = 0; i < hashedPass.Length; i++)
                {
                    if (hashedPass[i] != current.PasswordHash[i])
                        throw new UnauthorizedAccessException();
                }
            }

            var token = _tokenService.CreateToken(authUser.Username);

            var result = new Dictionary<string, string>();
            result["username"] = authUser.Username;
            result["token"] = token;
            
            return result;
        }

        public Dictionary<string, string> Register(RegisterUserDTO registerUser)
        {
            registerUser.Username = registerUser.Username.ToLower();
            

            if (_userRepostiory.GetUser(registerUser.Username) != null)
            {
                throw new Exception($"User {registerUser.Username} has exist!");
            }

            // Use hmac with hmac.Key to get exist sha512 hmac.
            using var hmac = new HMACSHA512();
            User user = new User()
            {
                Username = registerUser.Username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerUser.Password)),
                PasswordSalt = hmac.Key
            };

            _userRepostiory.InsertUser(user);
            _userRepostiory.IsSaveChanges();

            var token = _tokenService.CreateToken(registerUser.Username);

            var result = new Dictionary<string, string>();
            result["username"] = registerUser.Username;
            result["token"] = token;

            return result;
        }
    }
}
