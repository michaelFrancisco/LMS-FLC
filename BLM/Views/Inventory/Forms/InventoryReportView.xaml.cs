using BLM.Reports;
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
    /// Interaction logic for InventoryReportView.xaml
    /// </summary>
    public partial class InventoryReportView : Window
    {
        public InventoryReportView()
        {
            InitializeComponent();
            InventoryReport obj = new InventoryReport();
            obj.Load(@"InventoryReport");
            rptInventory.ViewerCore.ReportSource = obj;
        }
    }
}
