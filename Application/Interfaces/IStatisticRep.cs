using Application.Reps;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IStatisticRep : IRep<Statistic>
    {
        Task<IEnumerable<Statistic>> GetWithAll();
        Task<Statistic> GetByIdWithAll(int id);
    }
}
