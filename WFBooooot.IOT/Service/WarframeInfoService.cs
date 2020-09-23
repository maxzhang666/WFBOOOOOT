using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using GHttpHelper;
using Newtonsoft.Json;
using OPQ.SDK.Model.Group;
using TRKS.WF.QQBot;
using WarframeAlertingPrime.SDK.Models.Core;
using WarframeAlertingPrime.SDK.Models.Enums;
using WarframeAlertingPrime.SDK.Models.Others;
using WFBooooot.IOT.Extension;
using WFBooooot.IOT.Service.Warframe;

namespace WFBooooot.IOT.Service
{
    public class WarframeInfoService : BaseService, IBaseService
    {
        private readonly WFTranslator _translator = new WFTranslator();

        public override string GetMsg()
        {
            throw new NotImplementedException();
        }

        public override string GetMsg(string KeyWord)
        {
            var res = "";
            if (KeyWord.StartsWith("查询"))
            {
                if (!KeyWord.Contains("裂隙") || !KeyWord.Contains("裂缝"))
                {
                    if (KeyWord.Length > 3)
                    {
                        Task.Factory.StartNew(() =>
                        {
                            var item = KeyWord.Substring(3).Format();
                            SendWMInfo(item);
                        });
                        res = "处理中，请稍后";
                    }
                    else
                    {
                        res = "你没输入要查询的物品";
                    }
                }
            }

            return res;
        }

        public new void send(string msg)
        {
            throw new System.NotImplementedException();
        }

        public new void send()
        {
            throw new System.NotImplementedException();
        }

        public WMInfoEx GetWMINfoEx(string searchword)
        {
            var header = new WebHeaderCollection();
            header.Add(HttpRequestHeader.ContentType, "x-www-form-urlencoded");

            var rr = Http.Post("https://api.richasy.cn/connect/token", new
            {
                client_id = AppData.AppConfig.WarframeConfig.ClientId,
                client_secret = AppData.AppConfig.WarframeConfig.ClientSecret,
                grant_type = "client_credentials"
            }, RequestType.Form, header);

            header.Clear();
            header.Add(HttpRequestHeader.Authorization,
                "Bearer ");
            var info = Http.Get<WMInfoEx>($"https://api.richasy.cn/wfa/basic/pc/wm/{searchword}", header);
            var client = new Client(AppData.AppConfig.WarframeConfig.ClientId, AppData.AppConfig.WarframeConfig.ClientSecret, new[] {"client_credentials"}, PlatformType.PC);
            var init = client.InitAsync().Result;
            var res = client.GetWarframeMarketOrdersAsync(new WarframeMarketOrderQueryOption {Code = searchword}).Result;
            return info;
        }

        public WMInfo GetWMInfo(string searchword)
        {
            return Http.Get<WMInfo>($"https://api.warframe.market/v1/items/{searchword}/orders?include=item");
        }

        public void SendWMInfo(string item)
        {
            var searchword = _translator.TranslateSearchWord(item);
            var formateditem = item;
            if (item == searchword)
            {
                searchword = _translator.TranslateSearchWord(item + "一套");
                formateditem = item + "一套";
                if (formateditem == searchword)
                {
                    searchword = _translator.TranslateSearchWord(item.Replace("p", "prime").Replace("总图", "蓝图"));
                    formateditem = item.Replace("p", "prime").Replace("总图", "蓝图");
                    if (formateditem == searchword)
                    {
                        searchword = _translator.TranslateSearchWord(item.Replace("p", "prime") + "一套");
                        formateditem = item.Replace("p", "prime") + "一套";
                        if (formateditem == searchword)
                        {
                            var sb = new StringBuilder();
                            var similarlist = _translator.GetSimilarItem(item.Format());
                            sb.AppendLine($"物品{item}不存在或格式错误.");
                            sb.AppendLine($"请问这下面有没有你要找的物品呢?:");
                            foreach (var similarresult in similarlist)
                            {
                                sb.AppendLine($"    {similarresult}");
                            }

                            AppData.OpqApi.SendMessage(new GroupMessage(GroupId, sb.ToString().Trim()));
                            return;
                        }
                    }
                }
            }

            var msg = "";
            if (false)
            {
                var infoEx = GetWMINfoEx(searchword);
                OrderWMInfoEx(infoEx);
                _translator.TranslateWMOrderEx(infoEx, searchword);
                msg = WFFormatter.ToString(infoEx);
            }
            else
            {
                var info = GetWMInfo(searchword);
                OrderWMInfo(info);
                _translator.TranslateWMOrder(info, searchword);
                msg = WFFormatter.ToString(info);
            }

            AppData.OpqApi.SendMessage(new GroupMessage(GroupId, msg));
        }

        public void OrderWMInfo(WMInfo info)
        {
            info.payload.orders = info.payload.orders
                .Where(order => order.order_type == "sell")
                .Where(order => order.user.status == "online" || order.user.status == "ingame")
                .OrderBy(order => order.platinum)
                .Take(3)
                .ToArray();
        }

        public void OrderWMInfoEx(WMInfoEx info)
        {
            info.orders = info.orders
                .Where(order => order.order_Type == "sell")
                .Where(order => order.status == "online" || order.status == "ingame")
                .OrderBy(order => order.platinum)
                .Take(3)
                .ToArray();
        }

        public WarframeInfoService(long GroupId) : base(GroupId)
        {
        }

        public WarframeInfoService(long GroupId, long MemberId, string Keyword) : base(GroupId, MemberId, Keyword)
        {
        }

        public WarframeInfoService(long GroupId, long MemberId, string Keyword, string Msg) : base(GroupId, MemberId, Keyword, Msg)
        {
        }
    }
}