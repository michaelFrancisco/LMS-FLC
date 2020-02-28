using BLM.Models;
using BLM.ViewModels;
using Caliburn.Micro;
using System.Data;
using System.Windows;

namespace BLM.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private readonly IWindowManager windowManager = new WindowManager();

        public LoginView()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            if (Connection.verifyLogin(username.Text, password.Password))
            {
                getUserCredentials();
                windowManager.ShowWindow(new MainViewModel(), null, null);
                this.Close();
            }
        }

        public void getUserCredentials()
        {
            DataTable dt = Connection.dbTable("select ID,Name, User_Level from users where Username = '" + username.Text + "' AND Password = '" + password.Password + "';");
            CurrentUser.name = dt.Rows[0][1].ToString();
            CurrentUser.user_level = dt.Rows[0][2].ToString();
            CurrentUser.User_ID = dt.Rows[0][0].ToString();
        }
    }
}