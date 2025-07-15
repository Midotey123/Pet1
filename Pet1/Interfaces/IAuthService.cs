namespace Pet1.Interfaces
{
    public interface IAuthService
    {
        public Task<string> Register(string username, string password);
        public Task<string> Login(string username, string hashedPassword);
    }
}
