﻿namespace Application.Interfaces
{
    public interface IPasswordHashService
    {
        Task<string> Hash(string password);
        Task<bool> Check(string password, string hashedPassword);
    }
}
