using com.wandhi.wfbooooot.code.Extention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.wandhi.wfbooooot.code.Service
{
    public class WikiService : BaseService
    {
        const string SearchApi = "https://warframe.huijiwiki.com/api.php?action=query&format=json&formatversion=1&list=search&srsearch=1231";
        const string WikiLink = "https://warframe.huijiwiki.com/wiki/";
        public WikiService()
        {
        }

        public WikiService(long GroupId) : base(GroupId)
        {
        }

        public override string GetMsg()
        {
            return "你要搜什么玩意？";
        }

        public override string GetMsg(string KeyWord)
        {
            if (KeyWord.IsEmpty())
            {
                return GetMsg();
            }
            return "";
        }


    }
}
