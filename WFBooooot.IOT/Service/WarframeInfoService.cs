using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using GHttpHelper;
using Newtonsoft.Json;
using OPQ.SDK;
using OPQ.SDK.Model.Group;
using TRKS.WF.QQBot;
using WarframeAlertingPrime.SDK.Models.Core;
using WarframeAlertingPrime.SDK.Models.Enums;
using WarframeAlertingPrime.SDK.Models.Others;
using WFBooooot.IOT.Extension;
using WFBooooot.IOT.Service.Warframe;
using Order = WarframeAlertingPrime.SDK.Models.User.Order;

namespace WFBooooot.IOT.Service
{
    public class WarframeInfoService : BaseService, IBaseService
    {
        private readonly WFTranslator _translator = new WFTranslator();

        private bool wfa => AppData.AppConfig.WarframeConfig.ClientId.IsNullOrEmpty() || AppData.AppConfig.WarframeConfig.ClientSecret.IsNullOrEmpty();

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
            else if (KeyWord.StartsWith("警报"))
            {
                res = "好嘞，让我查查看";
                Task.Factory.StartNew((() =>
                {
                    var alerts = GetAlert();
                    AppData.OpqApi.SendMessage(new GroupMessage(GroupId, alerts.Format()));
                }));
            }
            else if (KeyWord.StartsWith("紫卡"))
            {
                if (KeyWord.Length >= 3)
                {
                    if (KeyWord.Substring(2).StartsWith(" "))
                    {
                        var weapon = KeyWord.Substring(3).Format();
                        res = "好嘞，这就去查";
                        Task.Factory.StartNew((() =>
                        {
                            var list = GetRiveninfos(KeyWord);
                        }));
                    }
                }
                else
                {
                    res = "不告诉我查什么难道等我猜？";
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
            var client = new Client(AppData.AppConfig.WarframeConfig.ClientId, AppData.AppConfig.WarframeConfig.ClientSecret, new[] {"client_credentials"}, PlatformType.PC);
            var init = client.InitAsync().Result;

            var res = client.GetWarframeMarketOrdersAsync(new WarframeMarketOrderQueryOption {Code = searchword});

            var info = new WMInfoEx();
            return null;
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

        /// <summary>
        /// 警报
        /// </summary>
        public List<WFAlert> GetAlert()
        {
            try
            {
                var alerts = Http.Get<List<WFAlert>>("https://api.warframestat.us/pc/alerts");
                foreach (var alert in alerts)
                {
                    _translator.TranslateAlert(alert);
                    alert.Activation = alert.Activation.ToLocalTime();
                    alert.Expiry = alert.Expiry.ToLocalTime();
                }

                return alerts;
            }
            catch (HttpRequestException)
            {
            }
            catch (WebException)
            {
            }
            catch (Exception e)
            {
                AppData.Log.Error($"警报获取异常: \r\n{e}");
            }

            return new List<WFAlert>();
        }

        private void SendRivenInfo(string weapon)
        {
            var msg = "";
            if (wfa)
            {
                if (_translator.ContainsWeapon(weapon.Format()))
                {
                    var info = GetRiveninfos(weapon);
                    if (info.Count > 0)
                    {
                        msg = info.Format();
                    }
                    else
                    {
                        msg = $"抱歉, 目前紫卡市场没有任何出售: {weapon} 紫卡的用户.";
                    }

                    AppData.OpqApi.SendMessage(new GroupMessage(GroupId, msg));
                }
                else
                {
                    msg = $"武器{weapon}不存在, 请检查格式(请注意: 悦音prime)";
                }
            }
            else
            {
                msg = "本机器人没有API授权,请联系机器人管理员.";
            }

            AppData.OpqApi.SendMessage(new GroupMessage(GroupId, msg));
        }

        /// <summary>
        /// 紫卡查询
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Order> GetRiveninfos(string keyword)
        {
            if (wfa)
            {
                _client.InitAsync();
                var res = _client.QueryRivenOrdersAsync(new SearchRivenOrderOption() {Weapon = keyword}).Result;

                return res.Items;
            }
            else
            {
                return new List<Order>();
            }
        }

        private Client _client;

        private void ClientInit()
        {
            if (wfa)
            {
                _client = new Client(AppData.AppConfig.WarframeConfig.ClientId, AppData.AppConfig.WarframeConfig.ClientSecret, new[] {"client_credentials"});
            }
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