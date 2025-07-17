using Application.Reps;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IHabitRep : IRep<Habit>
    {
        Task<IEnumerable<Habit>> GetWithAll();
        Task<Habit> GetByIdWithAll(int id);
    }
}
