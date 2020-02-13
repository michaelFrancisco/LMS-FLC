using System.Windows;
using System.Windows.Controls;

namespace BLM.Views.Inventory
{
    /// <summary>
    /// Interaction logic for InventoryView.xaml
    /// </summary>
    public partial class InventoryView : UserControl
    {
        public InventoryView()
        {
            InitializeComponent();
        }

        private void inventoryGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header.ToString())
            {
                case "Item_ID":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "Supplier_ID":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "Weight":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "Name":
                    DataGridLength width = new DataGridLength(1, DataGridLengthUnitType.Star);
                    e.Column.Width = width;
                    break;

                case "Critical_Level":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "rp_id":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "mo_id":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
            }
        }
    }
}