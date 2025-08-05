using Domain.Enums;
using Domain.Models;
using Domain.Reps;
using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class HabitService : IHabitService
    {
        private readonly IHabitRep habitRep;
        public HabitService(IHabitRep habitRep)
        {
            this.habitRep = habitRep;
        }
        public async Task<Result<Habit>> CreateHabit(string title,
            string? description,
            bool getUsedToIt,
            int totalDays,
            User user,
            Catalog? catalog,
            CancellationToken token = default)
        {
            var habitResult = Habit.Create(title,
                description,
                getUsedToIt,
                user.Id,
                catalog.Id);
            if (!habitResult.IsSuccess)
                return habitResult;
            var addHabitToUserResult = user.AddHabit(habitResult.Value);
            if (!addHabitToUserResult.IsSuccess)
                return Result<Habit>.Failure(addHabitToUserResult.Error);
            var addHabitToCatalogResult = catalog.AddHabit(habitResult.Value);
            if (!addHabitToCatalogResult.IsSuccess)
                return Result<Habit>.Failure(addHabitToCatalogResult.Error);
            var statisticResult = Statistic.Create(totalDays, (int)PriorityEnum.Default, habitResult.Value);
            if (!statisticResult.IsSuccess)
                return Result<Habit>.Failure(statisticResult.Error);
            var addStatisticToHabitResult = habitResult.Value.AddStatistic(statisticResult.Value);
            if (!addStatisticToHabitResult.IsSuccess)
                return Result<Habit>.Failure(addStatisticToHabitResult.Error);
            return habitResult;
        }
        public async Task<Result> UpdateHabit(
            string? title,
            string? description,
            bool? getUsedToId,
            Catalog? catalog,
            int? priorityNum,
            Habit habit,
            Statistic statistic,
            CancellationToken token = default)
        {
            if (title != null)
                if (!await habitRep.IsTitleUnique(title, token))
                    return Result.Failure("Habit's title is already taken by some of user's habits!");
            var habitResult = habit.Update(title, description, getUsedToId, catalog);
            if (!habitResult.IsSuccess)
                return habitResult;
            if (priorityNum == null)
                priorityNum = (int)statistic.Priority;
            var statisticResult = statistic.Update((int)priorityNum);
            if (!statisticResult.IsSuccess)
                return statisticResult;
            return Result.Success();
        }
    }
}
