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

namespace BLM.Views.Inventory.Forms
{
    /// <summary>
    /// Interaction logic for RequestView.xaml
    /// </summary>
    public partial class RequestView : Window
    {
        public RequestView()
        {
            InitializeComponent();
        }

        private void itemsGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header.ToString())
            {
                case "Item Name":
                    DataGridLength width1 = new DataGridLength(1, DataGridLengthUnitType.Star);
                    e.Column.Width = width1;
                    break;
            }
        }

        private void materialsGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }
    }
}
