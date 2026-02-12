using EmployeeManagement.Repositories.Interfaces;
using EmployeeManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using EmployeeManagement.Repositories.EF;

namespace EmployeeManagement.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        private readonly ICacheService _cache;

        public EmployeeService(IEmployeeRepository repo, ICacheService cache)
        {
            _repo = repo;
            _cache = cache;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _repo.GetAll();
        }

        public Employee GetById(int id)
        {
            return _repo.GetById(id);
        }

        public void Create(Employee employee)
        {
            employee.CreatedDate = DateTime.Now;
            employee.CreatedBy = GetUserName();

            _repo.Add(employee);
            _repo.Save();

            _cache.Remove("EMP_ALL");
        }

        public void Update(Employee employee)
        {
            _repo.Update(employee);
            _repo.Save();

            _cache.Remove("EMP_ALL");
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();

            _cache.Remove("EMP_ALL");
        }

        private string GetUserName()
        {
            return "SystemUser";
        }
    }
}
