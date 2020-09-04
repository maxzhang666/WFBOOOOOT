using System.Collections.Generic;

namespace WFBooooot.IOT.Model.Lsp
{
    public class DataItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int pid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int p { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int uid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string author { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string r18 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int width { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int height { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List <string > tags { get; set; }
    }
 
    public class Lsp
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int quota { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int quota_min_ttl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List <DataItem > data { get; set; }
    }
    
    
}