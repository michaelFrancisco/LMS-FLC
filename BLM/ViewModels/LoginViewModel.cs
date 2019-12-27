using BLM.Models;
using Caliburn.Micro;

namespace BLM.ViewModels
{
    internal class LoginViewModel : Screen
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