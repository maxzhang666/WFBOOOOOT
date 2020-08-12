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
    }

    [WandhiControl("")]
    public interface V1
    {
        
    }
}