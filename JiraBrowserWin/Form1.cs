using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using CefSharp;
using CefSharp.WinForms;
using System.Windows.Forms.Calendar;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using JiraBrowserWin.JiraModel;
using System.Threading;

namespace JiraBrowserWin
{
    public partial class Form1 : Form
    {        
        JiraClient client;
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        //string token;
        int iSeconds = 0;
        SQLiteConnection sqlConn;
        JiraTimeEntry timeEntry;
        DateTime startDateTime;
        string userName = "";
        CalendarItem calendarItem;
        private DataSet ds;
        private SQLiteDataAdapter da;
        private DataTable dt;
        private ListViewItemComparer _lvwItemComparer;
        private List<Rectangle> rectList;
        private List<String> taskList;
        private List<String> hoursList;
        private List<Brush> brushList;
        private List<Color> colorList;
        public Form1()
        {
            Splash.ShowOverlay();

            InitializeComponent();
            
            linkLabel8.Text = string.Empty;
            linkLabel9.Text = string.Empty;
            linkLabel10.Text = string.Empty;
            linkLabel11.Text = string.Empty;
            linkLabel12.Text = string.Empty;
            linkLabel13.Text = string.Empty;
            linkLabel14.Text = string.Empty;

            listView1.Invalidated += new InvalidateEventHandler(listView1_Invalidated);
            listView1.Columns.Add("Jira ID", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Opis", 300, HorizontalAlignment.Left);
            
            SetConnection();
            
            monthView1.SelectionStart = System.DateTime.Today;
            monthView1.SelectionEnd = System.DateTime.Today;

            ScrollBar vScrollBar1 = new VScrollBar();
            vScrollBar1.Dock = DockStyle.Right;
            vScrollBar1.Scroll += (sender, e) => { panel1.VerticalScroll.Value = vScrollBar1.Value; };
            panel1.Controls.Add(vScrollBar1);

            panel1.Visible = Properties.Settings.Default.ShowWeeklyHours;

            #region vnosi

            listView3.Columns.Add("Subject", 150, HorizontalAlignment.Left);
            // The ListViewItemSorter property allows you to specify the
            // object that performs the sorting of items in the ListView.
            // You can use the ListViewItemSorter property in combination
            // with the Sort method to perform custom sorting.
            _lvwItemComparer = new ListViewItemComparer();
            this.listView2.ListViewItemSorter = _lvwItemComparer;

            listView2.Columns.Add("Jira ID", 150, HorizontalAlignment.Left);
            listView2.Columns.Add("Začetni datum", 90, HorizontalAlignment.Left);
            listView2.Columns.Add("Začetni čas", 70, HorizontalAlignment.Left);
            listView2.Columns.Add("Končni datum", 90, HorizontalAlignment.Left);
            listView2.Columns.Add("Končni čas", 70, HorizontalAlignment.Left);
            listView2.Columns.Add("Opis 1", 300, HorizontalAlignment.Left);
            listView2.Columns.Add("Opis 2", 300, HorizontalAlignment.Left);
            listView2.Columns.Add("Nezaračunljivo", 100, HorizontalAlignment.Left);
            listView2.Columns.Add("Opis napake", 300, HorizontalAlignment.Left);
            try
            {
                FillData(sqlConn);
            }
            catch (Exception e)
            {

            }
            #endregion
            Splash.CloseForm();
            
            if (Properties.Settings.Default.Autologin && !String.IsNullOrEmpty(Properties.Settings.Default.Username) && !String.IsNullOrEmpty(Properties.Settings.Default.Secret))
            {
                Login(true);
            }
            try
            {
                InitializeChromium();
            }
            catch (Exception e)
            {
                
            }
        }       

        internal void FillData(SQLiteConnection sqlConn1)
        {
            string command = "Select * From JiraEntry";
            da = new SQLiteDataAdapter(command, sqlConn1);
            ds = new DataSet();
            SQLiteCommandBuilder commandBuilder = new SQLiteCommandBuilder(da);
            da.Fill(ds, "JiraEntry");
            dt = ds.Tables["JiraEntry"];
            listView2.Items.Clear();
            Font myCheckBoxFont = new Font("Wingdings", 12, FontStyle.Regular);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (dr.RowState != DataRowState.Deleted)
                {
                    // Define the list items
                    ListViewItem lvi = new ListViewItem(dr["WebNo"].ToString());
                    lvi.SubItems.Add(Convert.ToDateTime(dr["StartDate"]).Date.ToString("d"));
                    lvi.SubItems.Add(Convert.ToDateTime(dr["StartDate"]).TimeOfDay.ToString());
                    lvi.SubItems.Add(Convert.ToDateTime(dr["EndDate"]).Date.ToString("d"));
                    lvi.SubItems.Add(Convert.ToDateTime(dr["EndDate"]).TimeOfDay.ToString());
                    lvi.SubItems.Add(dr["Description1"].ToString());
                    lvi.SubItems.Add(dr["Description2"].ToString());
                    lvi.SubItems.Add(dr["Unchargeable"].ToString());
                    lvi.UseItemStyleForSubItems = false;
                    lvi.SubItems[7].Font = myCheckBoxFont;
                    if (lvi.SubItems[7].Text == "0")
                        lvi.SubItems[7].Text = ((char)168).ToString();
                    else
                        lvi.SubItems[7].Text = ((char)254).ToString();
                    // Add the list items to the ListView
                    lvi.SubItems.Add(dr["ErrorText"].ToString());
                    listView2.Items.Add(lvi);
                }
            }
        }
        private void listView2_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == _lvwItemComparer.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (_lvwItemComparer.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    _lvwItemComparer.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    _lvwItemComparer.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                _lvwItemComparer.SortColumn = e.Column;
                _lvwItemComparer.Order = System.Windows.Forms.SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView2.Sort();
        }
        
        
        

