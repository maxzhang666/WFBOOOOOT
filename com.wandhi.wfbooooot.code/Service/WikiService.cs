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
            if (res == null || res.error != null)
            {
                msg.AppendLine("飞机WikiApi调用失败");
                if (res?.error != null)
                {
                    msg.Append($"错误消息：{res.error.info}");
                }
                return msg.ToString();
            }

            if (res?.query.searchinfo.totalhits <= 0)
            {
                msg.AppendLine("啥也没查到哦");
            }
            else
            {
                var SearchRes = res?.query.search.Where(a => a.title == keyword).ToList();
                if (!SearchRes.Any())
                {
                    if (res.query.search.IsNotEmpty())
                    {
                        msg.AppendLine("你是不是想找：");
                        msg.AppendLine(string.Join("\r\n", res.query.search.Take(3)));  
                    }
                }
                else
                {
                    var dom = new HtmlAgilityPack.HtmlDocument();
                    dom.LoadHtml(res.query.search[0].snippet);
                    msg.AppendLine($"简介:{dom.DocumentNode.InnerText}\r\n");
                    msg.Append($"详情链接：{WikiLink}{Uri.EscapeDataString(res.query.search[0].title)}");
                }
            }

            return msg.ToString();
        }
    }
}
