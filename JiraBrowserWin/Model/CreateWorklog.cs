using System.Collections.Generic;
using JetBrains.Annotations;

namespace JiraBrowserWin.JiraModel
{
    /// <summary>
    /// Class used to create a new issue in the Jira API.
    /// 
    /// Contains only a dictionary because that allows us to (easily) add any custom fields
    /// without having trouble with serialization and deserialization. That's why Issue is not used
    /// for creating issues.
    /// </summary>
    public class CreateWorklog
    {
        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        public readonly Dictionary<string, object> fields;

        public CreateWorklog(            
            string comment,
            string started,
            string timeSpent)
        {
            fields = new Dictionary<string, object>
            {
                {"timeSpent", timeSpent },
                {"started", started },
                {"comment", comment }
            };
        }

        public void AddField(string fieldName, object value)
        {
            fields.Add(fieldName, value);
        }
    }
}