        // Draws column headers.
        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                // Store the column text alignment, letting it default
                // to Left if it has not been set to Center or Right.
                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        break;
                }

                // Draw the standard header background.
                e.DrawBackground();

                // Draw the header text.
                using (Font headerFont =
                            new Font("Segoe UI", 8, FontStyle.Bold))
                {
                    e.Graphics.DrawString(e.Header.Text, headerFont,
                        Brushes.Black, e.Bounds, sf);
                }
            }
            return;
        }

        // Draws the backgrounds for entire ListView items.
        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {

            if ((e.State & ListViewItemStates.Selected) != 0)
            {
                // Draw the background and focus rectangle for a selected item.
                e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds);
                e.DrawFocusRectangle();
            }
            /*
            else
            {
                // Draw the background for an unselected item.
                using (LinearGradientBrush brush =
                    new LinearGradientBrush(e.Bounds, Color.Orange,
                    Color.Maroon, LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                }
            }
            */

            // Draw the item text for views other than the Details view.
            if (listView1.View != View.Details)
            {
                e.DrawText();
            }
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            TextFormatFlags flags = TextFormatFlags.Left;

            using (StringFormat sf = new StringFormat())
            {
                // Store the column text alignment, letting it default
                // to Left if it has not been set to Center or Right.
                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        flags = TextFormatFlags.HorizontalCenter;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        flags = TextFormatFlags.Right;
                        break;
                }

                // Draw the text and background for a subitem with a 
                // negative value. 
                double subItemValue;
                if (e.ColumnIndex > 0 && Double.TryParse(
                    e.SubItem.Text, NumberStyles.Currency,
                    NumberFormatInfo.CurrentInfo, out subItemValue) &&
                    subItemValue < 0)
                {
                    // Unless the item is selected, draw the standard 
                    // background to make it stand out from the gradient.
                    if ((e.ItemState & ListViewItemStates.Selected) == 0)
                    {
                        e.DrawBackground();
                    }

                    // Draw the subitem text in red to highlight it. 
                    e.Graphics.DrawString(e.SubItem.Text,
                        listView1.Font, Brushes.Red, e.Bounds, sf);

                    return;
                }

                // Draw normal text for a subitem with a nonnegative 
                // or nonnumerical value.
                e.DrawText(flags);
            }
        }

        // Forces each row to repaint itself the first time the mouse moves over 
        // it, compensating for an extra DrawItem event sent by the wrapped 
        // Win32 control. This issue occurs each time the ListView is invalidated.
        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewItem item = listView1.GetItemAt(e.X, e.Y);
            if (item != null && item.Tag == null)
            {
                listView1.Invalidate(item.Bounds);
                item.Tag = "tagged";
            }
        }
        // Selects and focuses an item when it is clicked anywhere along 
        // its width. The click must normally be on the parent item text.
        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            ListViewItem clickedItem = listView1.GetItemAt(e.X, e.Y);
            if (clickedItem != null)
            {
                clickedItem.Selected = true;
                clickedItem.Focused = true;
            }
        }
        // Resets the item tags. 
        void listView1_Invalidated(object sender, InvalidateEventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item == null) return;
                item.Tag = null;
            }
        }

        // Forces the entire control to repaint if a column width is changed.
        void listView1_ColumnWidthChanged(object sender,
            ColumnWidthChangedEventArgs e)
        {
            listView1.Invalidate();
        }


        public ChromiumWebBrowser chromeBrowser;

        public void InitializeChromium()
        {
            
            CefSettings settings = new CefSettings();
            settings.CachePath = @"C:\temp\";
            // Initialize cef with the provided settings            
            Cef.Initialize(settings);
            // Create a browser component
            chromeBrowser = new ChromiumWebBrowser("https://jira.adacta-group.com");
            // Add it to the form and fill it to the form window.
            this.tabPage2.Controls.Add(chromeBrowser);
            chromeBrowser.Dock = DockStyle.Fill;
            
        }

        private void btn_Refresh(object sender, EventArgs e)
        {            
            Login(false);         
        }        

        private void Login(bool firstRun)
        {
            string exceptionMessage = string.Empty;
            Properties.Settings.Default.Reload();
            if (Properties.Settings.Default.Autologin && !String.IsNullOrEmpty(Properties.Settings.Default.Username) && !String.IsNullOrEmpty(Properties.Settings.Default.Secret))
            {
                LoginInfo.txUserName = Properties.Settings.Default.Username;
                LoginInfo.txPassword = CommonFunctions.ToInsecureString(CommonFunctions.DecryptString(Properties.Settings.Default.Secret));
            }
            else
            {
                LoginForm loginFrm = new LoginForm();
                loginFrm.ShowDialog();
            }
            LoginInfo.jUrl = Properties.Settings.Default.RESTurl;
            client = LoginInfo.LoginRest();
            if (!string.IsNullOrEmpty(exceptionMessage))
                MessageBox.Show(exceptionMessage);
            else
            {
                userName = LoginInfo.txUserName;
                CommonFunctions.userName = userName;
                if (!firstRun)
                {
                    loading_overlay.ShowOverlay(this);
                    RefreshIssues();
                    RefreshFilters();
                    CommonFunctions.GetRemoteProjectsREST();
                    loading_overlay.CloseForm();
                }
                else
                {
                    Splash.ShowOverlay();
                    RefreshIssues();
                    RefreshFilters();
                    CommonFunctions.GetRemoteProjectsREST();
                    Splash.CloseForm();
                }
            }
        }
        private void RefreshIssues()
        {
            try
            {
                //>>>>
                /*
                var dict = new Dictionary<Guid, string>();
                foreach (DataRow row in dt.Rows)
                {
                    dict.Add(row["GUID"], row["Name"] + " " + row["Surname"]);
                }
                cbo.DataSource = dict;
                cbo.DataTextField = "Value";
                cbo.DataValueField = "Key";
                cbo.DataBind();
                */
                //<<<<
                                
                int iObjectCount = 0;    
                Issues issues = client.GetIssuesByJql(ResourceUrls.GetIssuesByAssignee(userName), 1, 100);
                MTGCComboBoxItem[] comboObjects = new MTGCComboBoxItem[issues.issues.Count];
                CommonFunctions.commonIssuesRest = issues;             
                //comboBox1.DataSource = issues.issues;
                //comboBox1.DisplayMember = "key";                                                                                
                //comboBox1.Update();
                listView1.Items.Clear();
                mtgcComboBox1.Items.Clear();
                foreach(Issue issue in issues.issues)
                {
                    ListViewItem mainItem = new ListViewItem(issue.key);
                    mainItem.SubItems.Add(issue.fields.summary);
                    listView1.Items.Add(mainItem);
                    comboObjects[iObjectCount] = new MTGCComboBoxItem(issue.key, issue.fields.summary);
                    iObjectCount += 1;
                }                
                mtgcComboBox1.Items.AddRange(comboObjects);
            }            
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
        }

        private void RefreshIssuesWithFilterREST(string filterId)
        {
            string jqlString = string.Empty;
            jqlString = "";            
            int iObjectCount = 0;            
            Issues issues = client.GetIssuesByJql(ResourceUrls.JqlSearchByFilterId(filterId), 0, 500, null);
            
            MTGCComboBoxItem[] comboObjects = new MTGCComboBoxItem[issues.issues.Count];
            CommonFunctions.commonIssuesRest = issues;
            //comboBox1.DataSource = issues.issues;
            //comboBox1.DisplayMember = "key";
            //comboBox1.Update();
            //comboBox1.SelectedIndex = -1;
            listView1.Items.Clear();
            mtgcComboBox1.Items.Clear();          
            foreach (Issue issue in issues.issues)
            {
                ListViewItem mainItem = new ListViewItem(issue.key);
                mainItem.SubItems.Add(issue.fields.summary);
                listView1.Items.Add(mainItem);
                comboObjects[iObjectCount] = new MTGCComboBoxItem(issue.key, issue.fields.summary);
                iObjectCount += 1;
            }
            mtgcComboBox1.Items.AddRange(comboObjects);
            //CommonFunctions.GetRemoteProjectsREST();
        }       

        private void RefreshFilters()
        {
            try
            {
                List<Filter1> filters = client.GetFavouriteFilters1();
                CommonFunctions.commonFilter = filters;
                comboBox2.DataSource = filters;
                comboBox2.DisplayMember = "name";
                comboBox2.ValueMember = "id";
            }
            catch (Exception e)
            {

            }
        }

        private T[] InitializeArray<T>(int length) where T : new()
        {
            T[] array = new T[length];
            for (int i = 0; i < length; ++i)
            {
                array[i] = new T();
            }

            return array;
        }
        //findme
        //private void button3_Click(object sender, EventArgs e)
        //{
        //    if (LoginInfo.Logout(jsrv, token))
        //        MessageBox.Show("Logout succesfull");
        //    else
        //        MessageBox.Show("Logout failed");
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            iSeconds++;
            TimeSpan span = new TimeSpan(0, 0, iSeconds);
            string yourStr = string.Format("{00}:{1:00}", (int)span.TotalMinutes, span.Seconds);
            counterLabel.Text = yourStr;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            iSeconds = 0;
            counterLabel.Text = "0:00";
            timer1.Start();
            startDateTime = DateTime.Now;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            //if (iSeconds < 120)
            //{
            //    timer1.Stop();
            //    return;
            //}

            //if ((iSeconds > 120) & (iSeconds < 900))
                iSeconds = 900;
            
            timer1.Stop();
            timeEntry = new JiraTimeEntry();
            timeEntry.PostingDate = DateTime.Now.Date;
            timeEntry.guid = Guid.NewGuid().ToString("N");
            timeEntry.JobNo = "";
            timeEntry.SubprojectCode = "";
            timeEntry.ActivityNo = "";
            //if (comboBox1.SelectedItem != null)
            if (mtgcComboBox1.SelectedItem != null)
            {
                //timeEntry.WebNo = ((Issue)comboBox1.SelectedItem).key;
                timeEntry.WebNo = mtgcComboBox1.SelectedItem.Col1.ToString();
            }
            else
                //timeEntry.WebNo = comboBox1.Text;
                timeEntry.WebNo = mtgcComboBox1.Text;
            timeEntry.LocationCode = "ADACTA";
            timeEntry.WorkType = "PROG";
            TimeSpan span = new TimeSpan(0, 0, iSeconds).RoundToNearestMinutes(15);
            string jiraMinutes = span.TotalMinutes + "m";
            timeEntry.WorkHours = jiraMinutes;
            timeEntry.ChargeableHours = "";
            timeEntry.Unchargeable = 0;
            timeEntry.StepCode = "";
            timeEntry.Description1 = textBox1.Text;
            timeEntry.OwnTransfer = 0;
            timeEntry.Kilometres = "0";
            timeEntry.TimeTravel = "0";
            timeEntry.Parking = "0";
            timeEntry.startDate = startDateTime;
            //timeEntry.endDate = DateTime.Now;  
            timeEntry.endDate = startDateTime.AddMinutes(span.TotalMinutes);

            CommonFunctions.CreateDBEntry(timeEntry);
            CommonFunctions.LoadItems(ref calendar1);
            calendar1.Refresh();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (!string.IsNullOrEmpty(token))
            //    LoginInfo.Logout(jsrv, token);
            Cef.Shutdown();
        }

        private void SetConnection()
        {
            string databaseLocation = Properties.Settings.Default.DBLocation;
            try
            {
                sqlConn = new SQLiteConnection("Data Source=" + databaseLocation + ";Version=3");
                sqlConn.Open();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
        }
     
        private void EditBtn_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings(sqlConn);
            settingsForm.ShowDialog();
            LoadItems();
            panel1.Visible = Properties.Settings.Default.ShowWeeklyHours;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            loading_overlay.ShowOverlay(this);
            Thread.Sleep(500);
            CommonFunctions.WriteAllToJira();            
            loading_overlay.CloseForm();
            LoadItems();
            calendar1.Refresh();
            MessageBox.Show("Podatki so poslani v Jiro", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text != "Moji zahtevki")
            {
                chromeBrowser.Load("https://jira.adacta-group.com/browse/" + e.Node.Text);
                tabControl1.SelectedIndex = 1;
            }
        }

        private void LoadItems()
        {
            //calendar1.ViewEnd = DateTime.Now;
            //calendar1.ViewStart = DateTime.Now;          
            //calendar1.ViewStart = DateTime.Now.StartOfWeek(DayOfWeek.Monday).AddHours(8);
            //calendar1.ViewEnd = calendar1.ViewStart.AddDays(6);
            calendar1.SetViewRange(monthView1.SelectionStart.StartOfWeek(DayOfWeek.Monday), monthView1.SelectionStart.StartOfWeek(DayOfWeek.Monday).AddDays(6));
            calendar1.TimeUnitsOffset = -30;
            CommonFunctions.LoadItems(ref calendar1);
        }

        private void calendar1_ItemCreated(object sender, System.Windows.Forms.Calendar.CalendarItemCancelEventArgs e)
        {
            JiraTimeEntry timeEntry = new JiraTimeEntry();
            timeEntry.guid = Guid.NewGuid().ToString("N");
            e.Item.calendarId = timeEntry.guid;
            //timeEntry.PostingDate = DateTime.Now.Date;
            timeEntry.PostingDate = e.Item.Date;
            timeEntry.startDate = e.Item.StartDate;
            timeEntry.endDate = e.Item.EndDate;
            timeEntry.JobNo = "";
            timeEntry.SubprojectCode = "";
            timeEntry.ActivityNo = "";
            timeEntry.LocationCode = "ADACTA";
            timeEntry.WorkType = "PROG";
            TimeSpan span = new TimeSpan();
            span = e.Item.Duration;
            span.RoundToNearestMinutes(15);
            e.Item.jiraTime = "15m";
            string jiraMinutes = span.TotalMinutes + "m";
            timeEntry.WorkHours = jiraMinutes;

            //timeEntry.WorkHours = string.Format("{00}:{1:00}", (int)span.TotalMinutes, span.Seconds);
            //timeEntry.WorkHours = string.Format("{00}", (int)span.TotalMinutes);
            timeEntry.ChargeableHours = "";
            timeEntry.Unchargeable = 0;
            timeEntry.StepCode = "";
            //timeEntry.ShortDescription = "TEST KOLEDARJA";
            timeEntry.Description1 = e.Item.Text;
            timeEntry.OwnTransfer = 0;
            timeEntry.Kilometres = "0";
            timeEntry.TimeTravel = "0";
            timeEntry.Parking = "0";

            //CommonFunctions fnc = new CommonFunctions();
            //fnc.CreateDBEntry(timeEntry);
            CommonFunctions.CreateDBEntry(timeEntry);
            WorkLogEditor wle = new WorkLogEditor(e.Item, client);
            wle.StartPosition = FormStartPosition.CenterParent;
            wle.ShowDialog();
            CommonFunctions.LoadItems(ref calendar1);            
            calendar1.Refresh();
            refreshHourCounters();
            panel1.Refresh();         
        }

        private void calendar1_ItemDatesChanged(object sender, System.Windows.Forms.Calendar.CalendarItemEventArgs e)
        {
            TimeSpan span = new TimeSpan();
            span = e.Item.Duration;
            span.RoundToNearestMinutes(15);
            string jiraMinutes = span.TotalMinutes + "m";
            string tag = Convert.ToString(e.Item.Tag);
            CommonFunctions.UpdateDBEntry(e.Item.Text, e.Item.webNo, e.Item.StartDate, e.Item.EndDate, e.Item.calendarId, jiraMinutes, e.Item.Unchargeable, e.Item.Description2);            
            CommonFunctions.LoadItems(ref calendar1);
            calendar1.Refresh();            
            refreshHourCounters();
            panel1.Refresh();
        }

        private void CallTransferSchedVScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            //calendar1.TimeUnitsOffset = -CallTransferSchedVScrollBar.Value;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void testToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string description = string.Empty;
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                description = item.Text;
                WorkLogEditor wLog = new WorkLogEditor(item, client);
                wLog.ShowDialog();
                CommonFunctions.LoadItems(ref calendar1);
                calendar1.Refresh();
                refreshHourCounters();
            }
        }

        private void contextMenuStrip1_Opening_1(object sender, CancelEventArgs e)
        {
            calendarItem = calendar1.ItemAt(contextMenuStrip1.Bounds.Location);
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            refreshHourCounters();
        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            calendar1.SetViewRange(monthView1.SelectionStart.StartOfWeek(DayOfWeek.Monday), monthView1.SelectionStart.StartOfWeek(DayOfWeek.Monday).AddDays(6));
            CommonFunctions.LoadItems(ref calendar1);
            CommonFunctions.currentStartDate = monthView1.SelectionStart.StartOfWeek(DayOfWeek.Monday);
            CommonFunctions.currentEndDate = monthView1.SelectionStart.StartOfWeek(DayOfWeek.Monday).AddDays(6);
            refreshHourCounters();
            panel1.Refresh();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                DialogResult dialogResult = MessageBox.Show("Res želite brisati?", "Potrditev brisanja", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    CommonFunctions.DeleteDBEntry(item.calendarId);
                    CommonFunctions.LoadItems(ref calendar1);
                    calendar1.Refresh();
                    refreshHourCounters();
                }
            }
        }


        private void calendar1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string description = string.Empty;
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                description = item.Text;
                WorkLogEditor wLog = new WorkLogEditor(item, client);                
                wLog.StartPosition = FormStartPosition.CenterParent;
                wLog.ShowDialog();
                //wLog.ShowDialog(this);
                CommonFunctions.LoadItems(ref calendar1);
                calendar1.Refresh();
            }
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ComboBox comboBox = (ComboBox)sender;
            //CommonFunctions.commonFilter[]
            //old
            //JiraService.RemoteFilter rf = (JiraService.RemoteFilter)comboBox.SelectedItem;                        
            Filter1 selectedFilter = ((Filter1)comboBox2.SelectedItem);                        
            RefreshIssuesWithFilterREST(selectedFilter.id);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadItems();
            refreshHourCounters();
        }

        private void GetOutlookFolders()
        {

        }

        private void GetOutlookItems()
        {
            DateTime startTime = monthView1.SelectionStart.StartOfWeek(DayOfWeek.Monday);
            DateTime endTime = monthView1.SelectionStart.StartOfWeek(DayOfWeek.Monday).AddDays(6);
            Outlook.Application oApp = null;
            Outlook.NameSpace mapiNamespace = null;
            Outlook.MAPIFolder MailFolder = null;
            Outlook.Items outlookMailItems = null;

            oApp = new Outlook.Application();
            mapiNamespace = oApp.GetNamespace("MAPI"); ;
            MailFolder = mapiNamespace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
            outlookMailItems = MailFolder.Items;
            
            string filter = "[LastModificationTime] >= '" + startTime.ToString("g") + "' AND [LastModificationTime] <= '" + endTime.ToString("g") + "'";
            Outlook.Items restrictItems = outlookMailItems.Restrict(filter);
            listView3.Items.Clear();
            restrictItems.Sort("LastModificationTime", System.Windows.Forms.SortOrder.Ascending);
            foreach (object item in restrictItems)
            {
                var mail = item as Outlook.MailItem;
                if (mail != null)
                {
                    listView3.Items.Add(new ListViewItem(mail.Subject));
                }                
            }             
        }

        private void GetOutlookCalendar()
        {
            string innerException;
            DateTime startTime = monthView1.SelectionStart.StartOfWeek(DayOfWeek.Monday);
            DateTime endTime = monthView1.SelectionStart.StartOfWeek(DayOfWeek.Monday).AddDays(6);

            Outlook.Application oApp = null;
            Outlook.NameSpace mapiNamespace = null;
            Outlook.MAPIFolder CalendarFolder = null;
            Outlook.Items outlookCalendarItems = null;

            oApp = new Outlook.Application();
            mapiNamespace = oApp.GetNamespace("MAPI"); ;
            CalendarFolder = mapiNamespace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderCalendar);
            outlookCalendarItems = CalendarFolder.Items;
            outlookCalendarItems.IncludeRecurrences = true;
            string filter = "[Start] >= '" + startTime.ToString("g") + "' AND [End] <= '" + endTime.ToString("g") + "'";

            Outlook.Items restrictItems = outlookCalendarItems.Restrict(filter);

            foreach (Outlook.AppointmentItem item in restrictItems)
            {
                if (item.Sensitivity != Outlook.OlSensitivity.olPrivate)
                {
                    if (item.IsRecurring)
                    {

                        Outlook.RecurrencePattern rp = item.GetRecurrencePattern();
                        DateTime first = monthView1.SelectionStart.StartOfWeek(DayOfWeek.Monday);
                        DateTime last = monthView1.SelectionStart.StartOfWeek(DayOfWeek.Monday).AddDays(6);
                        Outlook.AppointmentItem recur = null;
                        for (DateTime cur = first; cur <= last; cur = cur.AddDays(1))
                        {
                            try
                            {
                                cur = cur.AddHours(item.Start.Hour);
                                cur = cur.AddMinutes(item.Start.Minute);
                                cur = cur.AddSeconds(item.Start.Second);
                                recur = rp.GetOccurrence(cur);
                                //preveriti ali ta outlook item že obstaja v koledarju.
                                //calendar1.Items.Find(x => x.isOutlookItem == true);                                                       
                                CalendarItem calItem1 = new CalendarItem(calendar1, recur.Start, recur.End, recur.Subject, true);
                                JiraTimeEntry timeEntry = new JiraTimeEntry();
                                timeEntry.guid = Guid.NewGuid().ToString("N");
                                calItem1.calendarId = timeEntry.guid;
                                timeEntry.PostingDate = calItem1.Date;
                                timeEntry.startDate = calItem1.StartDate;
                                timeEntry.endDate = calItem1.EndDate;
                                timeEntry.JobNo = "";
                                timeEntry.SubprojectCode = "";
                                timeEntry.ActivityNo = "";
                                timeEntry.LocationCode = "ADACTA";
                                timeEntry.WorkType = "PROG";
                                TimeSpan span = new TimeSpan();
                                span = calItem1.Duration;
                                span.RoundToNearestMinutes(15);
                                string jiraMinutes = span.TotalMinutes + "m";
                                timeEntry.WorkHours = jiraMinutes;
                                timeEntry.ChargeableHours = "";
                                timeEntry.Unchargeable = 0;
                                timeEntry.StepCode = "";
                                timeEntry.Description1 = calItem1.Text;
                                timeEntry.OwnTransfer = 0;
                                timeEntry.Kilometres = "0";
                                timeEntry.TimeTravel = "0";
                                timeEntry.Parking = "0";
                                CommonFunctions.CreateDBEntry(timeEntry);
                                CommonFunctions.LoadItems(ref calendar1);
                                calendar1.Refresh();
                                calItem1.BackgroundColor = Color.Brown;
                                calendar1.Items.Add(calItem1);
                            }
                            catch (Exception e)
                            {
                                innerException = e.Message;
                                //MessageBox.Show(e.Message);
                            }
                        }
                    }

                    else
                    {
                        //naredi time entry
                        CalendarItem calItem1 = new CalendarItem(calendar1, item.Start, item.End, item.Subject, true);
                        JiraTimeEntry timeEntry = new JiraTimeEntry();
                        timeEntry.guid = Guid.NewGuid().ToString("N");
                        calItem1.calendarId = timeEntry.guid;
                        timeEntry.PostingDate = calItem1.Date;
                        timeEntry.startDate = calItem1.StartDate;
                        timeEntry.endDate = calItem1.EndDate;
                        timeEntry.JobNo = "";
                        timeEntry.SubprojectCode = "";
                        timeEntry.ActivityNo = "";
                        timeEntry.LocationCode = "ADACTA";
                        timeEntry.WorkType = "PROG";
                        TimeSpan span = new TimeSpan();
                        span = calItem1.Duration;
                        span.RoundToNearestMinutes(15);
                        string jiraMinutes = span.TotalMinutes + "m";
                        timeEntry.WorkHours = jiraMinutes;
                        timeEntry.ChargeableHours = "";
                        timeEntry.Unchargeable = 0;
                        timeEntry.StepCode = "";
                        timeEntry.Description1 = calItem1.Text;
                        timeEntry.OwnTransfer = 0;
                        timeEntry.Kilometres = "0";
                        timeEntry.TimeTravel = "0";
                        timeEntry.Parking = "0";
                        CommonFunctions.CreateDBEntry(timeEntry);
                        CommonFunctions.LoadItems(ref calendar1);
                        calendar1.Refresh();
                        calItem1.BackgroundColor = Color.DarkSalmon;
                        calendar1.Items.Add(calItem1);
                    }
                }
            }
        }

        private void btn_OlCal_Click(object sender, EventArgs e)
        {
            GetOutlookCalendar();
        }

        private void potrdiSestanekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            JiraTimeEntry timeEntry = new JiraTimeEntry();
            timeEntry.guid = Guid.NewGuid().ToString("N");
            e.Item.calendarId = timeEntry.guid;            
            timeEntry.PostingDate = e.Item.Date;
            timeEntry.startDate = e.Item.StartDate;
            timeEntry.endDate = e.Item.EndDate;
            timeEntry.JobNo = "";
            timeEntry.SubprojectCode = "";
            timeEntry.ActivityNo = "";
            timeEntry.LocationCode = "ADACTA";
            timeEntry.WorkType = "PROG";
            TimeSpan span = new TimeSpan();
            span = e.Item.Duration;
            span.RoundToNearestMinutes(15);
            string jiraMinutes = span.TotalMinutes + "m";
            timeEntry.WorkHours = jiraMinutes;
            timeEntry.ChargeableHours = "";
            timeEntry.Unchargeable = 0;
            timeEntry.StepCode = "";
            timeEntry.ShortDescription = e.Item.Text;
            timeEntry.OwnTransfer = 0;
            timeEntry.Kilometres = "0";
            timeEntry.TimeTravel = "0";
            timeEntry.Parking = "0";
            CommonFunctions.CreateDBEntry(timeEntry);
            CommonFunctions.LoadItems(ref calendar1);
            calendar1.Refresh();
            */
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                chromeBrowser.Load("https://jira.adacta-group.com/browse/" + item.webNo);
                tabControl1.SelectedIndex = 1;
            }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string description = string.Empty;
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                textBox1.Text = item.Text;
                //comboBox1.Text = item.webNo;
                mtgcComboBox1.Text = item.webNo;
            }
            iSeconds = 0;
            counterLabel.Text = "0:00";
            timer1.Start();
            startDateTime = DateTime.Now;
        }

     
        void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = ((ListView)sender).HitTest(e.X, e.Y);
            ListViewItem item = info.Item;

            if (item != null)
            {
                //vpiši v selector, če timer ne teče
                if (!timer1.Enabled)
                    //comboBox1.Text = item.Text;
                    mtgcComboBox1.Text = item.Text;
                chromeBrowser.Load("https://jira.adacta-group.com/browse/" + item.Text);
            }
            else
            {
                this.listView1.SelectedItems.Clear();
            }
        }

        private void writeToJiraToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {                
                CommonFunctions.WriteSingleToJira(item);
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                ListView.SelectedListViewItemCollection items = listView1.SelectedItems;

                ListViewItem lvItem = listView1.SelectedItems[0];
                string jId = lvItem.Text;
                chromeBrowser.Load("https://jira.adacta-group.com/browse/" + jId);
                tabControl1.SelectedIndex = 2;
            }
        }

        private void refreshHourCounters()
        {
            string dateCaption = string.Empty;
            string timeCaption = string.Empty;
            CommonFunctions.CalculateDailyHours(monthView1.SelectionStart.StartOfWeek(DayOfWeek.Monday), out dateCaption, out timeCaption);
            linkLabel8.Text = dateCaption;
            linkLabel7.Text = timeCaption;
            CommonFunctions.CalculateDailyHours(monthView1.SelectionStart.StartOfWeek(DayOfWeek.Monday).AddDays(1), out dateCaption, out timeCaption);
            linkLabel9.Text = dateCaption;
            linkLabel6.Text = timeCaption;
            CommonFunctions.CalculateDailyHours(monthView1.SelectionStart.StartOfWeek(DayOfWeek.Monday).AddDays(2), out dateCaption, out timeCaption);
            linkLabel10.Text = dateCaption;
            linkLabel5.Text = timeCaption;
            CommonFunctions.CalculateDailyHours(monthView1.SelectionStart.StartOfWeek(DayOfWeek.Monday).AddDays(3), out dateCaption, out timeCaption);
            linkLabel11.Text = dateCaption;
            linkLabel4.Text = timeCaption;
            CommonFunctions.CalculateDailyHours(monthView1.SelectionStart.StartOfWeek(DayOfWeek.Monday).AddDays(4), out dateCaption, out timeCaption);
            linkLabel12.Text = dateCaption;
            linkLabel3.Text = timeCaption;
            CommonFunctions.CalculateDailyHours(monthView1.SelectionStart.StartOfWeek(DayOfWeek.Monday).AddDays(5), out dateCaption, out timeCaption);
            linkLabel13.Text = dateCaption;
            linkLabel2.Text = timeCaption;
            CommonFunctions.CalculateDailyHours(monthView1.SelectionStart.StartOfWeek(DayOfWeek.Monday).AddDays(6), out dateCaption, out timeCaption);
            linkLabel14.Text = dateCaption;
            linkLabel1.Text = timeCaption;
        }
        private void FilterAndShowResults()
        {

        }

        private void calendar1_ItemDeleting(object sender, CalendarItemCancelEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Res želite brisati?", "Potrditev brisanja", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                CommonFunctions.DeleteDBEntry(e.Item.calendarId);             
                refreshHourCounters();
                panel1.Refresh();
                
            }
            else if (dialogResult == DialogResult.No)
            {
                calendar1.Refresh();
                refreshHourCounters();
            }
        }  

        private void GetWeeklyTasks(object sender, PaintEventArgs e)
        {
            int yPos = 0;
            double luminance;
            Font fnt = new Font("Segoe UI", 8.25f, FontStyle.Bold);
            Color fontColor;
            string workhours = string.Empty;
            string colorCode = string.Empty;
            string webNo = string.Empty;
            string hours = string.Empty;
            rectList = new List<Rectangle>();
            taskList = new List<string>();
            hoursList = new List<string>();
            brushList = new List<Brush>();
            colorList = new List<Color>();

            string selectText =
            "select WebNo, sum(replace(workhours, \"m\", \"\")) AS Workhours, ColorCode " +
              "from JiraEntry " +
              "left join JiraProjects jp " +
              "on substr(WebNo, 1, instr(WebNo, '-') - 1) = jp.ProjectKey " +
              "where StartDate >= @param1 and EndDate <= @param2 " +
              "group by WebNo";

            //string selectText =
            //    @"select distinct WebNo from JiraEntry where StartDate >= @param1 and EndDate <=@param2";
            try
            {
                SQLiteCommand sqlCommand = new SQLiteCommand(selectText, sqlConn);
                sqlCommand.Parameters.Add(new SQLiteParameter("@param1", CommonFunctions.currentStartDate));
                sqlCommand.Parameters.Add(new SQLiteParameter("@param2", CommonFunctions.currentEndDate));
                SQLiteDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    workhours = Convert.ToString(reader["Workhours"]);
                    colorCode = Convert.ToString(reader["ColorCode"]);
                    webNo = Convert.ToString(reader["WebNo"]);
                    taskList.Add(webNo);

                    Rectangle rc = new Rectangle(0, yPos, panel1.Width - 20, 20);
                    rectList.Add(rc);

                    decimal minutes = Convert.ToDecimal(workhours);
                    minutes = minutes / 60;
                    hours = Convert.ToString(minutes);
                    hoursList.Add(hours);

                    if (!String.IsNullOrEmpty(colorCode))
                    {
                        SolidBrush br = new SolidBrush(CommonFunctions.FromHex(colorCode));
                        brushList.Add(br);
                        //e.Graphics.FillRectangle(br, rc);                
                        Color col = CommonFunctions.FromHex(colorCode);

                        luminance = CommonFunctions.GetLuminance(col.R, col.G, col.B);
                        if (luminance < 127.5)
                            fontColor = Color.White;
                        else
                            fontColor = Color.Black;
                        colorList.Add(fontColor);

                        //TextRenderer.DrawText(e.Graphics, webNo, fnt, new Point(0, yPos + 3), fontColor);
                        //TextRenderer.DrawText(e.Graphics, hours, fnt, new Point(rc.Width - TextRenderer.MeasureText(hours, fnt).Width - 3, yPos + 3), fontColor);
                    }
                    else
                    {
                        SolidBrush br = new SolidBrush(CommonFunctions.FromHex(Properties.Settings.Default.DefaultHeaderColor));
                        brushList.Add(br);
                        luminance = CommonFunctions.GetLuminance(br.Color.R, br.Color.G, br.Color.B);
                        if (luminance < 127.5)
                            fontColor = Color.White;
                        else
                            fontColor = Color.Black;
                        colorList.Add(fontColor);

                    }
                    yPos += 22;
                }
                yPos = 0;
                int iIndexer = 0;
                foreach (Rectangle rect in rectList)
                {
                    e.Graphics.FillRectangle(brushList[iIndexer], rect);
                    TextRenderer.DrawText(e.Graphics, taskList[iIndexer], fnt, new Point(0, yPos + 3), colorList[iIndexer]);
                    TextRenderer.DrawText(e.Graphics, hoursList[iIndexer], fnt, new Point(rect.Width - TextRenderer.MeasureText(hoursList[iIndexer], fnt).Width - 3, yPos + 3), colorList[iIndexer]);
                    yPos += 22;
                    iIndexer += 1;
                }
            }
            catch (Exception eex)
            {

            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            GetWeeklyTasks(sender, e);
            //DrawRectangles(sender, e);
        }

        private void DrawRectangles(object sender, PaintEventArgs e)
        {
            int yChange = 0;
            int iCount = 0;
            rectList = new List<Rectangle>();
            taskList = new List<string>();
            Font fnt = new Font("Segoe UI", 8.25f, FontStyle.Bold);
            for (int i = 0; i < 10; i++)
            {
                rectList.Add(new Rectangle(0, yChange, panel1.Width - 20, 20));
                taskList.Add(Convert.ToChar(i + 65).ToString());
                yChange += 22;
            }
            SolidBrush br = new SolidBrush(Color.White);
            yChange = 0;
            foreach (Rectangle rect in rectList)
            {
                iCount += 1;
                e.Graphics.DrawRectangle(Pens.Violet, rect);
                TextRenderer.DrawText(e.Graphics, iCount.ToString(), fnt, new Point(0, yChange + 3), Color.Black);
                yChange += 22;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            int iIndex = 0;
            foreach (Rectangle rect in rectList)
            {
                if (rect.Contains(e.Location))
                {
                    CommonFunctions.LoadItemsWithFilter(ref calendar1, taskList[iIndex]);
                    calendar1.Refresh();

                    //Rectangle r1 = new Rectangle(rect.X, rect.Y, panel1.Width - 20, 20);
                    //Graphics g = this.panel1.CreateGraphics();
                    //g.DrawRectangle(Pens.Red, r1);                    
                    //panel1.Refresh();
                }
                iIndex += 1;
            }
        }

        private void posodobiVJiriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (CalendarItem item in calendar1.GetSelectedItems())
            {
                CommonFunctions.UpdateJiraWorklog(item.JiraWorklogId);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                //Trackr.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
                e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void calendar1_ItemCreating(object sender, CalendarItemCancelEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetOutlookItems();
        }
    }
    public class ListViewItemComparer : IComparer
    {
        // Specifies the column to be sorted
        private int ColumnToSort;

        // Specifies the order in which to sort (i.e. 'Ascending').
        private System.Windows.Forms.SortOrder OrderOfSort;

        // Case insensitive comparer object
        private CaseInsensitiveComparer ObjectCompare;

        // Class constructor, initializes various elements
        public ListViewItemComparer()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = System.Windows.Forms.SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        // This method is inherited from the IComparer interface.
        // It compares the two objects passed using a case
        // insensitive comparison.
        //
        // x: First object to be compared
        // y: Second object to be compared
        //
        // The result of the comparison. "0" if equal,
        // negative if 'x' is less than 'y' and
        // positive if 'x' is greater than 'y'
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            try
            {
                // Parse the two objects passed as a parameter as a DateTime.
                System.DateTime firstDate =
                    DateTime.Parse(listviewX.SubItems[ColumnToSort].Text);
                System.DateTime secondDate =
                    DateTime.Parse(listviewY.SubItems[ColumnToSort].Text);

                // Compare the two dates.
                compareResult = DateTime.Compare(firstDate, secondDate);
            }
            catch
            {
                // Case insensitive Compare
                compareResult = ObjectCompare.Compare(
                    listviewX.SubItems[ColumnToSort].Text,
                    listviewY.SubItems[ColumnToSort].Text
                );
            }
            // Calculate correct return value based on object comparison
            if (OrderOfSort == System.Windows.Forms.SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == System.Windows.Forms.SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        // Gets or sets the number of the column to which to
        // apply the sorting operation (Defaults to '0').
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        // Gets or sets the order of sorting to apply
        // (for example, 'Ascending' or 'Descending').
        public System.Windows.Forms.SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
    }
}
