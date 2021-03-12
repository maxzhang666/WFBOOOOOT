using System;

namespace WFBooooot.IOT.Helper.Interface
{
    public interface ICacheService
    {
        public void Clear();

        public T Get<T>(string key);

        public bool TryGet<T>(string key, out T value);

        public void Remove(string key);

        public T Get<T>(string key, Func<T> factory);

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="default">默认值</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>(string key, T @default);


        /// <summary>
        /// 设置缓存(默认失效时间5分钟)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="time"></param>
        public void Set<T>(string key, T value, TimeSpan? time);

        /// <summary>
        /// 设置缓存(默认失效时间5分钟)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set<T>(string key, T value);
    }
}