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

namespace BLM.Views.CreateOrder
{
    /// <summary>
    /// Interaction logic for CreateDepartingOrderView.xaml
    /// </summary>
    public partial class CreateDepartingOrderView : UserControl
    {
        public CreateDepartingOrderView()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if(manualInput.IsChecked.Value)
            {
                destination.IsEnabled = true;
            }
            else
            {
                destination.IsEnabled = false;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (client.Text == "SM Fairview")
            {
                destination.Text = "Quirino Highway corner Regalado Avenue, Novaliches, Quezon City, Philippines";
            }
            else if (client.Text == "SM North")
            {
                destination.Text = "North Avenue corner EDSA, Quezon City, 1100 Metro Manila";
            }
            else if (client.Text == "SM Novaliches")
            {
                destination.Text = "Quirino Highway, Brgy. San Bartolome, Novaliches, Quezon City, Philippines";
            }
        }
    }
}
