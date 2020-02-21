using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace BLM.Views.Inventory
{
    /// <summary>
    /// Interaction logic for InventoryView.xaml
    /// </summary>
    public partial class InventoryView : UserControl
    {
        public InventoryView()
        {
            InitializeComponent();

        }



        private void inventoryGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //switch (e.Column.Header.ToString())
            //{
            //    case "Item_ID":
            //        e.Column.Visibility = Visibility.Collapsed;
            //        break;

            //    case "Supplier_ID":
            //        e.Column.Visibility = Visibility.Collapsed;
            //        break;

            //    case "Weight":
            //        e.Column.Visibility = Visibility.Collapsed;
            //        break;

            //    case "Name":
            //        DataGridLength width = new DataGridLength(1, DataGridLengthUnitType.Star);
            //        e.Column.Width = width;
            //        break;

            //    case "Critical_Level":
            //        e.Column.Visibility = Visibility.Collapsed;
            //        break;

            //    case "Manufacturing Order Number":
            //        DataGridLength width1 = new DataGridLength(2, DataGridLengthUnitType.Star);
            //        e.Column.Width = width1;
            //        break;
            //}
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {

            //crystalReportsViewer1.Owner = Window.GetWindow(this);

            //ReportDocument report = new ReportDocument();
            //string path = System.AppDomain.CurrentDomain.BaseDirectory + "\\InventoryReport.rpt";

            //report.Load(path);
            //crystalReportsViewer1.ViewerCore.ReportSource = report;



            //crystalReportsViewer1.Owner = Window.GetWindow(this);
            //ReportDocument report = new ReportDocument();
            //string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.ToString();
            //path += @"\BLM\BLM\Reports\InventoryReport.rpt";
            //report.Load(path);

            //crystalReportsViewer1.ViewerCore.ReportSource = report;

            //InventoryReport obj = new InventoryReport();
            //obj.Load(@"InventoryReport");
            //crystalReportsViewer1.ViewerCore.ReportSource = obj;

        }
    }
}