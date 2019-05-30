using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace JiraBrowserWin
{
    public partial class Splash : Form
    {

        private delegate void CloseDelegate();
        private static Splash splashScreen;

        public Splash()
        {
            InitializeComponent();
            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;
        }

        static public void ShowOverlay()
        {
            // Make sure it is only launched once.

            if (splashScreen != null)
                return;
            Thread thread = new Thread(new ThreadStart(ShowForm));           
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        static private void ShowForm()
        {
            splashScreen = new Splash();
            Application.Run(splashScreen);
        }

        static public void CloseForm()
        {
            splashScreen.Invoke(new CloseDelegate(CloseFormInternal));
        }

        static private void CloseFormInternal()
        {
            splashScreen.timer1.Stop();
            splashScreen.Close();
            splashScreen = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
                timer1.Stop();
        }
    }
}
