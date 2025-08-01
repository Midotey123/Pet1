using Domain.Models;
using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IUserService
    {
        Task<Result<User>> Create(string username, string passwordHash);
        Task<Result<Catalog>> CreateCatalog(string username, User creator);
    }
}
