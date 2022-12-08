using MVC_CS_API.DTO;

namespace MVC_CS_API.Services
{
    public interface IAuthService
    {
        public Dictionary<string, string> Login(AuthUserDTO authUser);
        
        public Dictionary<string, string> Register(RegisterUserDTO registerUser);
    }
}
