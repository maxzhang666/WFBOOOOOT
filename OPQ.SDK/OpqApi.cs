using IocManager;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OPQ.SDK.Model;

namespace OPQ.SDK
{
    public class OpqApi : IIocSingletonService
    {
        private string Root { set; get; }
        private long CurrentQQ { set; get; }
        private string Version;
        private int TimeOut;

        #region 配置信息

        private JsonSerializerSettings _jsonFormat = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        #endregion

        #region Api地址

        /// <summary>
        /// 通用消息发送
        /// </summary>
        private string SendMsg => $"{Root}/{Version}/LuaApiCaller?qq={CurrentQQ}&funcname=SendMsg&timeout={TimeOut}";

        #endregion

        /// <summary>
        /// 初始化Api
        /// </summary>
        /// <param name="root">
        /// 机器人服务根地址
        /// ep:http://127.0.0.1:8888
        /// </param>
        /// <param name="currentQQ">
        /// 机器人QQ
        /// </param>
        /// <param name="version">
        /// 机器人Api版本号，默认V1
        /// </param>
        /// <param name="timeout">
        /// 超时时间
        /// </param>
        public OpqApi(string root, long currentQQ, string version = "v1", int timeout = 10)
        {
            this.Root = root;
            this.CurrentQQ = currentQQ;
            Version = version;
            TimeOut = timeout;
        }

        #region 群消息发送

        /// <summary>
        /// 发送群文字消息
        /// </summary>
        public void SendMessage(Message message)
        {
            GHttpHelper.Http.PostJson(SendMsg, JsonConvert.SerializeObject(message, _jsonFormat));
        }

        #endregion
    }
}