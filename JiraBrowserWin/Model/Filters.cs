using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraBrowserWin.JiraModel
{
    public class Filters
    {
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public List<Filter> filters { get; set; }
    }
}
