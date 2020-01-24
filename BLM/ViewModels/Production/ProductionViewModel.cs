using BLM.Models;
using BLM.ViewModels.Production.Forms;
using Caliburn.Micro;
using System.Data;

namespace BLM.ViewModels.Production
{
    internal class ProductionViewModel : Screen
    {
        private readonly IWindowManager windowManager = new WindowManager();
        private object _productionGridSelectedItem;
        private DataTable _productionGridSource;
        private string _selectedStatus;
        private string _txtProductName;
        private string _txtRFID;
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

        public string txtRFID
        {
            get { return _txtRFID; }
            set { _txtRFID = value; }
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
                    dv.RowFilter = "NAME LIKE '%" + _txtSearch + "%' OR RFID LIKE '%" + _txtSearch + "%'";
                    _productionGridSource = dv.ToTable();
                    NotifyOfPropertyChange(null);
                    clear();
                }
                else
                {
                    _productionGridSource = Connection.dbTable(
             "SELECT prod_id as 'ID'," +
             "prod_name as 'NAME'," +
             "prod_theoretical_yield as 'THEORETICAL'," +
             "prod_item_name as 'ITEM'," +
             "prod_category as 'CATEGORY'," +
             "prod_qty as 'QUANTITY'," +
              "prod_received_weight as 'WEIGHT'," +
              "prod_size as 'SIZE'," +
              "prod_unit as 'UNIT'," +
             "prod_status as 'STATUS', " +
             "prod_rfid as 'RFID' " +
             "from flc.production");
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
                 "SELECT prod_id as 'ID'," +
                 "prod_name as 'NAME'," +
                 "prod_theoretical_yield as 'THEORETICAL'," +
                 "prod_status as 'STATUS'," +
                 "prod_rfid as 'RFID' " +
                 "from flc.production where prod_status = 'Finished' group by prod_rfid");
            NotifyOfPropertyChange(null);
            _selectedStatus = "Finished";
            clear();
        }

        public void btnPending()
        {
            _productionGridSource = Connection.dbTable(
                "SELECT prod_id as 'ID'," +
                "prod_name as 'NAME'," +
                "prod_theoretical_yield as 'THEORETICAL'," +
                "prod_status as 'STATUS'," +
                "prod_rfid as 'RFID' " +
                "from flc.production where prod_status = 'Pending' group by prod_rfid");

            NotifyOfPropertyChange(null);
            _selectedStatus = "Pending";
            clear();
        }

        public void btnProcessing()
        {
            _productionGridSource = Connection.dbTable(
                 "SELECT prod_id as 'ID'," +
                 "prod_name as 'NAME'," +
                 "prod_theoretical_yield as 'THEORETICAL'," +
                 "prod_status as 'STATUS'," +
                 "prod_rfid as 'RFID' " +
                 "from flc.production where prod_status = 'Processing' group by prod_rfid");
            NotifyOfPropertyChange(null);
            _selectedStatus = "Processing";
            clear();
        }

        public void btnRefresh()
        {
            _productionGridSource = Connection.dbTable(
                 "SELECT prod_id as 'ID'," +
                 "prod_name as 'NAME'," +
                 "prod_theoretical_yield as 'THEORETICAL'," +
                 "prod_item_name as 'ITEM'," +
                 "prod_category as 'CATEGORY'," +
                 "prod_qty as 'QUANTITY'," +
                  "prod_received_weight as 'WEIGHT'," +
                  "prod_size as 'SIZE'," +
                  "prod_unit as 'UNIT'," +
                 "prod_status as 'STATUS'," +
                 "prod_rfid as 'RFID' " +
                 "from flc.production");
            NotifyOfPropertyChange(() => productionGridSource);
            _txtSearch = string.Empty;
            _selectedStatus = "All";
            clear();
        }

        public void print()
        {
            try
            {
                if (_selectedStatus == "All")
                {
                    DataRowView dataRowView = (DataRowView)_productionGridSelectedItem;
                    _txtProductName = dataRowView.Row[1].ToString();
                    _txtTheoreticalYield = dataRowView.Row[2].ToString();
                    _txtStatus = dataRowView.Row[9].ToString();
                    _txtRFID = dataRowView.Row[10].ToString();
                    NotifyOfPropertyChange(null);
                }
                else
                {
                    DataRowView dataRowView = (DataRowView)_productionGridSelectedItem;
                    _txtProductName = dataRowView.Row[1].ToString();
                    _txtTheoreticalYield = dataRowView.Row[2].ToString();
                    _txtStatus = dataRowView.Row[3].ToString();
                    _txtRFID = dataRowView.Row[4].ToString();
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
                "SELECT prod_id as 'ID'," +
                "prod_name as 'NAME'," +
                "prod_theoretical_yield as 'THEORETICAL'," +
                "prod_item_name as 'ITEM'," +
                "prod_category as 'CATEGORY'," +
                "prod_qty as 'QUANTITY'," +
                 "prod_received_weight as 'WEIGHT'," +
                 "prod_size as 'SIZE'," +
                 "prod_unit as 'UNIT'," +
                "prod_status as 'STATUS', " +
                "prod_rfid as 'RFID' " +
                "from flc.production");
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
            _txtRFID = string.Empty;
            NotifyOfPropertyChange(null);
        }
    }
}