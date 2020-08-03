using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFBooooot.Model.Wiki
{
    public class WikiSearch
    {
        /// <summary>
        /// 
        /// </summary>
        public string batchcomplete { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public WikiSearchQuery query { get; set; }

        public WikiError error { set; get; }
    }
    public class WikiError
    {
        public string code { set; get; }

        public string info { set; get; }
    }
}
