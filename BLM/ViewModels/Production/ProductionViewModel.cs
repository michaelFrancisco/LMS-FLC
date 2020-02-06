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
        private string _selectedStatus;
        private string _txtProductName;
        private string _txtID;
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

        public string txtProductName
        {
            get { return _txtProductName; }
            set { _txtProductName = value; }
        }

        public string txtID
        {
            get { return _txtID; }
            set { _txtID = value; }
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
                "`status` as `Status`," +
                "`created_date`as`Created Date` " +
                "FROM flc.production");
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
                "`status` as `Status`," +
                "`created_date`as`Created Date` " +
                "FROM flc.production where status = 'finished'");
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
                "`status` as `Status`," +
                "`created_date`as`Created Date` " +
                "FROM flc.production where status = 'pending'");

            NotifyOfPropertyChange(null);
            _selectedStatus = "Pending";
            clear();
        }

        public void btnProcessing()
        {
            _productionGridSource = Connection.dbTable(
       "SELECT `id`," +
                "`name` as `Product Name`," +
                "`qty` as `Quantity`," +
                "`status` as `Status`," +
                "`created_date`as`Created Date` " +
                "FROM flc.production where status = 'processing'");
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
                "`status` as `Status`," +
                "`created_date`as`Created Date` " +
                "FROM flc.production");
            NotifyOfPropertyChange(() => productionGridSource);
            _txtSearch = string.Empty;
            _selectedStatus = "All";
            clear();
        }

        //private SystemColors _highlightselectedButton;

        //public SystemColors highlightselectedButton
        //{
        //    get { return _highlightselectedButton; }
        //    set {
        //        _highlightselectedButton = value;
        //    if (_selectedStatus != null)
        //        {
        //            _highlightselectedButton = SystemColors.;
        //        }
        //    }
        //}
      
        public void print()
        {
            try
            {
                if (_selectedStatus == "All,Pending,Processing,Finished")
                {
                    DataRowView dataRowView = (DataRowView)_productionGridSelectedItem;
                    _txtProductName = dataRowView.Row[1].ToString();
                    _txtTheoreticalYield = dataRowView.Row[2].ToString();
                    _txtStatus = dataRowView.Row[9].ToString();
                    NotifyOfPropertyChange(null);
                }
                else
                {
                    DataRowView dataRowView = (DataRowView)_productionGridSelectedItem;
                    _txtProductName = dataRowView.Row[1].ToString();
                    _txtTheoreticalYield = dataRowView.Row[2].ToString();
                    _txtStatus = dataRowView.Row[9].ToString();
                    _txtID = dataRowView.Row[4].ToString();
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
                "`size` as `Size`," +
                "`unit` as `Unit`," +
                "`weight` as `Weight`," +
                "`status` as `Status`," +
                "`created_date`as`Created Date` " +
                "FROM flc.production");

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

        private string _productName;


    public void btnProceed()
        {
            try
            {
                DataRowView dataRowView = (DataRowView)_productionGridSelectedItem;
                _productName = dataRowView.Row[1].ToString();
                _txtStatus = dataRowView.Row[3].ToString();


                if (_txtStatus == "pending")
                {
                    MessageBoxResult dialogResult = MessageBox.Show("Do you want to change the status of '" + _productName + "' from Pending to Processing?.", "!", MessageBoxButton.YesNo);
                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        _txtID = dataRowView.Row[0].ToString();
                        Connection.dbCommand(@"UPDATE `flc`.`production` SET `Status` = 'processing' WHERE `id` = '" + _txtID + "'");
                        _txtID = "";
                    }
                    else
                    {
                        MessageBox.Show("{Please check if you click any of those list");
                    } 
                }
                else if (_txtStatus == "processing")
                {
                    MessageBoxResult dialogResult = MessageBox.Show("Do you want to change the status of '" + _productName + "' from Processing to Finished?.", "!", MessageBoxButton.YesNo);
                    if (dialogResult == MessageBoxResult.Yes)
                    {
                       
                            _txtID = dataRowView.Row[0].ToString();
                            Connection.dbCommand(@"UPDATE `flc`.`inventory` SET `Supplier_ID` = '3', `Name` = '"+ dataRowView.Row[1].ToString() + "', `Category` = 'Finished Product', `Quantity` = '"+dataRowView.Row[2].ToString()+"', `Size` = '"+ dataRowView.Row[3].ToString() + "', `Unit` = '"+dataRowView.Row[4].ToString()+ "', `Weight` = '100', `Critical_Level` = '8' WHERE `Item_ID` = '" + dataRowView.Row[0].ToString() + "';");
                            _txtID = "";
                        
                    }
                    else
                    {
                        MessageBox.Show("{Please check if you click any of those list");
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Error!");
            }
        }
    }
}