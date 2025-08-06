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
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRep rep;
        public CatalogService(ICatalogRep rep)
        {
            this.rep = rep;
        }
        public async Task<Result<Catalog>> CreateCatalog(string title, User creator, CancellationToken cToken)
        {
            var catalogResult = Catalog.Create()
        }
    }
}
