using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace JiraBrowserWin
{
    public partial class JiraWorkLogEditor : Form
    {
        public JiraWorkLogEditor()
        {
            InitializeComponent();

            //CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings            
            //Cef.Initialize(settings);
            // Create a browser component

            // Add it to the form and fill it to the form window.
            //this.Controls.Add(chromeBrowser);
            //chromeBrowser.Dock = DockStyle.Fill;
            //chromeBrowser.Load("https://jira.adacta-group.com/secure/CreateWorklog!default.jspa?id=262291");            
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"C:\Chromedriver\");
            ChromeDriver cd = new ChromeDriver(service);
            CookieContainer cc = new CookieContainer();            
            cd.Url = @"https://jira.adacta-group.com";
            cd.Navigate();
            IWebElement e = cd.FindElementById("login-form-username");
            e.SendKeys("samob");
            e = cd.FindElementById("login-form-password");
            e.SendKeys("");
            e = cd.FindElement(By.XPath("//input[@class='button']"));
            e.Click();

            foreach (OpenQA.Selenium.Cookie c in cd.Manage().Cookies.AllCookies)
            {
                string name = c.Name;
                string value = c.Value;
                cc.Add(new System.Net.Cookie(name, value, c.Path, c.Domain));
            }
            ChromiumWebBrowser chromeBrowser = new ChromiumWebBrowser("https://jira.adacta-group.com");
            
            //Fire off the request
            /*
            HttpWebRequest hwr = (HttpWebRequest)HttpWebRequest.Create("https://fif.com/components/com_fif/tools/capacity/values/");
            hwr.CookieContainer = cc;
            hwr.Method = "POST";
            hwr.ContentType = "application/x-www-form-urlencoded";
            StreamWriter swr = new StreamWriter(hwr.GetRequestStream());
            swr.Write("feeds=35");
            swr.Close();

            WebResponse wr = hwr.GetResponse();
            string s = new System.IO.StreamReader(wr.GetResponseStream()).ReadToEnd();
            */
        }
    }
}
