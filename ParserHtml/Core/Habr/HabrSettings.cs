using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLParser.Core.Habr
{
    class HabrSettings : IParserSettings
    {
        public HabrSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }
        public string BaseURL { get; set; } = "https://habr.com/ru";

        public string Prefix { get; set; } = "page{CurrentId}";

        public int EndPoint { get; set; }

        
        public int StartPoint { get; set; }
    }
}
