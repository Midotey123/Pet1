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
        Task<Result<Habit>> CreateHabit(
            string title,
            string? description,
            bool getUsedToIt,
            User user,
            Catalog? catalog,
            CancellationToken token = default);
        Task<Result> UpdateHabit(
            string? title,
            string? description,
            bool? getUsedToId,
            Catalog? catalog,
            int? completedDays,
            int? priorityNum,
            Habit habit,
            Statistic statistic,
            CancellationToken token = default);

        ///TODO: сделат сервис по управлению состоянием привычек.

        //Task<Result<Mark>> CreateMark(...);  ///TODO: в доменный сервис отвечающий за заметки вынести.
    }
    ///TODO: Сделать сервис для каталогов, создания, изменения, удаления, некоторые не удалять.
}
