using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraBrowserWin.JiraModel
{
    public class owner
    {
        public string self { get; set; }
        public string name { get; set; }
        public avatarUrls avatarUrls {get; set;}
        public string displayName { get; set; }
        public string active { get; set; }
    }
}
