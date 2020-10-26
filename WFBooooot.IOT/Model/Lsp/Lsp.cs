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
    
    //如果好用，请收藏地址，帮忙分享。
    public class LspInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int sp_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sp_qq { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int sp_cd_count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string created_at { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string updated_at { get; set; }
    }
 
    public class LspData
    {
        /// <summary>
        /// 
        /// </summary>
        public LspInfo info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double cd_count { get; set; }
    }
 
    public class LspAnalyze
    {
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 哎哟不错哦
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string cache { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public LspData data { get; set; }
    }
    
}