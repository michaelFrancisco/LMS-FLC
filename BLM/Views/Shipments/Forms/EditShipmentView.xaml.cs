using System.Windows;
using System.Windows.Controls;

namespace BLM.Views.Shipments.Forms
{
    /// <summary>
    /// Interaction logic for EditShipmentView.xaml
    /// </summary>
    public partial class EditShipmentView : Window
    {
        public EditShipmentView()
        {
            InitializeComponent();
        }

        private void itemGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            DataGridLength width = new DataGridLength(1, DataGridLengthUnitType.Star);
            switch (e.Column.Header.ToString())
            {
                case "Shipment_Item_ID":
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

                case "Item_ID":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "ID1":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;


                case "Weight":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
            }
        }
    }
}