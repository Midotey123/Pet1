using Pet1.Interfaces;
using Pet1.Models;

namespace Pet1.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRep<User> userRep;
        private readonly IPasswordHashService passwordHashService;
        public AuthService(IRep<User> userRep)
        {
            this.userRep = userRep;
        }
        public Task<string> Register(string username, string password)
        {
            throw new NotImplementedException();
        }
        public Task<string> Login(string username, string hashedPassword)
        {
            throw new NotImplementedException();
        }

    }
}
