using Domain.Models;

namespace Domain.Reps
{
    public interface IStatisticRep : IRep<Statistic>
    {
        Task<IEnumerable<Statistic>> GetWithAll();
        Task<Statistic> GetByIdWithAll(int id);
    }
}
