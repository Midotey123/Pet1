using Domain.Models;
using Domain.Reps;

namespace Domain.Reps
{
    public interface IHabitRep : IRep<Habit>
    {
        Task<IEnumerable<Habit>> GetWithAll(CancellationToken cToken = default);
        Task<Habit> GetByIdWithAll(int id, CancellationToken cToken = default);
    }
}
