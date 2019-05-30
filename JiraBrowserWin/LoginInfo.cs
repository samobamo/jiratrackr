using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JiraBrowserWin
{
    class LoginInfo
    {
        private static string _txUserName;
        private static string _txPassword;
        private static string _txToken;
        private static string _jUrl;
        
        public static string txUserName
        {
            get { return _txUserName; }
            set { _txUserName = value; }
        }
        public static string txPassword
        {
            get { return _txPassword; }
            set { _txPassword = value; }
        }
        public static string token
        {
            get { return _txToken; }
            set { _txToken = value; }
        }
        public static string jUrl
        {
            get { return _jUrl; }
            set { _jUrl = value; }
        }    

        public static JiraClient LoginRest()
        {
            var client = new JiraClient(new JiraAccount
            {
                ServerUrl = _jUrl,
                User = _txUserName,
                Password = _txPassword
            });
            return client;
        }         
    }
}
