using System.Windows;
using System.Windows.Controls;

namespace BLM.Views.Requests
{
    /// <summary>
    /// Interaction logic for RequestsView.xaml
    /// </summary>
    public partial class RequestsView : UserControl
    {
        public RequestsView()
        {
            InitializeComponent();
        }

        private void requestsGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            DataGridLength width = new DataGridLength(2, DataGridLengthUnitType.Star);
            switch (e.Column.Header.ToString())
            {
                case "ID":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "Supplier_ID":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "Category":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "Size":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "Unit":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "Weight":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "Critical_Level":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "id":
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