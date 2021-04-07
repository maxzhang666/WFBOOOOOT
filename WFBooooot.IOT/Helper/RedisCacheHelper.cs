using System;
using CSRedis;
using IocManager;
using WFBooooot.IOT.Extension;
using WFBooooot.IOT.Helper.Interface;

namespace WFBooooot.IOT.Helper
{
    public class RedisCacheHelper : ICacheService, IIocSingletonService
    {
        private static CSRedisClient _Client;

        public RedisCacheHelper()
        {
            if (_Client == null)
            {
                _Client = new CSRedisClient($"{AppData.AppConfig.RedisConfig.Host}:{AppData.AppConfig.RedisConfig.Prot}{(AppData.AppConfig.RedisConfig.Password.IsNotEmpty() ? ($",password={AppData.AppConfig.RedisConfig.Password}") : "")},testcluster=false");
            }
        }

        public void Clear()
        {
        }

        public T Get<T>(string key)
        {
            return _Client.Get<T>(key);
        }

        public bool TryGet<T>(string key, out T value)
        {
            value = _Client.Get<T>(key);

            return value != null;
        }

        public void Remove(string key)
        {
            _Client.Del(key);
        }

        public T Get<T>(string key, Func<T> factory)
        {
            var value = Get<T>(key);
            if (value != null)
            {
                value = factory.Invoke();
            }

            return value;
        }

        public T Get<T>(string key, T @default)
        {
            return Get<T>(key) ?? @default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="time"></param>
        /// <typeparam name="T"></typeparam>
        public void Set<T>(string key, T value, TimeSpan? time)
        {
            if (time.HasValue)
            {
                _Client.Set(key, value, time.Value);
            }
            else
            {
                _Client.Set(key, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        public void Set<T>(string key, T value)
        {
            _Client.Set(key, value);
        }
    }
}