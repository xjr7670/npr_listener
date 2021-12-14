using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winformTestAll
{
    class NewsInfo
    {
        public string Title;
        public string Url;
        public string Mp3link;

        public override string ToString()
        {
            string ret = $"Title: {this.Title}\n";
            ret += $"URL: {this.Url}\n";
            ret += $"Mp3link: {this.Mp3link}\n";

            return ret;
        }
    }
}
