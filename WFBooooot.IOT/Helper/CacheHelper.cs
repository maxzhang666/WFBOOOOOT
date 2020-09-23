using System;
using IocManager;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace WFBooooot.IOT.Helper
{
    /// <summary>
    /// 内存缓存
    /// </summary>
    public class CacheHelper : IIocSingletonService
    {
        /// <summary>
        /// 锁
        /// </summary>
        private readonly object _lock = new object();

        private MemoryCache _memoryCache;
        private Log _log;

        public CacheHelper(Log log)
        {
            _log = log;
            this._memoryCache = new MemoryCache(Options.Create(new MemoryCacheOptions()));
        }

        public void Clear()
        {
            _memoryCache.Dispose();
            _memoryCache = new MemoryCache(Options.Create(new MemoryCacheOptions()));
        }

        public T Get<T>(string key)
        {
            T value = default;
            _memoryCache.TryGetValue(key, out value);
            return value;
        }

        public T Get<T>(string key, out bool flag)
        {
            flag = true;
            T value = default;
            flag = _memoryCache.TryGetValue(key, out value);
            return value;
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public T Get<T>(string key, Func<T> factory)
        {
            var value = Get<T>(key, out var flag);
            if (!flag)
            {
                value = factory.Invoke();
                lock (_lock)
                {
                    Set(key, value);
                }
            }

            return value;
        }


        /// <summary>
        /// 设置缓存(默认失效时间5分钟)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="time"></param>
        public void Set<T>(string key, T value, TimeSpan? time)
        {
            TimeSpan t = time.HasValue ? time.Value : TimeSpan.FromMinutes(5);

            _memoryCache.Set(key, value, DateTime.Now.Add(t));
        }

        /// <summary>
        /// 设置缓存(默认失效时间5分钟)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set<T>(string key, T value)
        {
            Set<T>(key, value, null);
        }
    }
}