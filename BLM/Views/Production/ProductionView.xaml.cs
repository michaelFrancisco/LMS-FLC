using System.Windows;
using System.Windows.Controls;

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
                case "ID":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;

                case "inventory_Item_ID":
                    e.Column.Visibility = Visibility.Collapsed;
                    break;
            }
        }
    }
}