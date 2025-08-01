using Domain.Models;
using Domain.Reps;

namespace Domain.Reps
{
    public interface IHabitRep : IRep<Habit>
    {
        Task<IEnumerable<Habit>> GetWithAll();
        Task<Habit> GetByIdWithAll(int id);
    }
}
