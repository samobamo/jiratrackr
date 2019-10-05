namespace JiraBrowserWin
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange1 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange2 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange3 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange4 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.Windows.Forms.Calendar.CalendarHighlightRange calendarHighlightRange5 = new System.Windows.Forms.Calendar.CalendarHighlightRange();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.counterLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.calendar1 = new System.Windows.Forms.Calendar.Calendar();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeToJiraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.potrdiSestanekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posodobiVJiriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.listView3 = new System.Windows.Forms.ListView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.jiraEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.data = new JiraBrowserWin.Data();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.monthView1 = new System.Windows.Forms.Calendar.MonthView();
            this.linkLabel8 = new System.Windows.Forms.LinkLabel();
            this.linkLabel9 = new System.Windows.Forms.LinkLabel();
            this.linkLabel10 = new System.Windows.Forms.LinkLabel();
            this.linkLabel11 = new System.Windows.Forms.LinkLabel();
            this.linkLabel12 = new System.Windows.Forms.LinkLabel();
            this.linkLabel13 = new System.Windows.Forms.LinkLabel();
            this.linkLabel14 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.linkLabel6 = new System.Windows.Forms.LinkLabel();
            this.linkLabel7 = new System.Windows.Forms.LinkLabel();
            this.btn_OlCal = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.EditBtn = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Trackr = new System.Windows.Forms.NotifyIcon(this.components);
            this.mtgcComboBox1 = new MTGCComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pieChart2 = new LiveCharts.WinForms.PieChart();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jiraEntryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // counterLabel
            // 
            this.counterLabel.AutoSize = true;
            this.counterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.counterLabel.Location = new System.Drawing.Point(820, 14);
            this.counterLabel.Name = "counterLabel";
            this.counterLabel.Size = new System.Drawing.Size(136, 63);
            this.counterLabel.TabIndex = 12;
            this.counterLabel.Text = "0:00";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(339, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(311, 22);
            this.textBox1.TabIndex = 14;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Location = new System.Drawing.Point(12, 85);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1036, 612);
            this.tabControl1.TabIndex = 19;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.listView1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1028, 586);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Taski";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new System.Drawing.Size(1022, 578);
            this.listView1.TabIndex = 26;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnWidthChanged += new System.Windows.Forms.ColumnWidthChangedEventHandler(this.listView1_ColumnWidthChanged);
            this.listView1.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listView1_DrawColumnHeader);
            this.listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView1_DrawItem);
            this.listView1.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listView1_DrawSubItem);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            this.listView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseMove);
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.calendar1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1028, 586);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Koledar";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // calendar1
            // 
            this.calendar1.AllowDrop = true;
            this.calendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calendar1.ContextMenuStrip = this.contextMenuStrip1;
            this.calendar1.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.calendar1.Font = new System.Drawing.Font("Segoe UI", 9F);
            calendarHighlightRange1.DayOfWeek = System.DayOfWeek.Monday;
            calendarHighlightRange1.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange1.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange2.DayOfWeek = System.DayOfWeek.Tuesday;
            calendarHighlightRange2.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange2.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange3.DayOfWeek = System.DayOfWeek.Wednesday;
            calendarHighlightRange3.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange3.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange4.DayOfWeek = System.DayOfWeek.Thursday;
            calendarHighlightRange4.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange4.StartTime = System.TimeSpan.Parse("08:00:00");
            calendarHighlightRange5.DayOfWeek = System.DayOfWeek.Friday;
            calendarHighlightRange5.EndTime = System.TimeSpan.Parse("17:00:00");
            calendarHighlightRange5.StartTime = System.TimeSpan.Parse("08:00:00");
            this.calendar1.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[] {
        calendarHighlightRange1,
        calendarHighlightRange2,
        calendarHighlightRange3,
        calendarHighlightRange4,
        calendarHighlightRange5};
            this.calendar1.Location = new System.Drawing.Point(6, 6);
            this.calendar1.Name = "calendar1";
            this.calendar1.Size = new System.Drawing.Size(1016, 576);
            this.calendar1.TabIndex = 0;
            this.calendar1.Text = "calendar1";
            this.calendar1.TimeScale = System.Windows.Forms.Calendar.CalendarTimeScale.FifteenMinutes;
            this.calendar1.ItemCreating += new System.Windows.Forms.Calendar.Calendar.CalendarItemCancelEventHandler(this.calendar1_ItemCreating);
            this.calendar1.ItemCreated += new System.Windows.Forms.Calendar.Calendar.CalendarItemCancelEventHandler(this.calendar1_ItemCreated);
            this.calendar1.ItemDeleting += new System.Windows.Forms.Calendar.Calendar.CalendarItemCancelEventHandler(this.calendar1_ItemDeleting);
            this.calendar1.ItemDatesChanged += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemDatesChanged);
            this.calendar1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.calendar1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.testToolStripMenuItem,
            this.toolStripMenuItem1,
            this.deleteToolStripMenuItem,
            this.writeToJiraToolStripMenuItem,
            this.potrdiSestanekToolStripMenuItem,
            this.posodobiVJiriToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 158);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening_1);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem2.Text = "Nadaljuj";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.testToolStripMenuItem.Text = "Uredi";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click_1);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.toolStripMenuItem1.Text = "Odpri v Jiri";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.deleteToolStripMenuItem.Text = "Briši";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // writeToJiraToolStripMenuItem
            // 
            this.writeToJiraToolStripMenuItem.Name = "writeToJiraToolStripMenuItem";
            this.writeToJiraToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.writeToJiraToolStripMenuItem.Text = "Piši v Jiro";
            this.writeToJiraToolStripMenuItem.Click += new System.EventHandler(this.writeToJiraToolStripMenuItem_Click);
            // 
            // potrdiSestanekToolStripMenuItem
            // 
            this.potrdiSestanekToolStripMenuItem.Name = "potrdiSestanekToolStripMenuItem";
            this.potrdiSestanekToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.potrdiSestanekToolStripMenuItem.Text = "Potrdi sestanek";
            this.potrdiSestanekToolStripMenuItem.Visible = false;
            this.potrdiSestanekToolStripMenuItem.Click += new System.EventHandler(this.potrdiSestanekToolStripMenuItem_Click);
            // 
            // posodobiVJiriToolStripMenuItem
            // 
            this.posodobiVJiriToolStripMenuItem.Name = "posodobiVJiriToolStripMenuItem";
            this.posodobiVJiriToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.posodobiVJiriToolStripMenuItem.Text = "Posodobi v Jiri";
            this.posodobiVJiriToolStripMenuItem.Visible = false;
            this.posodobiVJiriToolStripMenuItem.Click += new System.EventHandler(this.posodobiVJiriToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1028, 586);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Jira";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listView2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1028, 586);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Vnosi";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listView2
            // 
            this.listView2.AllowColumnReorder = true;
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.LabelEdit = true;
            this.listView2.Location = new System.Drawing.Point(3, 3);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1022, 578);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView2_ColumnClick);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.listView3);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1028, 586);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Inbox";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // listView3
            // 
            this.listView3.GridLines = true;
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(3, 3);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(471, 580);
            this.listView3.TabIndex = 0;
            this.listView3.UseCompatibleStateImageBehavior = false;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.pieChart2);
            this.tabPage6.Controls.Add(this.pieChart1);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1028, 586);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Analize";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // pieChart1
            // 
            this.pieChart1.Location = new System.Drawing.Point(18, 17);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(346, 346);
            this.pieChart1.TabIndex = 0;
            this.pieChart1.Text = "pieChart1";
            // 
            // jiraEntryBindingSource
            // 
            this.jiraEntryBindingSource.DataMember = "JiraEntry";
            this.jiraEntryBindingSource.DataSource = this.data;
            // 
            // data
            // 
            this.data.DataSetName = "Data";
            this.data.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(339, 14);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(311, 21);
            this.comboBox2.TabIndex = 23;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // monthView1
            // 
            this.monthView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.monthView1.ArrowsColor = System.Drawing.SystemColors.Window;
            this.monthView1.ArrowsSelectedColor = System.Drawing.Color.Gold;
            this.monthView1.DayBackgroundColor = System.Drawing.Color.Empty;
            this.monthView1.DayGrayedText = System.Drawing.SystemColors.GrayText;
            this.monthView1.DaySelectedBackgroundColor = System.Drawing.SystemColors.Highlight;
            this.monthView1.DaySelectedColor = System.Drawing.SystemColors.WindowText;
            this.monthView1.DaySelectedTextColor = System.Drawing.SystemColors.HighlightText;
            this.monthView1.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.monthView1.ItemPadding = new System.Windows.Forms.Padding(2);
            this.monthView1.Location = new System.Drawing.Point(1050, 107);
            this.monthView1.MonthTitleColor = System.Drawing.SystemColors.ActiveCaption;
            this.monthView1.MonthTitleColorInactive = System.Drawing.SystemColors.InactiveCaption;
            this.monthView1.MonthTitleTextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.monthView1.MonthTitleTextColorInactive = System.Drawing.SystemColors.InactiveCaptionText;
            this.monthView1.Name = "monthView1";
            this.monthView1.Size = new System.Drawing.Size(192, 160);
            this.monthView1.TabIndex = 21;
            this.monthView1.Text = "monthView1";
            this.monthView1.TodayBorderColor = System.Drawing.Color.Red;
            this.monthView1.SelectionChanged += new System.EventHandler(this.monthView1_SelectionChanged);
            // 
            // linkLabel8
            // 
            this.linkLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel8.AutoSize = true;
            this.linkLabel8.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel8.LinkColor = System.Drawing.Color.Black;
            this.linkLabel8.Location = new System.Drawing.Point(1054, 288);
            this.linkLabel8.Name = "linkLabel8";
            this.linkLabel8.Size = new System.Drawing.Size(59, 13);
            this.linkLabel8.TabIndex = 32;
            this.linkLabel8.TabStop = true;
            this.linkLabel8.Text = "linkLabel8";
            this.linkLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel9
            // 
            this.linkLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel9.AutoSize = true;
            this.linkLabel9.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel9.LinkColor = System.Drawing.Color.Black;
            this.linkLabel9.Location = new System.Drawing.Point(1054, 314);
            this.linkLabel9.Name = "linkLabel9";
            this.linkLabel9.Size = new System.Drawing.Size(59, 13);
            this.linkLabel9.TabIndex = 33;
            this.linkLabel9.TabStop = true;
            this.linkLabel9.Text = "linkLabel9";
            this.linkLabel9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel10
            // 
            this.linkLabel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel10.AutoSize = true;
            this.linkLabel10.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel10.LinkColor = System.Drawing.Color.Black;
            this.linkLabel10.Location = new System.Drawing.Point(1054, 340);
            this.linkLabel10.Name = "linkLabel10";
            this.linkLabel10.Size = new System.Drawing.Size(65, 13);
            this.linkLabel10.TabIndex = 34;
            this.linkLabel10.TabStop = true;
            this.linkLabel10.Text = "linkLabel10";
            this.linkLabel10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel11
            // 
            this.linkLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel11.AutoSize = true;
            this.linkLabel11.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel11.LinkColor = System.Drawing.Color.Black;
            this.linkLabel11.Location = new System.Drawing.Point(1054, 366);
            this.linkLabel11.Name = "linkLabel11";
            this.linkLabel11.Size = new System.Drawing.Size(65, 13);
            this.linkLabel11.TabIndex = 35;
            this.linkLabel11.TabStop = true;
            this.linkLabel11.Text = "linkLabel11";
            this.linkLabel11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel12
            // 
            this.linkLabel12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel12.AutoSize = true;
            this.linkLabel12.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel12.LinkColor = System.Drawing.Color.Black;
            this.linkLabel12.Location = new System.Drawing.Point(1054, 392);
            this.linkLabel12.Name = "linkLabel12";
            this.linkLabel12.Size = new System.Drawing.Size(65, 13);
            this.linkLabel12.TabIndex = 36;
            this.linkLabel12.TabStop = true;
            this.linkLabel12.Text = "linkLabel12";
            this.linkLabel12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel13
            // 
            this.linkLabel13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel13.AutoSize = true;
            this.linkLabel13.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel13.LinkColor = System.Drawing.Color.Black;
            this.linkLabel13.Location = new System.Drawing.Point(1054, 418);
            this.linkLabel13.Name = "linkLabel13";
            this.linkLabel13.Size = new System.Drawing.Size(65, 13);
            this.linkLabel13.TabIndex = 37;
            this.linkLabel13.TabStop = true;
            this.linkLabel13.Text = "linkLabel13";
            this.linkLabel13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel14
            // 
            this.linkLabel14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel14.AutoSize = true;
            this.linkLabel14.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel14.LinkColor = System.Drawing.Color.Black;
            this.linkLabel14.Location = new System.Drawing.Point(1054, 444);
            this.linkLabel14.Name = "linkLabel14";
            this.linkLabel14.Size = new System.Drawing.Size(65, 13);
            this.linkLabel14.TabIndex = 38;
            this.linkLabel14.TabStop = true;
            this.linkLabel14.Text = "linkLabel14";
            this.linkLabel14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Black;
            this.linkLabel1.Location = new System.Drawing.Point(1183, 444);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(59, 13);
            this.linkLabel1.TabIndex = 46;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // linkLabel2
            // 
            this.linkLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkLabel2.LinkColor = System.Drawing.Color.Black;
            this.linkLabel2.Location = new System.Drawing.Point(1183, 418);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(59, 13);
            this.linkLabel2.TabIndex = 45;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "linkLabel2";
            this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // linkLabel3
            // 
            this.linkLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkLabel3.LinkColor = System.Drawing.Color.Black;
            this.linkLabel3.Location = new System.Drawing.Point(1183, 392);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(59, 13);
            this.linkLabel3.TabIndex = 44;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "linkLabel3";
            this.linkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // linkLabel4
            // 
            this.linkLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkLabel4.LinkColor = System.Drawing.Color.Black;
            this.linkLabel4.Location = new System.Drawing.Point(1183, 366);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(59, 13);
            this.linkLabel4.TabIndex = 43;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "linkLabel4";
            this.linkLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // linkLabel5
            // 
            this.linkLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkLabel5.LinkColor = System.Drawing.Color.Black;
            this.linkLabel5.Location = new System.Drawing.Point(1183, 340);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(59, 13);
            this.linkLabel5.TabIndex = 42;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = "linkLabel5";
            this.linkLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // linkLabel6
            // 
            this.linkLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkLabel6.LinkColor = System.Drawing.Color.Black;
            this.linkLabel6.Location = new System.Drawing.Point(1183, 314);
            this.linkLabel6.Name = "linkLabel6";
            this.linkLabel6.Size = new System.Drawing.Size(59, 13);
            this.linkLabel6.TabIndex = 41;
            this.linkLabel6.TabStop = true;
            this.linkLabel6.Text = "linkLabel6";
            this.linkLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // linkLabel7
            // 
            this.linkLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.linkLabel7.LinkColor = System.Drawing.Color.Black;
            this.linkLabel7.Location = new System.Drawing.Point(1183, 288);
            this.linkLabel7.Name = "linkLabel7";
            this.linkLabel7.Size = new System.Drawing.Size(59, 13);
            this.linkLabel7.TabIndex = 40;
            this.linkLabel7.TabStop = true;
            this.linkLabel7.Text = "linkLabel7";
            this.linkLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_OlCal
            // 
            this.btn_OlCal.Enabled = false;
            this.btn_OlCal.Image = global::JiraBrowserWin.Properties.Resources.Calendar_32;
            this.btn_OlCal.Location = new System.Drawing.Point(174, 14);
            this.btn_OlCal.Name = "btn_OlCal";
            this.btn_OlCal.Size = new System.Drawing.Size(75, 65);
            this.btn_OlCal.TabIndex = 24;
            this.btn_OlCal.Text = "Outlook";
            this.btn_OlCal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_OlCal.UseVisualStyleBackColor = true;
            this.btn_OlCal.Click += new System.EventHandler(this.btn_OlCal_Click);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_save.Image = global::JiraBrowserWin.Properties.Resources.Save_32;
            this.btn_save.Location = new System.Drawing.Point(93, 14);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 65);
            this.btn_save.TabIndex = 18;
            this.btn_save.Text = "Shrani v Jiro";
            this.btn_save.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // EditBtn
            // 
            this.EditBtn.Image = global::JiraBrowserWin.Properties.Resources.Settings_32;
            this.EditBtn.Location = new System.Drawing.Point(255, 14);
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.Size = new System.Drawing.Size(75, 65);
            this.EditBtn.TabIndex = 15;
            this.EditBtn.Text = "Nastavitve";
            this.EditBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.EditBtn.UseVisualStyleBackColor = true;
            this.EditBtn.Click += new System.EventHandler(this.EditBtn_Click);
            // 
            // button5
            // 
            this.button5.Image = global::JiraBrowserWin.Properties.Resources.Stop_32;
            this.button5.Location = new System.Drawing.Point(739, 14);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 65);
            this.button5.TabIndex = 11;
            this.button5.Text = "Stop";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Image = global::JiraBrowserWin.Properties.Resources.Play_32;
            this.button4.Location = new System.Drawing.Point(658, 14);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 65);
            this.button4.TabIndex = 10;
            this.button4.Text = "Start";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::JiraBrowserWin.Properties.Resources.Refresh_32;
            this.btnRefresh.Location = new System.Drawing.Point(12, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 65);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Osveži";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btn_Refresh);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(1057, 469);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 219);
            this.panel1.TabIndex = 47;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // Trackr
            // 
            this.Trackr.Icon = ((System.Drawing.Icon)(resources.GetObject("Trackr.Icon")));
            this.Trackr.Text = "Trackr";
            this.Trackr.Visible = true;
            this.Trackr.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // mtgcComboBox1
            // 
            this.mtgcComboBox1.ArrowBoxColor = System.Drawing.SystemColors.Control;
            this.mtgcComboBox1.ArrowColor = System.Drawing.Color.Black;
            this.mtgcComboBox1.BindedControl = ((MTGCComboBox.ControlloAssociato)(resources.GetObject("mtgcComboBox1.BindedControl")));
            this.mtgcComboBox1.BorderStyle = MTGCComboBox.TipiBordi.System;
            this.mtgcComboBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.mtgcComboBox1.ColumnNum = 2;
            this.mtgcComboBox1.ColumnWidth = "120;120";
            this.mtgcComboBox1.DisabledArrowBoxColor = System.Drawing.SystemColors.Control;
            this.mtgcComboBox1.DisabledArrowColor = System.Drawing.Color.LightGray;
            this.mtgcComboBox1.DisabledBackColor = System.Drawing.SystemColors.Control;
            this.mtgcComboBox1.DisabledBorderColor = System.Drawing.SystemColors.InactiveBorder;
            this.mtgcComboBox1.DisabledForeColor = System.Drawing.SystemColors.GrayText;
            this.mtgcComboBox1.DisplayMember = "Text";
            this.mtgcComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.mtgcComboBox1.DropDownArrowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(169)))), ((int)(((byte)(223)))));
            this.mtgcComboBox1.DropDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(210)))), ((int)(((byte)(238)))));
            this.mtgcComboBox1.DropDownForeColor = System.Drawing.Color.Black;
            this.mtgcComboBox1.DropDownStyle = MTGCComboBox.CustomDropDownStyle.DropDown;
            this.mtgcComboBox1.DropDownWidth = 380;
            this.mtgcComboBox1.GridLineColor = System.Drawing.Color.LightGray;
            this.mtgcComboBox1.GridLineHorizontal = false;
            this.mtgcComboBox1.GridLineVertical = false;
            this.mtgcComboBox1.HighlightBorderColor = System.Drawing.Color.Blue;
            this.mtgcComboBox1.HighlightBorderOnMouseEvents = true;
            this.mtgcComboBox1.LoadingType = MTGCComboBox.CaricamentoCombo.ComboBoxItem;
            this.mtgcComboBox1.Location = new System.Drawing.Point(339, 35);
            this.mtgcComboBox1.ManagingFastMouseMoving = true;
            this.mtgcComboBox1.ManagingFastMouseMovingInterval = 30;
            this.mtgcComboBox1.Name = "mtgcComboBox1";
            this.mtgcComboBox1.NormalBorderColor = System.Drawing.Color.Black;
            this.mtgcComboBox1.SelectedItem = null;
            this.mtgcComboBox1.SelectedValue = null;
            this.mtgcComboBox1.Size = new System.Drawing.Size(311, 23);
            this.mtgcComboBox1.TabIndex = 48;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1057, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pieChart2
            // 
            this.pieChart2.Location = new System.Drawing.Point(502, 17);
            this.pieChart2.Name = "pieChart2";
            this.pieChart2.Size = new System.Drawing.Size(383, 360);
            this.pieChart2.TabIndex = 1;
            this.pieChart2.Text = "pieChart2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1258, 709);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mtgcComboBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel4);
            this.Controls.Add(this.linkLabel5);
            this.Controls.Add(this.linkLabel6);
            this.Controls.Add(this.linkLabel7);
            this.Controls.Add(this.linkLabel14);
            this.Controls.Add(this.linkLabel13);
            this.Controls.Add(this.linkLabel12);
            this.Controls.Add(this.linkLabel11);
            this.Controls.Add(this.linkLabel10);
            this.Controls.Add(this.linkLabel9);
            this.Controls.Add(this.linkLabel8);
            this.Controls.Add(this.btn_OlCal);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.monthView1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.EditBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.counterLabel);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnRefresh);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Trackr";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jiraEntryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label counterLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Calendar.Calendar calendar1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeToJiraToolStripMenuItem;
        private System.Windows.Forms.Calendar.MonthView monthView1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button btn_OlCal;
        private System.Windows.Forms.ToolStripMenuItem potrdiSestanekToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.LinkLabel linkLabel8;
        private System.Windows.Forms.LinkLabel linkLabel9;
        private System.Windows.Forms.LinkLabel linkLabel10;
        private System.Windows.Forms.LinkLabel linkLabel11;
        private System.Windows.Forms.LinkLabel linkLabel12;
        private System.Windows.Forms.LinkLabel linkLabel13;
        private System.Windows.Forms.LinkLabel linkLabel14;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.LinkLabel linkLabel6;
        private System.Windows.Forms.LinkLabel linkLabel7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem posodobiVJiriToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon Trackr;
        private MTGCComboBox mtgcComboBox1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage6;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.BindingSource jiraEntryBindingSource;
        private Data data;
        private LiveCharts.WinForms.PieChart pieChart2;
    }
}

