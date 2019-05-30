using System.IO;

namespace JiraBrowserWin
{
    public static class ResourceUrls
    {
        private const string BaseUrl = "/rest/api/latest/";

        public static string IssueByKey(string issueKey)
        {
            return Url($"issue/{issueKey}");
        }

        public static string Issue()
        {
            return Url("issue");
        }

        public static string Search()
        {
            return Url("search");
        }

        public static string Priority()
        {
            return Url("priority");
        }

        public static string CreateMeta()
        {
            return Url("issue/createmeta");
        }

        public static string Status()
        {
            return Url("status");
        }

        public static string Versions(string projectKey)
        {
            return Url($"project/{projectKey}/versions");
        }

        public static string Version()
        {
            return Url("version");
        }

        public static string UpdateVersion(string versionId)
        {
            return Url($"version/{versionId}");
        }

        public static string ApplicationProperties()
        {
            return Url("application-properties");
        }

        public static string AttachmentById(string attachmentId)
        {
            return Url($"attachment/{attachmentId}");
        }

        public static string Project()
        {
            return Url("project");
        }

        public static string FavouriteFilters()
        {
            return Url("filter/favourite");
        }

        public static string Filter()
        {
            return Url("filter");
        }
        public static string Worklog(string issueKey)
        {
            return Url($"issue/{issueKey}/worklog?adjustEstimate=auto");
        }
        public static string UpdateWorklog(string issueKey, string worklogId)
        {
            return Url($"issue/{issueKey}/worklog/{worklogId}?adjustEstimate=auto");
        }
        private static string Url(string key)
        {
            return Path.Combine(BaseUrl, key);
        }

        public static string JqlSearchByFilterId(string filterId)
        {
            return "filter = " + filterId;
        }

        public static string GetIssuesByAssignee(string userName)
        {
            return "assignee = " + userName + " AND resolution = Unresolved";
        }
    }
}