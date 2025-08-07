using Domain.Enums;
using Domain.Services;
using Domain.Validation;

namespace Domain.Models
{
    public class Statistic : IEntity
    {
        public int Id { get; set; }
        public int CompletedDays { get; set; }
        public int TotalDays { get; set; }
        public bool IsDone { get; set; }
        public PriorityEnum Priority { get; set; }
        public int HabitId { get; set; }
        public Habit Habit { get; set; }
        private Statistic(int totalDays, PriorityEnum priority, Habit habit)
        {
            TotalDays = totalDays;
            Priority = priority;
            Habit = habit;
        }
        internal static Result<Statistic> Create(int totalDays, int priorityNum, Habit habit)
        {
            if (totalDays <= 0)
                return Result<Statistic>.Failure("Total amount of days for habit can't be less or equals 0!");
            if (!Enum.IsDefined(typeof(PriorityEnum), priorityNum))
                return Result<Statistic>.Failure("Priority with that priority num not exists!");
            return Result<Statistic>.Success(new Statistic(totalDays, (PriorityEnum)priorityNum, habit));
        }
        internal Result Update(/*int completedDays,*/ int priorityNum)
        {
            //if (CompletedDays > completedDays)
            //    return Result.Failure("Can't reduce completed days count!");
            //else
            //    CompletedDays = completedDays;
            //if (TotalDays <= CompletedDays)
            //    IsDone = true;
            if (!Enum.IsDefined(typeof(PriorityEnum), priorityNum))
                return Result<Statistic>.Failure("Priority with that priority num not exists!");
            Priority = (PriorityEnum)priorityNum;
            return Result.Success();
        }
        /// <summary>
        /// TODO: вывести в сервис, делать проверку когда в последний раз выполнял, сделать раз в день отметку.
        /// </summary>
        /// <returns></returns>
        internal Result CompleteDay()
        {
            CompletedDays++;
            return Result.Success();
        }
    }
}
