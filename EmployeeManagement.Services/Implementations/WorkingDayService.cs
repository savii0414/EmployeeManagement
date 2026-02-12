using EmployeeManagement.Repositories.Interfaces;
using EmployeeManagement.Services.Interfaces;
using System;

namespace EmployeeManagement.Services.Implementations
{
    public class WorkingDayService : IWorkingDayService
    {
        private readonly IPublicHolidayRepository _holidayRepo;
        private readonly ICacheService _cache;

        public WorkingDayService(
            IPublicHolidayRepository holidayRepo,
            ICacheService cache)
        {
            _holidayRepo = holidayRepo;
            _cache = cache;
        }

        public int Calculate(DateTime start, DateTime end)
        {
            if (start.DayOfWeek == DayOfWeek.Saturday ||
                start.DayOfWeek == DayOfWeek.Sunday)
                throw new Exception("Start date must be weekday");

            var holidays = _cache.CachedLong("HOLIDAYS",
                () => _holidayRepo.GetHolidayDates());

            int count = 0;

            for (var date = start.Date; date <= end.Date; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Saturday ||
                    date.DayOfWeek == DayOfWeek.Sunday)
                    continue;

                if (holidays.Contains(date))
                    continue;

                count++;
            }

            return count;
        }
    }
}
