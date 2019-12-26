using System;
using System.Data;
using System.Media;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace BLM.Views.Logging
{
    /// <summary>
    /// Interaction logic for ReceivingView.xaml
    /// </summary>
    public partial class ReceivingView : System.Windows.Controls.UserControl
    {
        public ReceivingView()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch (Code.Text)
            {
                case "0457944240":
                    SystemSounds.Beep.Play();
                    ProdBatch.Text = "987654";
                    ProdCategory.Text = "Chemical";
                    ProdDate.Text = "2019-01-19 07:58:35";
                    ProdDesc.Text = "Ingredient for Bleach";
                    ProdID.Text = "00001";
                    ProdName.Text = "Hydrogen Peroxide";
                    ProdQuantity.Text = "10";
                    ProdSize.Text = "100ml";
                    Code.Text = String.Empty;
                    DataGridRow row = (DataGridRow)ordersGrid.ItemContainerGenerator.ContainerFromIndex(0);
                    row.Background = new SolidColorBrush(Colors.Green);
                    break;
                case "0246757330":
                    SystemSounds.Beep.Play();
                    ProdBatch.Text = "987654";
                    ProdCategory.Text = "Chemical";
                    ProdDate.Text = "2019-01-19 07:58:35";
                    ProdDesc.Text = "Ingredient for Bleach";
                    ProdID.Text = "00002";
                    ProdName.Text = "Sodium Perborate";
                    ProdQuantity.Text = "10";
                    ProdSize.Text = "100ml";
                    Code.Text = String.Empty;
                    row = (DataGridRow)ordersGrid.ItemContainerGenerator.ContainerFromIndex(1);
                    row.Background = new SolidColorBrush(Colors.Green);
                    break;
                case "0468081568":
                    SystemSounds.Beep.Play();
                    ProdBatch.Text = "987654";
                    ProdCategory.Text = "Chemical";
                    ProdDate.Text = "2019-01-19 07:58:35";
                    ProdDesc.Text = "Ingredient for Bleach";
                    ProdID.Text = "00002";
                    ProdName.Text = "Calcium Hypochlorite";
                    ProdQuantity.Text = "10";
                    ProdSize.Text = "100ml";
                    Code.Text = String.Empty;
                    row = (DataGridRow)ordersGrid.ItemContainerGenerator.ContainerFromIndex(2);
                    row.Background = new SolidColorBrush(Colors.Green);
                    break;
            }
        }
    }
}