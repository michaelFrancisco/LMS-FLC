using BLM.Models;
using Caliburn.Micro;
using System.Data;

namespace BLM.ViewModels
{
    internal class LoginViewModel : Screen
    {
        private string _username;
        private string _password;
        private readonly IWindowManager windowManager = new WindowManager();

        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        public void login()
        {
            if (Connection.verifyLogin(_username, _password))
            {
                getUserCredentials();
                windowManager.ShowWindow(new MainViewModel(), null, null);
                TryClose();
            }
        }

        public void loginasadmin()
        {
            DataTable dt = Connection.dbTable("select ID,Name, User_Level from users where Username = 'admin' AND Password = 'admin';");
            CurrentUser.name = dt.Rows[0][1].ToString();
            CurrentUser.user_level = dt.Rows[0][2].ToString();
            CurrentUser.User_ID = dt.Rows[0][0].ToString();
            windowManager.ShowWindow(new MainViewModel(), null, null);
            TryClose();
        }

        public void getUserCredentials()
        {
            DataTable dt = Connection.dbTable("select ID,Name, User_Level from users where Username = '" + _username + "' AND Password = '" + _password + "';");
            CurrentUser.name = dt.Rows[0][1].ToString();
            CurrentUser.user_level = dt.Rows[0][2].ToString();
            CurrentUser.User_ID = dt.Rows[0][0].ToString();
        }
    }
}