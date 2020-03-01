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
            DataGridLength width = new DataGridLength(1, DataGridLengthUnitType.Star);

            switch (e.Column.Header.ToString())
            {
                case "ID":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "Supplier Name":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "Email":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "Name":
                    width = new DataGridLength(1, DataGridLengthUnitType.Star);
                    e.Column.Width = width;
                    break;
            }
        }
    }
}