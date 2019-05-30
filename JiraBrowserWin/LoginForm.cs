using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JiraBrowserWin
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }        

        private void button1_Click(object sender, EventArgs e)
        {
            LoginInfo.txUserName = textBox1.Text;
            LoginInfo.txPassword = textBox2.Text;
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.Username = textBox1.Text;
                Properties.Settings.Default.Secret = CommonFunctions.EncryptString(CommonFunctions.ToSecureString(textBox2.Text));
                Properties.Settings.Default.Autologin = true;
            }
            this.Close();
        }  
    }
}
