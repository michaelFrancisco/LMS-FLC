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

namespace BLM.Views.Production.Forms
{
    /// <summary>
    /// Interaction logic for NewProductionView.xaml
    /// </summary>
    public partial class NewProductionView : Window
    {
        public NewProductionView()
        {
            InitializeComponent();
        }

        private void txtQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void itemsGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //Set properties on the columns during auto-generation 
            //switch (e.Column.Header.ToString())
            //{
                
            //    case "ACTUAL":
            //        e.Column.Visibility = Visibility.Collapsed;
            //        break;  
            //    case "THEORETICAL":
            //        e.Column.Visibility = Visibility.Collapsed;
            //        break;
            //    case "PERCENT":
            //        e.Column.Visibility = Visibility.Collapsed;
            //        break;
            //    case "STATUS":
            //        e.Column.Visibility = Visibility.Collapsed;
            //        break;
            //    case "RFID":
            //        e.Column.Visibility = Visibility.Collapsed;
            //        break;
            //    case "product_name":
            //        e.Column.Visibility = Visibility.Collapsed;
            //        break;
            //}
        }

        private void receivedGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //Set properties on the columns during auto-generation 
            //switch (e.Column.Header.ToString())
            //{

            //    case "ACTUAL":
            //        e.Column.Visibility = Visibility.Collapsed;
            //        break;
            //    case "THEORETICAL":
            //        e.Column.Visibility = Visibility.Collapsed;
            //        break;
            //    case "PERCENT":
            //        e.Column.Visibility = Visibility.Collapsed;
            //        break;
            //    case "STATUS":
            //        e.Column.Visibility = Visibility.Collapsed;
            //        break;
            //    case "RFID":
            //        e.Column.Visibility = Visibility.Collapsed;
            //        break;
            //    case "product_name":
            //        e.Column.Visibility = Visibility.Collapsed;
            //        break;
            //}
        }
    }
}
