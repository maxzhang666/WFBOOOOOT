using WandhiBot.SDK.Enum;
using WandhiBot.SDK.Http;
using WandhiBot.SDK.Http.Attributes;

namespace WFBooooot.Test.ProxyTest
{
    
    public class TestClient:IWandhiModule
    {
        private readonly string _root;
        public TestClient(string root)
        {
            this._root = root;
        }
        public string GetRoot()
        {
            return _root;
        }

        public static V1 v1 { set; get; }
    }

    [WandhiControl("v1")]
    public interface V1
    {
        /// <summary>
        /// 请求测试
        /// </summary>
        /// <returns></returns>
        [WandhiAction("666",HttpMethod.Get)]
        string getTest();
    }
}