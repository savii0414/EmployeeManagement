using EmployeeManagement.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.Repositories.EF;

namespace EmployeeManagement.Repositories.Implementations
{
    public class PublicHolidayRepository
        : Repository<PublicHoliday>, IPublicHolidayRepository
    {
        public PublicHolidayRepository(EmployeeManagementDbEntities context)
            : base(context)
        {
        }

        public List<DateTime> GetHolidayDates()
        {
            return _context.PublicHolidays
                           .Where(h => h.HolidayDate.HasValue)
                           .Select(h => h.HolidayDate.Value)
                           .ToList();
        }
    }
}
