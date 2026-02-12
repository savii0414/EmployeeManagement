using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IWorkingDayService
    {
        int Calculate(DateTime start, DateTime end);
    }
}
