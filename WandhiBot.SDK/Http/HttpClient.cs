using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using Castle.DynamicProxy;

namespace WandhiBot.SDK.Http
{
    /// <summary>
    /// Http请求类
    /// </summary>
    public  class HttpClient
    {
        /// <summary>
        /// 根地址
        /// </summary>
        public string Root { set; get; }
        
        /// <summary>
        /// Cookie保持器
        /// </summary>
        private static readonly CookieContainer CookieContainer = new CookieContainer();
        /// <summary>
        /// 动态代理
        /// </summary>
        private static readonly ProxyGenerator ProxyGenerate = new ProxyGenerator();
        /// <summary>
        /// 拦截器
        /// </summary>
        private static  readonly  WandhiInterceptor WandhiInterceptor=new WandhiInterceptor();

        public HttpClient()
        {
            
        }

        /// <summary>
        /// 扫描并注入服务
        /// </summary>
        private void RegisterInterface()
        {
            //仅注册公开类  不考虑私有类的问题
            var types = Assembly.GetExecutingAssembly().GetExportedTypes().ToList();
            types = types.Where(c => c.GetCustomAttributes().Any()).ToList();
            var propertyInfos = new List<PropertyInfo>();
            //扫描类成员
            types.ForEach(t =>
            {
                    propertyInfos.AddRange(t.GetProperties());
            });
            //注册代理类、成员
            propertyInfos.ForEach(el =>
            {
                el.SetValue(null, ProxyGenerate.CreateInterfaceProxyWithoutTarget(el.PropertyType,WandhiInterceptor));
            });
        }
    }
}