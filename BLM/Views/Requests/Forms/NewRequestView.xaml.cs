using System.Windows;
using System.Windows.Controls;

namespace BLM.Views.Requests.Forms
{
    /// <summary>
    /// Interaction logic for NewRequestView.xaml
    /// </summary>
    public partial class NewRequestView : Window
    {
        public NewRequestView()
        {
            InitializeComponent();
        }

        private void materialsGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header.ToString())
            {
                case "ID":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
            }
        }
    }
}