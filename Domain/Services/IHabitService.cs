using Domain.Models;
using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IHabitService
    {
        Task<Result<Habit>> CreateHabit(string title, string? description, bool getUsedToIt, User user, Catalog? catalog);
        Task<Result> UpdateHabit(
            string title, string? description, bool getUsedToId, Catalog? catalog,
            int completedDays, int priorityNum
            );
        ///TODO: сделать доменный сервис для создания привычки статистики ее, для отметок ежедневных выполнения привычки
        ///и изменения. Сделать сервис для каталогов, создания, изменения, удаления, некоторые не удалять.

        //Task<Result<Mark>> CreateMark(...);
    }
}
