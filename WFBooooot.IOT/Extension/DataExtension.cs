using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Castle.Core.Internal;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Humanizer;
using Humanizer.Localisation;
using TRKS.WF.QQBot;
using WarframeAlertingPrime.SDK.Models.User;
using WFBooooot.IOT.Service.Warframe;
using Order = WarframeAlertingPrime.SDK.Models.User.Order;

namespace WFBooooot.IOT.Extension
{
    public static class DataExtension
    {
        /// <summary>
        /// 警报
        /// </summary>
        /// <param name="wfAlert"></param>
        /// <returns></returns>
        public static string Format(this WFAlert wfAlert)
        {
            var mission = wfAlert.Mission;
            var reward = mission.Reward;
            var time = (wfAlert.Expiry - DateTime.Now).Humanize(int.MaxValue, CultureInfo.GetCultureInfo("zh-CN"), TimeUnit.Day, TimeUnit.Second, " ");

            return $"[{mission.Node}] 等级{mission.MinEnemyLevel}~{mission.MaxEnemyLevel}:\r\n" +
                   $"- 类型:     {mission.Type} - {mission.Faction}\r\n" +
                   $"- 奖励:     {reward}\r\n" +
                   //$"-过期时间: {alert.Expiry}({time} 后)" +
                   $"- 过期时间: {time} 后";
        }

        /// <summary>
        /// 警报集
        /// </summary>
        /// <param name="wfAlerts"></param>
        /// <returns></returns>
        public static string Format(this List<WFAlert> wfAlerts)
        {
            if (wfAlerts.IsNullOrEmpty())
            {
                return "风平浪静，没有警报";
            }

            var sb = new StringBuilder();

            sb.AppendLine("查询到当前时间的警报如下：");
            foreach (var alert in wfAlerts)
            {
                sb.AppendLine(alert.Format());
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static string ToString(this Reward reward)
        {
            var rewards = new List<string>();
            if (reward.Credits > 0)
            {
                rewards.Add($"{reward.Credits} cr");
            }

            foreach (var item in reward.Items)
            {
                rewards.Add(item);
            }

            foreach (var item in reward.CountedItems)
            {
                rewards.Add($"{item.Count}x{item.Type}");
            }

            return string.Join(" + ", rewards);
        }


        #region Api

        /// <summary>
        /// 紫卡
        /// </summary>
        /// <param name="list"></param>
        /// <param name="weapon"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string Format(this List<Order> list, string weapon, int num = 5)
        {
            var sb = new StringBuilder();
            list = list.OrderBy(a => a.platinum).Take(num).ToList();
            sb.AppendLine($"下面是 {weapon} 紫卡的 {list.Count} 条卖家信息.");
            foreach (var info in list)
            {
                sb.AppendLine($"[{info.account.gameName}]  ");
                switch (info.account.status)
                {
                    case UserStatus.InGame:
                        sb.AppendLine("游戏中");
                        break;
                    case UserStatus.Online:
                        sb.AppendLine("在线");
                        break;
                    case UserStatus.Offline:
                        sb.AppendLine("离线");
                        break;
                    case UserStatus.Suspend:
                        break;
                }

                sb.AppendLine($"- 价格:{info.platinum}白鸡");
                sb.AppendLine($"- 属性:\r\n{info.properties.Format()}");
            }

            return sb.ToString().Trim();
        }

        /// <summary>
        /// 紫卡属性
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        public static string Format(this List<Property> properties)
        {
            var sb = new StringBuilder();
            foreach (var item in properties)
            {
                sb.AppendLine($"      {AppData.WandhiIocManager.Resolve<WFTranslator>().TranslateWordEnToCn(item.name)}【{item.value}%】");
            }

            return sb.ToString();
        }

        #endregion
    }
}