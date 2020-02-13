using BLM.Models;
using BLM.ViewModels.Production.Forms;
using Caliburn.Micro;
using System.Data;
//using System.Drawing;
using System.Windows;
using System.Windows.Media;


namespace BLM.ViewModels.Production
{
    internal class ProductionViewModel : Screen
    {
        private readonly IWindowManager windowManager = new WindowManager();
        private Brush _brushFinished;
        private Brush _brushProcessing;
        private Brush _brushRequest;
        private object _productionGridSelectedItem;
        private DataTable _productionGridSource;
        private string _productName;
        private string _selectedStatus;
        private string _txtID;
        private string _txtProductName;
        private string _txtSearch;
        private string _txtStatus;
        private string _txtTheoreticalYield;

        public Brush brushFinished
        {
            get { return _brushFinished; }
            set { _brushFinished = value; }
        }

        public Brush brushProcessing
        {
            get { return _brushProcessing; }
            set { _brushProcessing = value; }
        }

        public Brush brushRequest
        {
            get { return _brushRequest; }
            set { _brushRequest = value; }
        }

        public Visibility btnProceedVisibility { get; set; }

        public object productionGridSelectedItem
        {
            get { return _productionGridSelectedItem; }
            set { _productionGridSelectedItem = value; }
        }

        public DataTable productionGridSource
        {
            get { return _productionGridSource; }
            set { _productionGridSource = value; }
        }

        public string txtID
        {
            get { return _txtID; }
            set { _txtID = value; }
        }

        public string txtProductName
        {
            get { return _txtProductName; }
            set { _txtProductName = value; }
        }

        public string txtSearch
        {
            get { return _txtSearch; }
            set
            {
                _txtSearch = value;
                if (!string.IsNullOrEmpty(_txtSearch))
                {
                    DataView dv = new DataView(_productionGridSource);
                    dv.RowFilter = "`Product Name` LIKE '%" + _txtSearch + "%'";
                    _productionGridSource = dv.ToTable();
                    NotifyOfPropertyChange(null);
                    clear();
                }
                else
                {
                    _productionGridSource = Connection.dbTable(
  "SELECT a.`id`, a.`inventory_Item_ID`, b.`Name`, " +
          "a.`theoretical_yield` as 'Required Quantity', " +
          "a.`request_date` as `Requested Date`, " +
          "a.`status` as 'Status' " +
          "FROM flc.`request_production` as a " +
          "inner join flc.`inventory` as b " +
          "on a.`inventory_Item_ID` = b.`Item_ID` " +
          "where b.`Item_ID` = a.`inventory_Item_ID`;");
                    NotifyOfPropertyChange(() => productionGridSource);
                    clear();
                }
            }
        }

        public string txtStatus
        {
            get { return _txtStatus; }
            set { _txtStatus = value; }
        }

        public string txtTheoreticalYield
        {
            get { return _txtTheoreticalYield; }
            set { _txtTheoreticalYield = value; }
        }

        private Visibility _btnCreateVisibility;

        public Visibility btnCreateVisibility
        {
            get { return _btnCreateVisibility; }
            set { _btnCreateVisibility = value; }
        }

        public void btnCreate()
        {
            try
            {
                if (_productionGridSelectedItem != null)
                {
                    DataRowView dataRowView = (DataRowView)_productionGridSelectedItem;
                    string nameColumn = dataRowView.Row[2].ToString();
                    string theoretical = dataRowView.Row[3].ToString();
                    string id = dataRowView.Row[0].ToString();
                    string Item_ID = dataRowView.Row[1].ToString();
                   string Name = dataRowView.Row[2].ToString();
                    windowManager.ShowWindow(new NewProductionViewModel(
                        "select b.`item_name`, " +
                        "b.`id` as 'Recipe ID', " +
                        "b.`size` * '"+theoretical+"' as 'Required Quantity', " +
                        "b.`unit`, " +
                        "b.`inventory_Item_ID` " +
                        "from flc.inventory as a " +
                        "inner join flc.recipe as b " +
                        "on a.`Item_ID` = b.`inventory_Item_ID` " +
                        "where a.`Name` like '%" + nameColumn + "%'", theoretical, id, Item_ID, Name), null, null);
                }
                else
                {
                    MessageBox.Show("Please Select Request Item");
                }
            }
            catch
            {
            }
        }

