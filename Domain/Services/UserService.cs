using Domain.Enums;
using Domain.Models;
using Domain.Reps;
using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRep rep;
        private readonly ICatalogRep catalogRep;
        public UserService(IUserRep rep,
            ICatalogRep catalogRep)
        {
            this.rep = rep;
            this.catalogRep = catalogRep;

        }
        public async Task<Result<User>> Create(string username, string passwordHash)
        {
            if (!await rep.IsUniqueUsername(username))
                return Result<User>.Failure("Username is taken!");
            var userResult = User.Create(username, passwordHash);
            if (!userResult.IsSuccess)
                return userResult;
            var fCR = Catalog.Create("Favorite", userResult.Value, (int)CatalogTypeEnum.Favorite);
            if (!fCR.IsSuccess)
                return Result<User>.Failure(fCR.Error);
            var hCR = Catalog.Create("Hidden", userResult.Value, (int)CatalogTypeEnum.Hidden);
            if (!hCR.IsSuccess)
                return Result<User>.Failure(hCR.Error);
            var cCR = Catalog.Create("Completed", userResult.Value, (int)CatalogTypeEnum.Completed);
            if (!cCR.IsSuccess)
                return Result<User>.Failure(cCR.Error);
            var uFCR = userResult.Value.AddCatalog(fCR.Value);
            if (!uFCR.IsSuccess)
                return Result<User>.Failure(uFCR.Error);
            var uHCR = userResult.Value.AddCatalog(hCR.Value);
            if (!uHCR.IsSuccess)
                return Result<User>.Failure(uHCR.Error);
            var uCCR = userResult.Value.AddCatalog(cCR.Value);
            if (!uCCR.IsSuccess)
                return Result<User>.Failure(uCCR.Error);
            return userResult;
        }
        public async Task<Result<Catalog>> CreateCatalog(string title, User creator)
        {
            if(await catalogRep.IsTitleUniqueForUser(title, creator))

        }
    }
}
