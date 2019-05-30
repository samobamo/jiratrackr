using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms.Calendar;
using System.Net;
using System.IO;
using System.Drawing;
using System.Security;
using JiraBrowserWin.JiraModel;

namespace JiraBrowserWin
{
    class CommonFunctions
    {
        static SQLiteConnection sqlConn;

        
        public static Issues commonIssuesRest;
        //public static JiraService.RemoteFilter[] commonFilter;
        public static List<Filter1> commonFilter;
        public static string userName;
        public static DateTime currentStartDate;
        public static DateTime currentEndDate;
        public static JiraClient client;
        private static void SetConnection()
        {
            string databaseLocation = Properties.Settings.Default.DBLocation;
            try
            {
                sqlConn = new SQLiteConnection("Data Source=" + databaseLocation + ";Version=3");
                sqlConn.Open();
            }
            catch (Exception e)
            {

            }
        }
        private static void CloseConnection()
        {
            sqlConn.Clone();
        }

        public static void CreateJiraProjectEntry(string jiraKey, string jiraName, string jiraDescription)
        {
            SetConnection();          
            string commandText =
            @"INSERT INTO JiraProjects(ProjectKey, Project, Opis)
              SELECT @param1, @param2, @param3
              WHERE NOT EXISTS(SELECT 1 FROM JiraProjects WHERE ProjectKey = @param1)";
            SQLiteCommand insertSql = new SQLiteCommand(commandText, sqlConn);
            insertSql.Parameters.Add(new SQLiteParameter("@param1", jiraKey));
            insertSql.Parameters.Add(new SQLiteParameter("@param2", jiraName));
            insertSql.Parameters.Add(new SQLiteParameter("@param3", jiraDescription));
            try
            {
                insertSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public static void UpdateJiraProjectEntry(string jiraKey, string jiraColor)
        {
            SetConnection();           
            string commandText =
            @"UPDATE JiraProjects
              SET ColorCode = @param1
              WHERE ProjectKey = @param2";
            SQLiteCommand updateSql = new SQLiteCommand(commandText, sqlConn);
            updateSql.Parameters.Add(new SQLiteParameter("@param1", jiraColor));
            updateSql.Parameters.Add(new SQLiteParameter("@param2", jiraKey));
            try
            {
                updateSql.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public static void CreateDBEntry(JiraTimeEntry timeEntry)
        {
            SetConnection();
            string commandText =
            @"INSERT INTO JiraEntry (PostingDate,JobNo,SubprojectCode,ActivityNo,WebNo,LocationCode,WorkType,
                                     WorkHours,ChargeableHours,Unchargeable,StepCode,Description1,OwnTransfer,
                                     Kilometers,TimeTravel,Parking,Exported,EntryId, StartDate, EndDate, Description2) VALUES
                                     (@param1,@param2,@param3,@param4,
                                      @param5,@param6,@param7,@param8,
                                      @param9,@param10,@param11,@param12,
                                      @param13,@param14,@param15,@param16,@param17,@param18, @param19, @param20, @param21)";
            SQLiteCommand insertSQL = new SQLiteCommand(commandText, sqlConn);
            //insertSQL.Parameters.Add(new SQLiteParameter("@param1", timeEntry.PostingDate.ToString("d")));
            insertSQL.Parameters.Add(new SQLiteParameter("@param1", timeEntry.PostingDate.ToString()));
            insertSQL.Parameters.Add(new SQLiteParameter("@param2", timeEntry.JobNo));
            insertSQL.Parameters.Add(new SQLiteParameter("@param3", timeEntry.SubprojectCode));
            insertSQL.Parameters.Add(new SQLiteParameter("@param4", timeEntry.ActivityNo));
            insertSQL.Parameters.Add(new SQLiteParameter("@param5", timeEntry.WebNo));
            insertSQL.Parameters.Add(new SQLiteParameter("@param6", timeEntry.LocationCode));
            insertSQL.Parameters.Add(new SQLiteParameter("@param7", timeEntry.WorkType));
            insertSQL.Parameters.Add(new SQLiteParameter("@param8", timeEntry.WorkHours));
            insertSQL.Parameters.Add(new SQLiteParameter("@param9", timeEntry.ChargeableHours));
            insertSQL.Parameters.Add(new SQLiteParameter("@param10", timeEntry.Unchargeable));
            insertSQL.Parameters.Add(new SQLiteParameter("@param11", timeEntry.StepCode));
            insertSQL.Parameters.Add(new SQLiteParameter("@param12", timeEntry.Description1));
            insertSQL.Parameters.Add(new SQLiteParameter("@param13", timeEntry.OwnTransfer));
            insertSQL.Parameters.Add(new SQLiteParameter("@param14", timeEntry.Kilometres));
            insertSQL.Parameters.Add(new SQLiteParameter("@param15", timeEntry.TimeTravel));
            insertSQL.Parameters.Add(new SQLiteParameter("@param16", timeEntry.Parking));
            insertSQL.Parameters.Add(new SQLiteParameter("@param17", "0"));
            insertSQL.Parameters.Add(new SQLiteParameter("@param18", timeEntry.guid));
            insertSQL.Parameters.Add(new SQLiteParameter("@param19", timeEntry.startDate));
            insertSQL.Parameters.Add(new SQLiteParameter("@param20", timeEntry.endDate));
            insertSQL.Parameters.Add(new SQLiteParameter("@param21", timeEntry.Description2));
            try
            {
                insertSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        public static void UpdateDBEntry(string Description, string webNo, DateTime startDate, DateTime endDate, string entryId, string jiraTime, bool unchargeable, string Description2)
        {
            SetConnection();
            string commandText =
            @"UPDATE JiraEntry SET StartDate = @param1, EndDate = @param2, Description1 = @param3, WorkHours = @param5, WebNo = @param6, Unchargeable = @param7, Description2 = @param8, Exported = 0 WHERE EntryId = @param4";
            SQLiteCommand updateSQL = new SQLiteCommand(commandText, sqlConn);
            updateSQL.Parameters.Add(new SQLiteParameter("@param1", startDate));
            updateSQL.Parameters.Add(new SQLiteParameter("@param2", endDate));
            updateSQL.Parameters.Add(new SQLiteParameter("@param3", Description));
            updateSQL.Parameters.Add(new SQLiteParameter("@param4", entryId));
            updateSQL.Parameters.Add(new SQLiteParameter("@param5", jiraTime));
            updateSQL.Parameters.Add(new SQLiteParameter("@param6", webNo));
            updateSQL.Parameters.Add(new SQLiteParameter("@param7", unchargeable));
            updateSQL.Parameters.Add(new SQLiteParameter("@param8", Description2));
            try
            {
                updateSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        public static void DeleteDBEntry(string entryId)
        {
            SetConnection();
            string commandText =
            @"DELETE FROM JiraEntry WHERE EntryId = @param1";
            SQLiteCommand deleteSQL = new SQLiteCommand(commandText, sqlConn);
            deleteSQL.Parameters.Add(new SQLiteParameter("@param1", entryId));
            try
            {
                deleteSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        public static void MarkAsExported(string entryId, string worklogId)
        {
            SetConnection();
            string commandText =
            @"UPDATE JiraEntry SET Exported = 1, WorklogId = @param2 WHERE EntryId = @param1";
            SQLiteCommand updateSQL = new SQLiteCommand(commandText, sqlConn);
            updateSQL.Parameters.Add(new SQLiteParameter("@param1", entryId));
            updateSQL.Parameters.Add(new SQLiteParameter("@param2", worklogId));

            try
            {
                updateSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        public static void MarkAsError(string entryId, string errorDescription)
        {
            SetConnection();
            string commandText =
            @"UPDATE JiraEntry SET Error = 1, ErrorText = @param2 WHERE EntryId = @param1";
            SQLiteCommand updateSQL = new SQLiteCommand(commandText, sqlConn);
            updateSQL.Parameters.Add(new SQLiteParameter("@param1", entryId));
            updateSQL.Parameters.Add(new SQLiteParameter("@param2", errorDescription));

            try
            {
                updateSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        private static bool RemoveAllCondition(CalendarItem obj)
        {
            return true;
        }
        public static void CalculateDailyHours(DateTime StartDate, out string dateCaption, out string hours)
        {
            string day = string.Empty;
            string month = string.Empty;
            string year = string.Empty;
            string inputDate = string.Empty;
            dateCaption = string.Empty;

            day = StartDate.Day.ToString("d2");
            month = StartDate.Month.ToString("d2");
            year = StartDate.Year.ToString();

            inputDate = year + "-" + month + "-" + day + "%";
            SetConnection();
            try
            {
                string commandText = "select sum(replace(workhours, \"m\", \"\")) from jiraEntry where startDate like \"" + inputDate + "\"";
                SQLiteCommand selectSQL = new SQLiteCommand(commandText, sqlConn);
                object result = selectSQL.ExecuteScalar();
                CloseConnection();
                dateCaption = StartDate.ToString("dddd") + " " + StartDate.Date.ToString("d");
                if (result != null && DBNull.Value != result)
                {
                    decimal minutes = Convert.ToDecimal(result);
                    minutes = minutes / 60;
                    hours = Convert.ToString(minutes);
                }
                else
                {
                    hours = "0";
                }
            }
            catch (Exception e)
            {
                hours = "0";
            }
        }
        public static void LoadItems(ref Calendar cal1)
        {
            Color headerColor;
            double luminance;
            cal1.Empty();
            //cal1.Items.RemoveAll(RemoveAllCondition);
            SetConnection();            

            string commandText =
            @"select StartDate, EndDate, Description1, Description2, EntryId, WebNo, WorkHours, Unchargeable, Exported, Error, ColorCode, WorklogId
              from JiraEntry
              left join JiraProjects jp
              on substr(WebNo, 1, instr(WebNo, '-') - 1) = jp.ProjectKey
              where StartDate >= @param1
              and EndDate <= @param2";
            try
            {
                SQLiteCommand selectSQL = new SQLiteCommand(commandText, sqlConn);
                selectSQL.Parameters.Add(new SQLiteParameter("@param1", cal1.ViewStart));
                selectSQL.Parameters.Add(new SQLiteParameter("@param2", cal1.ViewEnd));
                SQLiteDataReader reader = selectSQL.ExecuteReader();
                while (reader.Read())
                {
                    CalendarItem cItem = new CalendarItem(cal1);
                    cItem.StartDate = Convert.ToDateTime(reader["StartDate"]);
                    cItem.EndDate = Convert.ToDateTime(reader["EndDate"]);
                    cItem.Text = Convert.ToString(reader["Description1"]);
                    cItem.Description2 = Convert.ToString(reader["Description2"]);
                    cItem.calendarId = Convert.ToString(reader["EntryId"]);
                    cItem.webNo = Convert.ToString(reader["WebNo"]);
                    cItem.jiraTime = Convert.ToString(reader["WorkHours"]);
                    cItem.Unchargeable = Convert.ToBoolean(reader["Unchargeable"]);
                    cItem.Exported = Convert.ToBoolean(reader["Exported"]);
                    cItem.JiraWorklogId = Convert.ToString(reader["WorklogId"]);
                    if (!String.IsNullOrEmpty(Convert.ToString(reader["Error"])))
                        cItem.isError = Convert.ToBoolean(reader["Error"]);
                    if (cItem.Exported)
                    {
                        cItem.BackgroundColor = Color.LightGreen;
                        cItem.BackgroundColorLighter = Color.LightGreen;
                    }
                    if (cItem.isError)
                    {
                        cItem.BackgroundColor = Color.Red;
                        cItem.BackgroundColorLighter = Color.Red;
                    }
                    if (cItem.Unchargeable)
                    {
                        cItem.BackgroundColor = Color.GhostWhite;
                        cItem.BorderColor = Color.Red;
                    }
                    string colorCode = Convert.ToString(reader["ColorCode"]);
                    if (!String.IsNullOrEmpty(colorCode))
                    {
                        cItem.HeaderColor = FromHex(Convert.ToString(reader["ColorCode"]));
                        headerColor = FromHex(Convert.ToString(reader["ColorCode"]));
                        luminance = GetLuminance(headerColor.R, headerColor.G, headerColor.B);
                        if (luminance < 127.5)
                            cItem.HeaderFontColor = Color.White;
                        else
                            cItem.HeaderFontColor = Color.Black;
                    }
                    else
                    {
                        cItem.HeaderColor = FromHex(Properties.Settings.Default.DefaultHeaderColor);
                        headerColor = FromHex(Properties.Settings.Default.DefaultHeaderColor);
                        luminance = GetLuminance(headerColor.R, headerColor.G, headerColor.B);
                        if (luminance < 127.5)
                            cItem.HeaderFontColor = Color.White;
                        else
                            cItem.HeaderFontColor = Color.Black;
                    }
                    cal1.Items.Add(cItem);
                }
                CloseConnection();
            }
            catch (Exception e)
            {

            }
        }

        public static void LoadItemsWithFilter(ref Calendar cal1, string taskFilter)
        {
            Color headerColor;
            double luminance;
            cal1.Items.RemoveAll(RemoveAllCondition);
            SetConnection();
            //string commandText =
            //@"SELECT * FROM JiraEntry";

            string commandText =
            @"select StartDate, EndDate, Description1, Description2, EntryId, WebNo, WorkHours, Unchargeable, Exported, Error, ColorCode
              from JiraEntry
              left join JiraProjects jp
              on substr(WebNo, 1, instr(WebNo, '-') - 1) = jp.ProjectKey
              where WebNo = @param1";
            SQLiteCommand selectSQL = new SQLiteCommand(commandText, sqlConn);
            selectSQL.Parameters.Add(new SQLiteParameter("@param1", taskFilter));
            SQLiteDataReader reader = selectSQL.ExecuteReader();
            while (reader.Read())
            {
                CalendarItem cItem = new CalendarItem(cal1);
                cItem.StartDate = Convert.ToDateTime(reader["StartDate"]);
                cItem.EndDate = Convert.ToDateTime(reader["EndDate"]);
                cItem.Text = Convert.ToString(reader["Description1"]);
                cItem.Description2 = Convert.ToString(reader["Description2"]);
                cItem.calendarId = Convert.ToString(reader["EntryId"]);
                cItem.webNo = Convert.ToString(reader["WebNo"]);
                cItem.jiraTime = Convert.ToString(reader["WorkHours"]);                
                cItem.Unchargeable = Convert.ToBoolean(reader["Unchargeable"]);
                cItem.Exported = Convert.ToBoolean(reader["Exported"]);
                if (!String.IsNullOrEmpty(Convert.ToString(reader["Error"])))
                    cItem.isError = Convert.ToBoolean(reader["Error"]);
                if (cItem.Exported)
                {
                    cItem.BackgroundColor = Color.LightGreen;
                    cItem.BackgroundColorLighter = Color.LightGreen;
                }
                if (cItem.isError)
                {
                    cItem.BackgroundColor = Color.Red;
                    cItem.BackgroundColorLighter = Color.Red;
                }
                if (cItem.Unchargeable)
                {
                    cItem.BackgroundColor = Color.GhostWhite;
                    cItem.BorderColor = Color.Red;
                }
                string colorCode = Convert.ToString(reader["ColorCode"]);
                if (!String.IsNullOrEmpty(colorCode))
                {
                    cItem.HeaderColor = FromHex(Convert.ToString(reader["ColorCode"]));
                    headerColor = FromHex(Convert.ToString(reader["ColorCode"]));
                    luminance = GetLuminance(headerColor.R, headerColor.G, headerColor.B);
                    if (luminance < 127.5)
                        cItem.HeaderFontColor = Color.White;
                    else
                        cItem.HeaderFontColor = Color.Black;
                }
                cal1.Items.Add(cItem);
            }
            CloseConnection();
        }

        public static void RefreshItems(ref Calendar cal1)
        {

        }

        public static void WriteAllToJira()
        {
            List<JiraTimeEntry> JiraEntryList = new List<JiraTimeEntry>();
            SetConnection();
            string workLogId = string.Empty;
            string commandText = @"SELECT * FROM JiraEntry WHERE Exported = 0";
            SQLiteCommand selectSQL = new SQLiteCommand(commandText, sqlConn);
            SQLiteDataReader reader = selectSQL.ExecuteReader();
            while (reader.Read())
            {
                JiraTimeEntry jEntry = new JiraTimeEntry();
                jEntry.startDate = Convert.ToDateTime(reader["StartDate"]);
                jEntry.WorkHours = Convert.ToString(reader["WorkHours"]);
                jEntry.WebNo = Convert.ToString(reader["WebNo"]);
                jEntry.author = userName;
                jEntry.Description1 = Convert.ToString(reader["Description1"]);
                jEntry.Description2 = Convert.ToString(reader["Description2"]);
                jEntry.Unchargeable = Convert.ToInt32(reader["Unchargeable"]);
                jEntry.guid = Convert.ToString(reader["EntryId"]);
                JiraEntryList.Add(jEntry);
            }
            foreach (JiraTimeEntry jEntry in JiraEntryList)
            {
                try
                {                    
                    workLogId = WriteToJiraFullREST(jEntry);
                    MarkAsExported(jEntry.guid, workLogId);
                }
                catch (JiraApiException e)
                {                   
                    MarkAsError(jEntry.guid, e.Message);
                }
            }
            CloseConnection();
        }
        public static void WriteSingleToJira(CalendarItem item)
        {
            if (!string.IsNullOrWhiteSpace(item.JiraWorklogId))
            {
                UpdateJiraWorklog(item.JiraWorklogId);
            }
            else
            {
                List<JiraTimeEntry> JiraEntryList = new List<JiraTimeEntry>();
                SetConnection();
                string workLogId = string.Empty;

                string commandText = "SELECT * FROM JiraEntry WHERE Exported = 0 and EntryId = @calendarId";

                SQLiteCommand selectSQL = new SQLiteCommand(commandText, sqlConn);
                selectSQL.Parameters.AddWithValue("@calendarId", item.calendarId);
                SQLiteDataReader reader = selectSQL.ExecuteReader();
                while (reader.Read())
                {
                    JiraTimeEntry jEntry = new JiraTimeEntry();
                    jEntry.startDate = Convert.ToDateTime(reader["StartDate"]);
                    jEntry.WorkHours = Convert.ToString(reader["WorkHours"]);
                    jEntry.WebNo = Convert.ToString(reader["WebNo"]);
                    jEntry.author = userName;
                    jEntry.Description1 = Convert.ToString(reader["Description1"]);
                    jEntry.Description2 = Convert.ToString(reader["Description2"]);
                    jEntry.Unchargeable = Convert.ToInt32(reader["Unchargeable"]);
                    jEntry.guid = Convert.ToString(reader["EntryId"]);
                    JiraEntryList.Add(jEntry);
                }
                foreach (JiraTimeEntry jEntry in JiraEntryList)
                {
                    try
                    {
                        workLogId = WriteToJiraFullREST(jEntry);
                        MarkAsExported(jEntry.guid, workLogId);
                    }
                    catch (JiraApiException e)
                    {
                        MarkAsError(jEntry.guid, e.Message);
                    }
                }

                CloseConnection();
            }
        }

        public static string CreateJiraTask(string project, string subject, string body)
        {
            client = LoginInfo.LoginRest();
            Issue issue = new Issue();
            //issue.fields.
            //client.CreateIssue();
            return "";
        }


        public static string WriteToJiraFullREST(JiraTimeEntry jTimeEntry)
        {
            string comment = String.Empty;
            comment = string.IsNullOrEmpty(jTimeEntry.Description2) ? jTimeEntry.Description1 : jTimeEntry.Description1 + "|" + jTimeEntry.Description2;
            comment = jTimeEntry.Unchargeable == 1 ? String.Concat("0-", comment) : comment;
            client = LoginInfo.LoginRest(); //preveriti če je ok.
            Worklog newWorklog = new Worklog();
            newWorklog.comment = comment;
            int hours = TimeZoneInfo.Local.BaseUtcOffset.Hours;
            string offset = string.Format("{0}{1}", ((hours > 0) ? "+" : ""), hours.ToString("00"));            
            string isoformat = jTimeEntry.startDate.ToString("s") + ".000+0200";            
            newWorklog.started = isoformat;
            newWorklog.timeSpent = jTimeEntry.WorkHours;           
            Worklog wl = client.CreateWorklog1(newWorklog, jTimeEntry.WebNo);
            return wl.id;            
        }

        public static void UpdateJiraWorklog(string worklogId)
        {
            List<JiraTimeEntry> JiraEntryList = new List<JiraTimeEntry>();
            SetConnection();            
            string commandText = @"SELECT * FROM JiraEntry WHERE Exported = 0 and WorklogId = @param1"; //and entryId = nekaj.
            SQLiteCommand selectSQL = new SQLiteCommand(commandText, sqlConn);
            selectSQL.Parameters.Add(new SQLiteParameter("@param1", worklogId));
            SQLiteDataReader reader = selectSQL.ExecuteReader();
            while (reader.Read())
            {                
                JiraTimeEntry jEntry = new JiraTimeEntry();
                jEntry.startDate = Convert.ToDateTime(reader["StartDate"]);
                jEntry.WorkHours = Convert.ToString(reader["WorkHours"]);
                jEntry.WebNo = Convert.ToString(reader["WebNo"]);
                jEntry.author = userName;
                jEntry.Description1 = Convert.ToString(reader["Description1"]);
                jEntry.Description2 = Convert.ToString(reader["Description2"]);
                jEntry.Unchargeable = Convert.ToInt32(reader["Unchargeable"]);
                jEntry.guid = Convert.ToString(reader["EntryId"]);
                jEntry.JiraWorklogId = Convert.ToString(reader["WorklogId"]);
                JiraEntryList.Add(jEntry);
            }
            foreach (JiraTimeEntry jTimeEntry in JiraEntryList)
            {
                string comment = String.Empty;
                comment = string.IsNullOrEmpty(jTimeEntry.Description2) ? jTimeEntry.Description1 : jTimeEntry.Description1 + "|" + jTimeEntry.Description2;
                comment = jTimeEntry.Unchargeable == 1 ? String.Concat("0-", comment) : comment;
                client = LoginInfo.LoginRest(); //preveriti če je ok.
                Worklog newWorklog = new Worklog();
                newWorklog.comment = comment;
                int hours = TimeZoneInfo.Local.BaseUtcOffset.Hours;
                string offset = string.Format("{0}{1}", ((hours > 0) ? "+" : ""), hours.ToString("00"));
                string isoformat = jTimeEntry.startDate.ToString("s") + ".000+0200";
                newWorklog.started = isoformat;
                newWorklog.timeSpent = jTimeEntry.WorkHours;
                newWorklog.id = jTimeEntry.JiraWorklogId;
                try
                {
                    Worklog wl = client.UpdateWorklog(newWorklog, jTimeEntry.WebNo);
                    MarkAsExported(jTimeEntry.guid, jTimeEntry.JiraWorklogId);
                }
                catch (JiraApiException e)
                {
                    MarkAsError(jTimeEntry.guid, e.Message);
                }
            }
        }
            

        public static List<Project> GetAllProjectsREST(string token)
        {
            client = LoginInfo.LoginRest();
            List<Project> projects = client.GetProjects();
            return projects;
        }

       
        public static void GetRemoteProjectsREST()
        {
            List<Project> projects;
            projects = GetAllProjectsREST("");
            foreach (Project project in projects)
            {
                CreateJiraProjectEntry(project.key, project.name, "");
            }

        }

        private static T[] InitializeArray<T>(int length) where T : new()
        {
            T[] array = new T[length];
            for (int i = 0; i < length; ++i)
            {
                array[i] = new T();
            }

            return array;
        }
        public static Color FromHex(string hex)
        {
            if (hex.StartsWith("#"))
                hex = hex.Substring(1);

            if (hex.Length != 6) throw new Exception("Color not valid");

            return Color.FromArgb(
                int.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                int.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                int.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber));
        }

        public static String ToHex(Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }
        static byte[] entropy = System.Text.Encoding.Unicode.GetBytes("ma nek nakljucen salt");

        public static string EncryptString(System.Security.SecureString input)
        {
            byte[] encryptedData = System.Security.Cryptography.ProtectedData.Protect(
                System.Text.Encoding.Unicode.GetBytes(ToInsecureString(input)),
                entropy,
                System.Security.Cryptography.DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(encryptedData);
        }

        public static SecureString DecryptString(string encryptedData)
        {
            try
            {
                byte[] decryptedData = System.Security.Cryptography.ProtectedData.Unprotect(
                    Convert.FromBase64String(encryptedData),
                    entropy,
                    System.Security.Cryptography.DataProtectionScope.CurrentUser);
                return ToSecureString(System.Text.Encoding.Unicode.GetString(decryptedData));
            }
            catch
            {
                return new SecureString();
            }
        }

        public static SecureString ToSecureString(string input)
        {
            SecureString secure = new SecureString();
            foreach (char c in input)
            {
                secure.AppendChar(c);
            }
            secure.MakeReadOnly();
            return secure;
        }

        public static string ToInsecureString(SecureString input)
        {
            string returnValue = string.Empty;
            IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(input);
            try
            {
                returnValue = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
            }
            finally
            {
                System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
            }
            return returnValue;
        }
        public static double GetLuminance(byte r, byte g, byte b)
        {
            return 0.299 * r + 0.587 * g + 0.114 * b;
        }

    }
}