        public void btnFinished()
        {
            clearColors();
            _brushFinished = Brushes.DarkTurquoise;
            _btnCreateVisibility = Visibility.Collapsed;
            _productionGridSource = Connection.dbTable(
          "SELECT a.`id`, a.`inventory_Item_ID`, b.`Name`, " +
          "a.`theoretical_yield` as 'Required Quantity', " +
          "a.`request_date` as `Requested Date`, " +
          "a.`status` as 'Status' " +
                "FROM flc.request_production as a " +
                "INNER JOIN flc.inventory as b " +
                "ON a.`inventory_Item_ID` = b.`Item_ID` " +
                "WHERE (`Status` = 'moved to inventory') Order by `Requested Date` Desc");
            NotifyOfPropertyChange(null);
            _selectedStatus = "Finished";
            clear();
        }

        public void btnPending()
        {
            clearColors();
            _brushRequest = Brushes.DarkTurquoise;
            _btnCreateVisibility = Visibility. Visible;
            btnProceedVisibility = Visibility.Collapsed;
            _productionGridSource = Connection.dbTable(
           "SELECT a.`id`, a.`inventory_Item_ID`, b.`Name`, " +
          "a.`theoretical_yield` as 'Required Quantity', " +
          "a.`request_date` as `Requested Date`, " +
          "a.`status` as 'Status' " +
                "FROM flc.request_production as a " +
                "INNER JOIN flc.inventory as b " +
                "ON a.`inventory_Item_ID` = b.`Item_ID` " +
                "WHERE (`Status` = 'pending') Order by `Requested Date` Desc");

            NotifyOfPropertyChange(null);
            _selectedStatus = "Pending";
            clear();
        }

