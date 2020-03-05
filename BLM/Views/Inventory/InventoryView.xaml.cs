using CrystalDecisions.CrystalReports.Engine;
using System.IO;
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

        private void InventoryGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            DataGridLength width = new DataGridLength(2, DataGridLengthUnitType.Star);
            switch (e.Column.Header.ToString())
            {
                case "ID":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "ID1":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
                case "Supplier_ID":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

            }
        }
    }
}