using EmployeeManagement.Repositories.Interfaces;
using EmployeeManagement.Repositories.EF;

namespace EmployeeManagement.Repositories.Implementations
{
    public class EmployeeRepository
        : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeManagementDbEntities context)
            : base(context)
        {
        }
    }
}
