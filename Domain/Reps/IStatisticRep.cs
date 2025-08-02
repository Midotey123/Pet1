using Domain.Models;

namespace Domain.Reps
{
    public interface IStatisticRep : IRep<Statistic>
    {
        Task<IEnumerable<Statistic>> GetWithAll(CancellationToken cToken = default);
        Task<Statistic> GetByIdWithAll(int id, CancellationToken cToken = default);
    }
}
