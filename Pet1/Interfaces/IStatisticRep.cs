using Pet1.Models;

namespace Pet1.Interfaces
{
    public interface IStatisticRep : IRep<Statistic>
    {
        Task<IEnumerable<Statistic>> GetWithAll();
        Task<Statistic> GetByIdWithAll(int id);
    }
}
