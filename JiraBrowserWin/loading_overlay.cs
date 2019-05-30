using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.Windows.Forms;

namespace JiraBrowserWin
{
    public partial class loading_overlay : Form
    {

        private readonly Color BackgroundFadeColor = Color.FromArgb(50, Color.Black);
        private Form BackgroundForm;

        private delegate void CloseDelegate();
        private static loading_overlay splashForm;


        public loading_overlay()
        {
            InitializeComponent();
        }

        public loading_overlay(Form frm)
        {
            InitializeComponent();
            BackgroundForm = frm;
            Size = frm.Size;
            Location = frm.Location;
            CaptureBackgroundForm();
            progressBar1.Left = (this.ClientSize.Width - progressBar1.Width) / 2;
            progressBar1.Top = (this.ClientSize.Height - progressBar1.Height) / 2;
            progressBar1.BackColor = CommonFunctions.FromHex(Properties.Settings.Default.DefaultHeaderColor);
            progressBar1.ForeColor = CommonFunctions.FromHex(Properties.Settings.Default.DefaultHeaderColor);
        }

        public static void ShowOverlay(Form frm)
        {
            // Make sure it is only launched once.

            if (splashForm != null)
                return;            
            Thread thread = new Thread(new ParameterizedThreadStart(ShowForm));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start(frm);
        }

        private static void ShowForm(object frm)
        {
            splashForm = new loading_overlay((Form)frm);
            Application.Run(splashForm);
        }

        public static void CloseForm()
        {
            if (splashForm != null)
            {
                try
                {
                    if (splashForm.InvokeRequired)
                      splashForm.Invoke(new CloseDelegate(CloseFormInternal));
                }
                catch (System.Exception w)
                {
                    MessageBox.Show(w.Message);
                    CloseFormInternal();
                }                 
            }           
        }

        private static void CloseFormInternal()
        {
            splashForm.timer1.Stop();            
            splashForm.Close();            
            splashForm = null;            
        }

        /// <summary>
        /// Paints the background form as the background of this form, if one is defined.
        /// </summary>
        public void CaptureBackgroundForm()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MethodInvoker(CaptureBackgroundForm));
                return;
            }

            if (this.BackgroundForm == null)
            {
                return;
            }


            //var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            var bmpScreenshot = new Bitmap(BackgroundForm.Bounds.Width, BackgroundForm.Bounds.Height, PixelFormat.Format32bppArgb);


            Graphics g = Graphics.FromImage(bmpScreenshot);

            try
            {
                // COPY BACKGROUND

                int x = this.BackgroundForm.Left;
                int y = this.BackgroundForm.Top;
                var size = this.BackgroundForm.Size;

                g.CopyFromScreen(x, y, 0, 0, size, CopyPixelOperation.SourceCopy);
                var rect = new Rectangle(0, 0, size.Width, size.Height);
                g.FillRectangle(new SolidBrush(BackgroundFadeColor), rect);

            }
            catch (Exception e)
            {
                g.Clear(Color.White);
            }
            this.BackgroundImage = bmpScreenshot;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                this.Close();
            }
        }


    }

}
