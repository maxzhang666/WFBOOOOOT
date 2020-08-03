using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.wandhi.wfbooooot.code.Model.Wiki
{
    public class WikiSearchItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int ns { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pageid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int wordcount { get; set; }
        /// <summary>
        /// 详情说明
        /// </summary>
        public string snippet { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime timestamp { get; set; }
    }
}
