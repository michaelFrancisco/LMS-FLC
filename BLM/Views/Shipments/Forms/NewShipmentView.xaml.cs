using System.Windows;
using System.Windows.Controls;

namespace BLM.Views.Shipments.Forms
{
    /// <summary>
    /// Interaction logic for NewShipmentView.xaml
    /// </summary>
    public partial class NewShipmentView : Window
    {
        public NewShipmentView()
        {
            InitializeComponent();
        }

        private void itemGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header.ToString())
            {
                case "Category":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "Item_ID":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "Name1":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "ID":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void shipmentGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header.ToString())
            {
                case "Category":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "Item_ID":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "Name1":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
            }
        }
    }
}