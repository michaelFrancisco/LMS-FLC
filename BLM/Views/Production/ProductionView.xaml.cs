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

namespace BLM.Views.Production
{
    /// <summary>
    /// Interaction logic for ProductionView.xaml
    /// </summary>
    public partial class ProductionView : UserControl
    {
        public ProductionView()
        {
            InitializeComponent();
        }

        private void productionGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header.ToString())
            {
                case "id":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
                case "Name":
                    DataGridLength width = new DataGridLength(1, DataGridLengthUnitType.Star);
                    e.Column.Width = width;
                    break;
                case "inventory_Item_ID":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
            }
        }
    }
}
