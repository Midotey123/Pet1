using Domain.Models;
using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface ICatalogService
    {
        Task<Result<Catalog>> CreateCatalog(string title, User creator, CancellationToken cToken = default);
    }
}
