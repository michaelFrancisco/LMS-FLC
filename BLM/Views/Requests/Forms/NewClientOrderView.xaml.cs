using System.Windows;

namespace BLM.Views.Requests.Forms
{
    /// <summary>
    /// Interaction logic for NewClientOrderView.xaml
    /// </summary>
    public partial class NewClientOrderView : Window
    {
        public NewClientOrderView()
        {
            InitializeComponent();
        }
        private void DialogHost_DialogOpened(object sender, MaterialDesignThemes.Wpf.DialogOpenedEventArgs eventArgs)
        {
            if (itemGrid.SelectedItems.Count < 1)
            {
                dialogHost.IsOpen = false;
            }
        }
    }
}