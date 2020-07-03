using com.wandhi.wfbooooot.code.Extention;
using com.wandhi.wfbooooot.code.Model.Wiki;
using GHttpHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.wandhi.wfbooooot.code.Service
{
    public class WikiService : BaseService
    {
        const string Key = "/Wiki";

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
            return WikiSearch(KeyWord);
        }

        string WikiSearch(string keyword)
        {
            var msg = new StringBuilder();
            var res = Http.Get<WikiSearch>($"{SearchApi}{keyword}");


            if (res?.query.searchinfo.totalhits <= 0)
            {
                msg.Append("啥也没查到哦");
            }
            var SearchRes = res?.query.search.Where(a => a.title == keyword).ToList();
            if (SearchRes.Any())
            {
                msg.Append("你是不是想找：");
                foreach (var item in SearchRes)
                {
                    msg.AppendLine(item.title);
                }
            }

            return msg.ToString();
        }
    }
}
