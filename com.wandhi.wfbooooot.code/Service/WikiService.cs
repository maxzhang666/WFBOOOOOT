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

        const string SearchApi = "https://warframe.huijiwiki.com/api.php?action=query&format=json&formatversion=1&list=search&srsearch=";
        const string WikiLink = "https://warframe.huijiwiki.com/wiki/";
        const string ParseApi = "https://warframe.huijiwiki.com/api.php?action=parse&format=phpfm&page=";
        public WikiService()
        {
        }

        public WikiService(long GroupId) : base(GroupId)
        {
        }
        public WikiService(long GroupId, long MemberId, string Keyword) : base(GroupId, MemberId, Keyword) { }

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
            var SearchUrl = $"{SearchApi}{(Uri.EscapeUriString(keyword))}";

            var res = Http.Get<WikiSearch>(SearchUrl);
            if (res.code.IsNotEmpty())
            {
                msg.AppendLine("飞机WikiApi调用失败");
                msg.Append($"错误消息{res.info}");
                return msg.ToString();
            }

            if (res?.query.searchinfo.totalhits <= 0)
            {
                msg.AppendLine("啥也没查到哦");
            }
            var SearchRes = res?.query.search.Where(a => a.title == keyword).ToList();
            if (!SearchRes.Any() && res.query.search.IsNotEmpty())
            {
                msg.AppendLine("你是不是想找：");
                foreach (var item in res.query.search.Take(3))
                {
                    msg.AppendLine(item.title);
                }
            }
            else
            {
                msg.AppendLine("准备解析页面");
            }

            return msg.ToString();
        }
    }
}
