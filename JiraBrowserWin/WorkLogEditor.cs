using JiraBrowserWin.JiraModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;

namespace JiraBrowserWin
{
    public partial class WorkLogEditor : Form
    {
        private string _description;
        private CalendarItem _citem;
        JiraClient _client;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public CalendarItem cItem
        {
            get { return _citem; }
            set { _citem = value; }
        }
        public WorkLogEditor()
        {
            InitializeComponent();
            if (CommonFunctions.commonIssuesRest != null)
            {
                //comboBox1.DataSource = CommonFunctions.commonIssuesRest.issues;
                //comboBox1.DisplayMember = "key";
                mtgcComboBox1.Items.Clear();
                MTGCComboBoxItem[] comboObjects = new MTGCComboBoxItem[CommonFunctions.commonIssuesRest.issues.Count];
                int iObjectCount = 0;
                foreach (Issue issue in CommonFunctions.commonIssuesRest.issues)
                {
                    comboObjects[iObjectCount] = new MTGCComboBoxItem(issue.key, issue.fields.summary);
                    iObjectCount += 1;
                }
                mtgcComboBox1.Items.AddRange(comboObjects);
            }
            if (CommonFunctions.commonFilter != null)
            {
                comboBox2.DataSource = CommonFunctions.commonFilter;                
            }
            textBox1.Text = _description;            
        }
        public WorkLogEditor(CalendarItem item, JiraClient client)
        {
            InitializeComponent();
            _citem = item;
            _client = client;
            if (string.IsNullOrWhiteSpace(item.webNo))
            {
                if (CommonFunctions.commonIssuesRest != null)
                {
                    //comboBox1.DataSource = CommonFunctions.commonIssuesRest.issues;
                    //comboBox1.SelectedText = "";
                    //comboBox1.DisplayMember = "key";
                    mtgcComboBox1.Items.Clear();
                    MTGCComboBoxItem[] comboObjects = new MTGCComboBoxItem[CommonFunctions.commonIssuesRest.issues.Count];
                    int iObjectCount = 0;
                    foreach (Issue issue in CommonFunctions.commonIssuesRest.issues)
                    {
                        comboObjects[iObjectCount] = new MTGCComboBoxItem(issue.key, issue.fields.summary);
                        iObjectCount += 1;
                    }
                    mtgcComboBox1.Items.AddRange(comboObjects);
                }
                if (CommonFunctions.commonFilter != null)
                {
                    comboBox2.DataSource = CommonFunctions.commonFilter;
                    comboBox2.DisplayMember = "name";
                }
                textBox1.Text = _description;
                cbox_Unchargeable.Checked = item.Unchargeable;
            }
            else
            {
                //comboBox1.SelectedText = item.webNo;
                //comboBox1.Text = item.webNo;
                cbox_Unchargeable.Checked = item.Unchargeable;
                mtgcComboBox1.SelectedText = item.webNo;
                mtgcComboBox1.Text = item.webNo;
            }
            //comboBox1.Refresh();
            mtgcComboBox1.Refresh();
            //_description = item.Text;
            textBox1.Text = item.Text;
            textBox2.Text = item.Description2;
            lbl_jiraTime.Text = item.jiraTime;
            cbox_Unchargeable.Checked = item.Unchargeable;            
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text))
                MessageBox.Show("Opis 1 je obvezen vnos!", "Napaka vnosa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                //CommonFunctions.UpdateDBEntry(textBox1.Text, comboBox1.Text, _citem.StartDate, _citem.EndDate, _citem.calendarId, _citem.jiraTime, cbox_Unchargeable.Checked, textBox2.Text);
                CommonFunctions.UpdateDBEntry(textBox1.Text, mtgcComboBox1.Text, _citem.StartDate, _citem.EndDate, _citem.calendarId, _citem.jiraTime, cbox_Unchargeable.Checked, textBox2.Text);
                this.Close();
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter1 selectedFilter = ((Filter1)comboBox2.SelectedItem);
            RefreshIssuesWithFilterREST(selectedFilter.id);
        }
        private void RefreshIssuesWithFilterREST(string filterId)
        {
            string jqlString = string.Empty;
            jqlString = "";
            Issues issues = _client.GetIssuesByJql(ResourceUrls.JqlSearchByFilterId(filterId), 1, 50, null);
            CommonFunctions.commonIssuesRest = issues;
            //comboBox1.DataSource = issues.issues;
            //comboBox1.DisplayMember = "key";
            //comboBox1.Update();
            mtgcComboBox1.Items.Clear();
            MTGCComboBoxItem[] comboObjects = new MTGCComboBoxItem[issues.issues.Count];
            int iObjectCount = 0;
            foreach (Issue issue in CommonFunctions.commonIssuesRest.issues)
            {
                comboObjects[iObjectCount] = new MTGCComboBoxItem(issue.key, issue.fields.summary);
                iObjectCount += 1;
            }
            mtgcComboBox1.Items.AddRange(comboObjects);
            mtgcComboBox1.Update();

            //CommonFunctions.GetRemoteProjectsREST();
        }

        private void mtgcComboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
                e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}
