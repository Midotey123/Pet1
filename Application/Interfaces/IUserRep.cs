using Application.Reps;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserRep : IRep<User>
    {
        Task<bool> IsUniqueUsername(string username);
        Task<User> GetByUsername(string username);
    }
}
