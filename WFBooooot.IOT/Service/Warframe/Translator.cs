using System.Collections.Generic;
using System.Linq;
using WFBooooot.IOT.Extension;

namespace WFBooooot.IOT.Service.Warframe
{
    public class Translator
    {
        private readonly Dictionary<string, string> dic;

        public Translator()
        {
            dic = new Dictionary<string, string>();
        }

        public Translator(Dictionary<string, string> dictionary)
        {
            dic = dictionary;
        }

        public string CnToEn(string source)
        {
            return dic.ContainsValue(source) ? dic.FirstOrDefault(a => a.Value == source.Format()).Key : source;
        }

        public string Translate(string source)
        {
            return dic.ContainsKey(source) ? dic[source] : source;
        }

        public void AddEntry(string source, string target)
        {
            dic[source] = target;
        }
    }
}