        public void btnProceed()
        {
            try
            {
                DataRowView dataRowView = (DataRowView)_productionGridSelectedItem;
                _productName = dataRowView.Row[2].ToString();
                _txtStatus = dataRowView.Row[6].ToString();
                _txtID = dataRowView.Row[1].ToString();

                if (_txtStatus == "processing")
                {
                    MessageBoxResult dialogResult = MessageBox.Show("Do you want to change the status of '" + _productName + "' from Processing to Finished?.", "!", MessageBoxButton.YesNo);
                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        DataTable currentQuantity = Connection.dbTable("SELECT Quantity FROM flc.inventory where Item_ID = " + _txtID + ";");
                        Connection.dbCommand("UPDATE `flc`.`inventory` SET `Quantity` = '" + (((int)currentQuantity.Rows[0][0]) + (int)dataRowView.Row[2]).ToString() + "' WHERE (`Item_ID` = '" + _txtID + "');");
                        MessageBox.Show("The Product '" + _productName + "' is finished!");
                        Connection.dbCommand("UPDATE `flc`.`request_production` SET `status` = 'moved to inventory' WHERE `id` = '" + _txtID + "'");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        public void btnProcessing()
        {
            clearColors();
            _brushProcessing = Brushes.DarkTurquoise;
            _btnCreateVisibility = Visibility.Collapsed;
            btnProceedVisibility = Visibility.Visible;
            _productionGridSource = Connection.dbTable(
"SELECT a.`id`, a.`inventory_Item_ID`, b.`Name`, " +
          "a.`theoretical_yield` as 'Required Quantity', " +
          "a.`request_date` as `Requested Date`, " +
          "a.`status` as 'Status' " +
                "FROM flc.request_production as a " +
                "INNER JOIN flc.inventory as b " +
                "ON a.`inventory_Item_ID` = b.`Item_ID` " +
                "WHERE (`Status` = 'processing') Order by `Requested Date` Desc");
           
            _selectedStatus = "Processing";
            _txtStatus = "processing";
                 NotifyOfPropertyChange(null);
            clear();
        }

        private Brush _brushRefreshAll;

        public Brush brushRefreshAll
        {
            get { return _brushRefreshAll; }
            set { _brushRefreshAll = value; }
        }

        public void btnRefresh()
        {
            clearColors();  
            _brushRefreshAll = Brushes.DarkTurquoise;
            _btnCreateVisibility = Visibility.Collapsed;
            _productionGridSource = Connection.dbTable(
         "SELECT a.`id`, a.`inventory_Item_ID`, b.`Name`, " +
          "a.`theoretical_yield` as 'Required Quantity', " +
          "a.`request_date` as `Requested Date`, " +
          "a.`status` as 'Status' " +
          "FROM flc.`request_production` as a " +
          "inner join flc.`inventory` as b " +
          "on a.`inventory_Item_ID` = b.`Item_ID` " +
          "where b.`Item_ID` = a.`inventory_Item_ID`;");
            NotifyOfPropertyChange(() => productionGridSource);
            _txtSearch = string.Empty;
            _selectedStatus = "All";
            clear();
        }
        public void print()
        {
            try
            {
                if (_selectedStatus == "All,Pending,Processing,Finished")
                {
                    DataRowView dataRowView1 = (DataRowView)_productionGridSelectedItem;
                    string selectedStatus = dataRowView1.Row[5].ToString();
                    if (selectedStatus == "pending")
                    {
                        _btnCreateVisibility = Visibility.Visible;
                    }
                    else
                    {
                        _btnCreateVisibility = Visibility.Collapsed;
                    }
                    DataRowView dataRowView = (DataRowView)_productionGridSelectedItem;
                    _txtProductName = dataRowView.Row[2].ToString();
                    _txtTheoreticalYield = dataRowView.Row[3].ToString();
                    _txtStatus = dataRowView.Row[5].ToString();
                    NotifyOfPropertyChange(null);
                }
                else
                {
                    DataRowView dataRowView1 = (DataRowView)_productionGridSelectedItem;
                    string selectedStatus = dataRowView1.Row[5].ToString();
                    if (selectedStatus == "pending")
                    {
                        _btnCreateVisibility = Visibility.Visible;
                    }
                    else
                    {
                        _btnCreateVisibility = Visibility.Collapsed;
                    }
                    DataRowView dataRowView = (DataRowView)_productionGridSelectedItem;
                    _txtProductName = dataRowView.Row[2].ToString();
                    _txtTheoreticalYield = dataRowView.Row[3].ToString();
                    _txtStatus = dataRowView.Row[5].ToString();
                    NotifyOfPropertyChange(null);
                }
            }
            catch
            {
            }
        }

        public void showItem()
        {
            try
            {
                DataRowView dataRowView = (DataRowView)_productionGridSelectedItem;
                // windowManager.ShowWindow(new EditProductionViewModel(Convert.ToInt32(dataRowView.Row[0])), null, null);
            }
            catch
            {
            }
        }
        protected override void OnActivate()
        {
            _btnCreateVisibility = Visibility.Collapsed;
            btnProceedVisibility = Visibility.Collapsed;
            _productionGridSource = Connection.dbTable(
          "SELECT a.`id`, a.`inventory_Item_ID`, b.`Name`, " +
          "a.`theoretical_yield` as 'Required Quantity', " +
          "a.`request_date` as `Requested Date`, " +
          "a.`status` as 'Status' " +
          "FROM flc.`request_production` as a " +
          "inner join flc.`inventory` as b " +
          "on a.`inventory_Item_ID` = b.`Item_ID` " +
          "where b.`Item_ID` = a.`inventory_Item_ID`;");

            
            NotifyOfPropertyChange(() => productionGridSource);
            _selectedStatus = "All";
            clear();
            base.OnActivate();
        }
        private void clear()
        {
            _txtProductName = string.Empty;
            _txtStatus = string.Empty;
            _txtTheoreticalYield = string.Empty;
            _txtID = string.Empty;
            NotifyOfPropertyChange(null);
        }

        public void clearColors()
        {
            _brushFinished = null;
            _brushProcessing = null;
            _brushRefreshAll = null;
            _brushRequest = null;
            NotifyOfPropertyChange(null);
        }
    }
}