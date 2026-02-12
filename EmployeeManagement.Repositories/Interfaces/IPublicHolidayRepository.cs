using System;
using System.Collections.Generic;
using EmployeeManagement.Repositories.EF;

namespace EmployeeManagement.Repositories.Interfaces
{
    public interface IPublicHolidayRepository : IRepository<PublicHoliday>
    {
        List<DateTime> GetHolidayDates();
    }
}
