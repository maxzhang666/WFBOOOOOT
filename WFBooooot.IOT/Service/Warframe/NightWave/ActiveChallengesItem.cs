using System;

namespace WFBooooot.IOT.Service.Warframe.NightWave
{
    public class ActiveChallengesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime activation { get; set; }
        /// <summary>
        /// 持续时间
        /// </summary>
        public string startString { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? expiry { get; set; }
        /// <summary>
        /// 是否激活
        /// </summary>
        public bool active { get; set; }
        /// <summary>
        /// 是否每日
        /// </summary>
        public bool isDaily { get; set; }
        /// <summary>
        /// 是否精英任务
        /// </summary>
        public bool isElite { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 声望奖励
        /// </summary>
        public int reputation { get; set; }
    }
}