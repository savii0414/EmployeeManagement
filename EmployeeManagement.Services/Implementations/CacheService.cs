using System;
using EmployeeManagement.Services.Delegates;
using EmployeeManagement.Services.Interfaces;
using System.Runtime.Caching;

namespace EmployeeManagement.Services.Implementations
{
    public class CacheService : ICacheService
    {
        private readonly ObjectCache _cache = MemoryCache.Default;

        public T Cached<T>(string key, CacheDelegate<T> method)
        {
            if (_cache.Contains(key))
                return (T)_cache[key];

            var result = method();
            _cache.Set(key, result, DateTimeOffset.Now.AddMinutes(5));
            return result;
        }

        public T CachedLong<T>(string key, CacheDelegate<T> method)
        {
            if (_cache.Contains(key))
                return (T)_cache[key];

            var result = method();
            _cache.Set(key, result, ObjectCache.InfiniteAbsoluteExpiration);
            return result;
        }
    }
}
