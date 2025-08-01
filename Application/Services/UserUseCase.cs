using Application.DTO;
using Application.Interfaces;
using Domain.Models;
using FluentValidation;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    /// <summary>
    /// TODO:... .
    /// </summary>
    public class UserUseCase : IUserUseCase
    {
        private readonly IUserRep rep;
        private readonly IJwtProvideService jwtProvide;
        private readonly IPasswordHashService passwordHash;
        private readonly IValidator<UserRegisterPOST> registerValidator;
        private readonly IValidator<UserLoginPOST> loginValidator;
        public UserUseCase(IUserRep rep,
            IJwtProvideService jwtProvide,
            IPasswordHashService passwordHash,
            IValidator<UserRegisterPOST> registerValidator,
            IValidator<UserLoginPOST> loginValidator)
        {
            this.rep = rep;
            this.jwtProvide = jwtProvide;
            this.passwordHash = passwordHash;
            this.registerValidator = registerValidator;
            this.loginValidator = loginValidator;

        }
        public async Task<string> Login(UserLoginPOST user)
        {
            var vR = loginValidator.Validate(user);
            if (!vR.IsValid)
                return null;
            var eUser = await rep.GetByUsername(user.Username);
            if (!passwordHash.Check(user.Password, eUser.PasswordHash))
                return null;
            var token = jwtProvide.GenerateToken(eUser);
            return token;
        }
        public async Task<string> Register(UserRegisterPOST user)
        {
            var vR = registerValidator.Validate(user);
            if (!vR.IsValid)
                return null;
            var password = passwordHash.Hash(user.Password);
            var newUser = user.Adapt<User>();
            newUser.PasswordHash = password;
            if (!await rep.Add(newUser))
                return null;
            if (rep.Save() == 0)
                return null;
            var token = jwtProvide.GenerateToken(newUser);
            return token;
        }

    }
}
