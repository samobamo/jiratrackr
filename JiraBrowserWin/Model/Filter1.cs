using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraBrowserWin.JiraModel
{
    public class Filter1
    {
        public string self { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public owner owner { get; set; }
        public string jql { get; set; }
        public string viewUrl { get; set; }
        public string searchUrl { get; set; }
    }
}
