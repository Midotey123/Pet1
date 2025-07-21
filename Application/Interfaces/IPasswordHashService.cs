namespace Application.Interfaces
{
    public interface IPasswordHashService
    {
        string Hash(string password);
        bool Check(string password, string hashedPassword);
    }
}
