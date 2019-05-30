using System.Collections.Generic;

namespace JiraBrowserWin.JiraModel
{
    public class Subtask
    {
        public string id { get; set; }
        public string key { get; set; }
        public string self { get; set; }
        public List<object> fields { get; set; }
    }
}