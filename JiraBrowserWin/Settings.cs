using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Linq;

namespace JiraBrowserWin
{
    public partial class Settings : Form
    {
        private SQLiteConnection _sqlConn;
        private DataSet ds;
        private SQLiteDataAdapter da;
        private DataTable dt;
        private string _secret;        
        public SQLiteConnection sqlConn
        {
            get { return _sqlConn; }
            set { _sqlConn = sqlConn; }
        }  

        public Settings(SQLiteConnection sqlConn)
        {
            InitializeComponent();

            textBox1.Text = Properties.Settings.Default.RESTurl;
            textBox2.Text = Properties.Settings.Default.DBLocation;
            textBox3.Text = Properties.Settings.Default.Username;
            _secret = CommonFunctions.ToInsecureString(CommonFunctions.DecryptString(Properties.Settings.Default.Secret));
            textBox4.Text = _secret;
            checkBox1.Checked = Properties.Settings.Default.Autologin;
            checkBox3.Checked = Properties.Settings.Default.ShowWeeklyHours;
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.DefaultHeaderColor))
                button2.BackColor = CommonFunctions.FromHex(Properties.Settings.Default.DefaultHeaderColor);

            listView1.Columns.Add("Projekt", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Ključ", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Opis", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("Barva", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Filter", 100, HorizontalAlignment.Left);
            FillData(sqlConn);

            var source = new AutoCompleteStringCollection();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        source.Add(dr["ProjectKey"].ToString());
                    }
                }

                textBox5.AutoCompleteCustomSource = source;
                textBox5.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBox5.AutoCompleteMode = AutoCompleteMode.Suggest;
            }
            catch (Exception e)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Database Files|*.db";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBox2.Text = openFileDialog1.FileName;
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.RESTurl = textBox1.Text;
            Properties.Settings.Default.DBLocation = textBox2.Text;
            Properties.Settings.Default.Username = textBox3.Text;
            Properties.Settings.Default.Secret = CommonFunctions.EncryptString(CommonFunctions.ToSecureString(_secret));
            Properties.Settings.Default.Autologin = checkBox1.Checked;
            Properties.Settings.Default.ShowWeeklyHours = checkBox3.Checked;
            Properties.Settings.Default.DefaultHeaderColor = CommonFunctions.ToHex(button2.BackColor);
            Properties.Settings.Default.Save();    
        }

        private void ShowColorPicker(object sender, EventArgs e)
        {
            Point mousePosition = listView1.PointToClient(Control.MousePosition);
            ListViewHitTestInfo hit = listView1.HitTest(mousePosition);
            int columnindex = hit.Item.SubItems.IndexOf(hit.SubItem);
            if (columnindex == 3)
            {

                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (listView1.SelectedItems.Count == 1)
                    {
                        ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
                        ListViewItem lvItem = listView1.SelectedItems[0];
                        lvItem.SubItems[3].BackColor = colorDialog1.Color;
                        lvItem.SubItems[3].Text = CommonFunctions.ToHex(colorDialog1.Color);
                        lvItem.Selected = false;                        
                        listView1.Refresh();
                        FromListView(dt, listView1);
                    }
                }
                else
                {
                    ListView.SelectedListViewItemCollection items = listView1.SelectedItems;
                    ListViewItem lvItem = listView1.SelectedItems[0];
                    lvItem.Selected = false;
                }
            }
        }

        private static void FromListView(DataTable table, ListView lvw)
        {
            table.Clear();
            var columns = lvw.Columns.Count;
        
            foreach (ListViewItem item in lvw.Items)
            {
                CommonFunctions.UpdateJiraProjectEntry(item.SubItems[1].Text, item.SubItems[3].Text);               
            }
        }

        internal void FillData(SQLiteConnection sqlConn1)
        {
            string command = "Select * From JiraProjects";
            da = new SQLiteDataAdapter(command, sqlConn1);
            ds = new DataSet();
            SQLiteCommandBuilder commandBuilder = new SQLiteCommandBuilder(da);
            try
            {
                da.Fill(ds, "JiraProjects");
                dt = ds.Tables["JiraProjects"];
                listView1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        ListViewItem lvi = new ListViewItem(dr["Project"].ToString());
                        lvi.SubItems.Add(dr["ProjectKey"].ToString());
                        lvi.SubItems.Add(dr["Opis"].ToString());
                        lvi.SubItems.Add(dr["ColorCode"].ToString());
                        lvi.SubItems.Add(dr["Filter"].ToString());
                        if (dr["colorCode"].ToString() != "")
                            lvi.SubItems[3].BackColor = CommonFunctions.FromHex(dr["ColorCode"].ToString());
                        lvi.UseItemStyleForSubItems = false;
                        listView1.Items.Add(lvi);
                    }
                }
            }
            catch (Exception e)
            {

            }
        }      

        private void textBox4_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox4.Text))
              _secret = textBox4.Text;
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {            
            textBox4.UseSystemPasswordChar = !checkBox2.Checked;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            AddItems();            
        }
        private void AddItems()
        {
            listView1.Items.Clear(); 
            foreach (DataRow row in dt.Rows)
            {
                if ((row["ProjectKey"].ToString().Contains(textBox5.Text)) || (row["Project"].ToString().Contains(textBox5.Text)))
                {
                    ListViewItem lvi = new ListViewItem(row["Project"].ToString());
                    lvi.SubItems.Add(row["ProjectKey"].ToString());
                    lvi.SubItems.Add(row["Opis"].ToString());
                    lvi.SubItems.Add(row["ColorCode"].ToString());
                    lvi.SubItems.Add(row["Filter"].ToString());
                    if (row["colorCode"].ToString() != "")
                        lvi.SubItems[3].BackColor = CommonFunctions.FromHex(row["ColorCode"].ToString());
                    lvi.UseItemStyleForSubItems = false;
                    listView1.Items.Add(lvi);
                }
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button2.BackColor = colorDialog1.Color;
                //lvItem.SubItems[3].Text = CommonFunctions.ToHex(colorDialog1.Color);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
