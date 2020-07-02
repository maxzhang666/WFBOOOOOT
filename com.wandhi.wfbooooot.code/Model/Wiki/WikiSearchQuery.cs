using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.wandhi.wfbooooot.code.Model.Wiki
{
    public class WikiSearchQuery
    {
        /// <summary>
        /// 
        /// </summary>
        public WikiSearchInfo searchinfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<WikiSearchItem> search { get; set; }
    }
}
