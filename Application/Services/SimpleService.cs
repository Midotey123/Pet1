using Application.Interfaces;
using Application.Reps;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class SimpleService : ISimpleService
    {
        private readonly IRep<Simple> rep;
        public SimpleService(IRep<Simple> rep)
        {
            this.rep = rep;
        }
        public async Task<IEnumerable<Simple>> GetWithName(string name)
        {
            var simples = await rep.Get();
            return simples.Where(s => s.Name.ToLower() == name.ToLower());
        }
    }
}
