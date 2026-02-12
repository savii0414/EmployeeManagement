using EmployeeManagement.Services.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Interfaces
{
    public interface ICacheService
    {
        T Cached<T>(string key, CacheDelegate<T> method);
        T CachedLong<T>(string key, CacheDelegate<T> method);

        void Remove(string key);
    }
}
