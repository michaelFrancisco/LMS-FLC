using BLM.Models;
using Caliburn.Micro;
using System.Data;

namespace BLM.ViewModels
{
    internal class LoginViewModel : Screen
    {
        private readonly IWindowManager windowManager = new WindowManager();

        public void loginasadmin()
        {
            DataTable dt = Connection.dbTable("select ID,Name, User_Level from users where Username = 'admin' AND Password = 'admin';");
            CurrentUser.name = dt.Rows[0][1].ToString();
            CurrentUser.user_level = dt.Rows[0][2].ToString();
            CurrentUser.User_ID = dt.Rows[0][0].ToString();
            windowManager.ShowWindow(new MainViewModel(), null, null);
            TryClose();
        }

        public void test()
        {
            windowManager.ShowWindow(new TestViewModel(), null, null);
            TryClose();
        }
    }
}