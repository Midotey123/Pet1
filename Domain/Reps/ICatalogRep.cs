using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Reps
{
    public interface ICatalogRep : IRep<Catalog>
    {
        Task<bool> IsTitleUniqueForUser(string title, User user, CancellationToken cToken = default);
    }
}
