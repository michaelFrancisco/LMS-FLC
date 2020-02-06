using BLM.Models;
using BLM.ViewModels.Production.Forms;
using Caliburn.Micro;
using System.Data;
using System.Drawing;
using System.Windows;

namespace BLM.ViewModels.Production
{
    internal class ProductionViewModel : Screen
    {
        private readonly IWindowManager windowManager = new WindowManager();
        private object _productionGridSelectedItem;
        private DataTable _productionGridSource;
        private string _productName;
        private string _selectedStatus;
        private string _txtID;
        private string _txtProductName;
        private string _txtSearch;
        private string _txtStatus;
        private string _txtTheoreticalYield;

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
              "SELECT `id`," +
                "`name` as `Product Name`," +
                "`qty` as `Quantity`," +
                "`unit` as `Unit`," +
                "`weight` as `Weight`," +
                "`status` as `Status`," +
                "`theoretical_yield` as `Theoretical Yield`," +
                "`created_date`as`Created Date` " +
                "FROM flc.production WHERE (`Status` = 'pending'&'moved to inventory'&'processing')");
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

        public void btnCreate()
        {
            windowManager.ShowWindow(new NewProductionViewModel(), null, null);
        }

        public void btnFinished()
        {
            _productionGridSource = Connection.dbTable(
                 "SELECT `id`," +
                "`name` as `Product Name`," +
                "`qty` as `Quantity`," +
                "`unit` as `Unit`," +
                "`weight` as `Weight`," +
                "`status` as `Status`," +
                "`theoretical_yield` as `Theoretical Yield`," +
                "`created_date`as`Created Date` " +
                "FROM flc.production where `Status` = 'moved to inventory'");
            NotifyOfPropertyChange(null);
            _selectedStatus = "Finished";
            clear();
        }

        public void btnPending()
        {
            _productionGridSource = Connection.dbTable(
                "SELECT `id`," +
                "`name` as `Product Name`," +
                "`qty` as `Quantity`," +
                "`unit` as `Unit`," +
                "`weight` as `Weight`," +
                "`status` as `Status`," +
                "`theoretical_yield` as `Theoretical Yield`," +
                "`created_date`as`Created Date` " +
                "FROM flc.production where `Status` = 'pending'");

            NotifyOfPropertyChange(null);
            _selectedStatus = "Pending";
            clear();
        }

        public void btnProceed()
        {
            try
            {
                DataRowView dataRowView = (DataRowView)_productionGridSelectedItem;
                _productName = dataRowView.Row[1].ToString();
                _txtStatus = dataRowView.Row[6].ToString();
                _txtID = dataRowView.Row[0].ToString();

                if (_txtStatus == "pending")
                {
                    MessageBoxResult dialogResult = MessageBox.Show("Do you want to change the status of '" + _productName + "' from Pending to Processing?.", "!", MessageBoxButton.YesNo);
                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        _txtID = dataRowView.Row[0].ToString();
                        Connection.dbCommand(@"UPDATE `flc`.`production` SET `status` = 'processing' WHERE `id` = '" + _txtID + "'");
                        MessageBox.Show("The Product '" + _productName + "' is now in processing state!");
                    }
                }
                else if (_txtStatus == "processing")
                {
                    MessageBoxResult dialogResult = MessageBox.Show("Do you want to change the status of '" + _productName + "' from Processing to Finished?.", "!", MessageBoxButton.YesNo);
                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        DataTable currentQuantity = Connection.dbTable("SELECT Quantity FROM flc.inventory where Item_ID = " + _txtID + ";");
                        Connection.dbCommand("UPDATE `flc`.`inventory` SET `Quantity` = '" + (((int)currentQuantity.Rows[0][0]) + (int)dataRowView.Row[2]).ToString() + "' WHERE (`Item_ID` = '" + _txtID + "');");
                        MessageBox.Show("The Product '" + _productName + "' is finished!");
                        Connection.dbCommand("UPDATE `flc`.`production` SET `status` = 'moved to inventory' WHERE `id` = '" + _txtID + "'");
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
            _productionGridSource = Connection.dbTable(
       "SELECT `id`," +
                "`name` as `Product Name`," +
                "`qty` as `Quantity`," +
                "`unit` as `Unit`," +
                "`weight` as `Weight`," +
                "`status` as `Status`," +
                "`theoretical_yield` as `Theoretical Yield`," +
                "`created_date`as`Created Date` " +
                "FROM flc.production where `Status` = 'processing'");
            NotifyOfPropertyChange(null);
            _selectedStatus = "Processing";
            clear();
        }

        public void btnRefresh()
        {
            _productionGridSource = Connection.dbTable(
                "SELECT `id`," +
                "`name` as `Product Name`," +
                "`qty` as `Quantity`," +
                "`unit` as `Unit`," +
                "`weight` as `Weight`," +
                "`status` as `Status`," +
                "`theoretical_yield` as `Theoretical Yield`," +
                "`created_date`as`Created Date` " +
                "FROM flc.production WHERE (`Status` = 'pending'&'moved to inventory'&'processing')");
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
                    DataRowView dataRowView = (DataRowView)_productionGridSelectedItem;
                    _txtProductName = dataRowView.Row[1].ToString();
                    _txtTheoreticalYield = dataRowView.Row[6].ToString();
                    _txtStatus = dataRowView.Row[5].ToString();
                    NotifyOfPropertyChange(null);
                }
                else
                {
                    DataRowView dataRowView = (DataRowView)_productionGridSelectedItem;
                    _txtProductName = dataRowView.Row[1].ToString();
                    _txtTheoreticalYield = dataRowView.Row[6].ToString();
                    _txtStatus = dataRowView.Row[5].ToString();
                    _txtID = dataRowView.Row[0].ToString();
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
            _productionGridSource = Connection.dbTable(
                "SELECT `id`," +
                "`name` as `Product Name`," +
                "`qty` as `Quantity`," +
                "`unit` as `Unit`," +
                "`weight` as `Weight`," +
                "`status` as `Status`," +
                "`theoretical_yield` as `Theoretical Yield`," +
                "`created_date`as`Created Date` " +
                "FROM flc.production WHERE (`Status` = 'pending'&'moved to inventory'&'processing') Order by `Created Date` Desc");

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
    }
}