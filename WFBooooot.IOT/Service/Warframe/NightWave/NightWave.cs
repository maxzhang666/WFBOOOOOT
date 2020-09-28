using System;
using System.Collections.Generic;

namespace WFBooooot.IOT.Service.Warframe.NightWave
{
    public class NightWave
    {
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? activation { get; set; }

        /// <summary>
        /// 持续时间
        /// </summary>
        public string startString { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? expiry { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string active { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int season { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string tag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int phase { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<string> possibleChallenges { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ActiveChallengesItem> activeChallenges { get; set; }
    }
}