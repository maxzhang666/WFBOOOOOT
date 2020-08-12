using System;
using WandhiBot.SDK.Enum;

namespace WandhiBot.SDK.Http.Attributes
{
    /// <summary>
    /// 特性标记-动作-函数
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class WandhiAction:Attribute
    {
        /// <summary>
        /// 请求路径
        /// </summary>
        public string Path { get; private set; }
        /// <summary>
        /// 请求方式
        /// </summary>
        public HttpMethod Method { get; private set;}
        /// <summary>
        /// 请求类型
        /// </summary>
        public HttpContentType ContentType { get; private set;}
        /// <summary>
        /// 超时时间(秒)
        /// </summary>
        public int TimeOut { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">请求路径</param>
        /// <param name="httpMethod">请求方式</param>
        /// <param name="httpContentType">请求类型</param>
        /// <param name="timeOut">超时时间(秒)</param>
        public WandhiAction(string path,HttpMethod httpMethod,HttpContentType httpContentType,int timeOut=600)
        {
            Path = path;
            Method = httpMethod;
            ContentType = httpContentType;
            TimeOut = timeOut;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">请求路径</param>
        /// <param name="httpMethod">请求方式</param>
        /// <param name="httpContentType">请求类型</param>
        public WandhiAction(string path,HttpMethod httpMethod,HttpContentType httpContentType)
        {
            Path = path;
            Method = httpMethod;
            ContentType = httpContentType;
        }       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">请求路径</param>
        /// <param name="httpMethod">请求方式</param>
        public WandhiAction(string path,HttpMethod httpMethod)
        {
            Path = path;
            Method = httpMethod;
        }    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">请求路径</param>
        /// <param name="httpContentType">请求类型</param>
        public WandhiAction(string path,HttpContentType httpContentType)
        {
            Path = path;
            ContentType = httpContentType;
        }   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">请求路径</param>
        public WandhiAction(string path)
        {
            Path = path;
        }
    }
}