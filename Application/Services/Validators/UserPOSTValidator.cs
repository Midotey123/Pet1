using Application.DTO;
using Application.Interfaces;
using Application.Reps;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Validators
{
    public class UserRegisterPOSTValidator : AbstractValidator<UserRegisterPOST>
    {
        public UserRegisterPOSTValidator(IUserRep rep)
        {
            RuleFor(u => u.Username)
                .NotNull().WithMessage("Username is null")
                .NotEmpty().WithMessage("Username is empty")
                .Must(u =>
                {
                    if (!rep.IsUniqueUsername(u).Result)
                        return false;
                    return true;
                }).WithMessage("User is exists");
            RuleFor(u => u.Password)
                .NotNull().WithMessage("Password is null")
                .NotEmpty().WithMessage("Password is empty");
        }
    }
    public class UserLoginPOSTValidator : AbstractValidator<UserLoginPOST>
    {
        public UserLoginPOSTValidator(IUserRep rep)
        {
            RuleFor(u => u.Username)
                .NotNull().WithMessage("Username is null")
                .NotEmpty().WithMessage("Username is empty")
                .Must(u =>
                {
                    if (rep.IsUniqueUsername(u).Result)
                        return false;
                    return true;
                }).WithMessage("User not exists");
            RuleFor(u => u.Password)
                .NotNull().WithMessage("Password is null")
                .NotEmpty().WithMessage("Password is empty");
        }
    }
}
