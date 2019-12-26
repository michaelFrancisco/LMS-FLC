using BLM.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLM.ViewModels
{
    class LoginViewModel : Screen
    {
        private string _username;
        private string _password;
        private IWindowManager windowManager = new WindowManager();

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
                windowManager.ShowWindow(new MainViewModel(), null, null);
                TryClose();
            }
        }
    }
}
