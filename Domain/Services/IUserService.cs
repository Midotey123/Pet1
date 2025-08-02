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
        Task<Result<User>> Create(string username, string passwordHash, CancellationToken cToken = default);
        Task<Result<Catalog>> CreateCatalog(string title, User creator, CancellationToken cToken = default);
        ///TODO: вынести в отдельный сервис катологи.
    }
}
