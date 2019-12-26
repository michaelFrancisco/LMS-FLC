using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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

namespace BLM.Views.Logging
{
    /// <summary>
    /// Interaction logic for DepartureView.xaml
    /// </summary>
    public partial class DepartureView : UserControl
    {
        public DepartureView()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SystemSounds.Beep.Play();
            ProdBatch.Text = "45678";
            ProdCategory.Text = "Soap";
            ProdDate.Text = "10/12/2019";
            ProdDesc.Text = "Lemon Scented Dishwashing Liquid";
            ProdID.Text = "69420";
            ProdName.Text = "BONUS Dishwashing Liquid";
            ProdQuantity.Text = "10";
            ProdSize.Text = "500ml";
            ProductImage.Source = new BitmapImage(new Uri(@"C:\Users\Michael C. Francisco\Source\Repos\michaelFrancisco\BLM\BLM\BLM\Resources\k6ofa6ec.bmp"));
        }
    }
}
