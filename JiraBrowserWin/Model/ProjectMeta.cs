using System.Collections.Generic;

namespace JiraBrowserWin.JiraModel
{
    public class ProjectMeta
    {
        public string self { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public List<IssueType> issuetypes { get; set; }
    }
}