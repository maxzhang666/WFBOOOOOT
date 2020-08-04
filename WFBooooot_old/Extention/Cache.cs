using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace WFBooooot.Extention
{
    public class Cache
    {
        /// <summary>
        /// 锁
        /// </summary>
        protected readonly object Lock = new object();
        private MemoryCache _MemoryCache;
        public Cache()
        {
            this._MemoryCache = new MemoryCache("WFBOOOOOT");
        }
        public void Clear()
        {
            _MemoryCache.Dispose();
            _MemoryCache = new MemoryCache("WFBOOOOOT");
        }

        public T Get<T>(string key)
        {
            T value = default;
            try
            {
                value = (T)_MemoryCache.Get(key);
            }
            catch (Exception e)
            {
                Log.Debug($"内存读取失败[{key}]:{e.Message}");
            }
            return value;
        }

        public T Get<T>(string key, out bool flag)
        {
            flag = true;
            T value = default;
            try
            {
                value = (T)_MemoryCache.Get(key);
            }
            catch (Exception e)
            {
                Log.Debug($"内存读取失败[{key}]:{e.Message}");
                flag = false;
            }
            return value;
        }

        public void Remove(string key)
        {
            _MemoryCache.Remove(key);
        }
        public T Get<T>(string key, Func<T> factory)
        {
            var value = Get<T>(key, out var flag);
            if (!flag)
            {
                value = factory.Invoke();
                lock (Lock)
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

            _MemoryCache.Set(key, value, DateTime.Now.Add(t));
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
