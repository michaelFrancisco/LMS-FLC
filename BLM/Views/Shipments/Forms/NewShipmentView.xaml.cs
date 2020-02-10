using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;

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
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LocationSelectorView win = new LocationSelectorView();
            win.Show();
        }
    }
}
