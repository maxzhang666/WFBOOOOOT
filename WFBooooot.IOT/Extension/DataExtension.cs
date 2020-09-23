using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Castle.Core.Internal;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Humanizer;
using Humanizer.Localisation;
using TRKS.WF.QQBot;
using WFBooooot.IOT.Service.Warframe;

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
    }
}