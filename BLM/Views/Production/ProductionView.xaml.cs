using BLM.ViewModels.Production;
using System;
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

        private void Sample1_DialogHost_OnDialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
            if (!Equals(eventArgs.Parameter, true)) return;
            if (productionGrid.SelectedItems.Count > 0)
            {
                ProductionViewModel.DialogHost_OnDialogClosing(Int32.Parse(txtActualYield.Text), productionGrid.SelectedItem);
            }
            else
            {
                MessageBox.Show("No item selected");
            }
        }
    }
}