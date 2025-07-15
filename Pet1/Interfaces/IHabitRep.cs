using Pet1.Models;

namespace Pet1.Interfaces
{
    public interface IHabitRep : IRep<Habit>
    {
        Task<IEnumerable<Habit>> GetWithAll();
        Task<Habit> GetByIdWithAll(int id);
    }
}
