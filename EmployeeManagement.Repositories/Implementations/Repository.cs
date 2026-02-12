using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EmployeeManagement.Repositories.Interfaces;
using EmployeeManagement.Repositories.EF;

namespace EmployeeManagement.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly EmployeeManagementDbEntities _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(EmployeeManagementDbEntities context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
                _dbSet.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
