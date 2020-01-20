using BLM.Models;
using BLM.ViewModels.Production.Forms;
using BLM.ViewModels.Shipments.Forms;
using Caliburn.Micro;
using System;
using System.Data;

namespace BLM.ViewModels.Production
{
    internal class ProductionViewModel : Screen
    {
        private readonly IWindowManager windowManager = new WindowManager();
        private object _productionGridSelectedItem;

        private DataTable _productionGridSource;

        private string _selectedStatus;

        private string _txtSearch;

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

        public string txtSearch
        {
            get { return _txtSearch; }
            set
            {
                _txtSearch = value;
                DataView dv = new DataView(_productionGridSource);
                dv.RowFilter = "Origin LIKE '%" + _txtSearch + "%' OR Destination LIKE '%" + _txtSearch + "%'";
                _productionGridSource = dv.ToTable();
                NotifyOfPropertyChange(null);
            }
        }
        public void btnCreate()
        {
            windowManager.ShowWindow(new NewProductionViewModel(), null, null);
        }

        public void btnExport()
        {
        }

        public void btnFinished()
        {
            _productionGridSource = Connection.dbTable(
                "SELECT prod_id as 'ID'," +
                "prod_name as 'NAME'," +
                "prod_category as 'CATEGORY'," +
                "prod_status as 'STATUS'," +
                "prod_theoretical_yield as 'THEORETICAL Y'," +
                "prod_actual_yield as 'ACTUAL Y'," +
                "prod_percent_yield as '% YIELD'," +
                "prod_received_weight as 'RECEIVED W'" +
                "from flc.production WHERE prod_status = 'Finished'");
            NotifyOfPropertyChange(null);
            _selectedStatus = "Finished";
        }
        public void btnPending()
        {
             _productionGridSource = Connection.dbTable("SELECT prod_id as 'ID'," +
                "prod_name as 'NAME'," +
                "prod_category as 'CATEGORY'," +
                "prod_status as 'STATUS'," +
                "prod_theoretical_yield as 'THEORETICAL Y'," +
                "prod_actual_yield as 'ACTUAL Y'," +
                "prod_percent_yield as '% YIELD'," +
                "prod_received_weight as 'RECEIVED W'" +
                "from flc.production WHERE prod_status = 'Pending'");
       
            NotifyOfPropertyChange(null);
            _selectedStatus = "Pending";
        }

        public void btnProcessing()
        {
            _productionGridSource = Connection.dbTable("SELECT prod_id as 'ID'," +
                "prod_name as 'NAME'," +
                "prod_category as 'CATEGORY'," +
                "prod_status as 'STATUS', " +
                "prod_theoretical_yield as 'THEORETICAL Y'," +
                "prod_actual_yield as 'ACTUAL Y'," +
                "prod_percent_yield as '% YIELD'," +
                "prod_received_weight as 'RECEIVED W'" +
                "from flc.production WHERE prod_status = 'Processing'");
            NotifyOfPropertyChange(null);
            _selectedStatus = "Processing";
        }

        public void btnRefresh()
        {
            switch (_selectedStatus)
            {
                case "Pending":
                    _productionGridSource = Connection.dbTable(
                         "SELECT prod_id as 'ID', " +
                "prod_name as 'NAME', " +
                "prod_category as 'CATEGORY', " +
                "prod_status as 'STATUS', " +
                "prod_theoretical_yield as 'THEORETICAL Y'," +
                "prod_actual_yield as 'ACTUAL Y'," +
                "prod_percent_yield as '% YIELD'," +
                "prod_received_weight as 'RECEIVED W' " +
                "from flc.production WHERE prod_status = 'Pending'");
                    break;

                case "Processing":
                    _productionGridSource = Connection.dbTable(
                "SELECT prod_id as 'ID', " +
                "prod_name as 'NAME', " +
                "prod_category as 'CATEGORY', " +
                "prod_status as 'STATUS', " +
                "prod_theoretical_yield as 'THEORETICAL Y'," +
                "prod_actual_yield as 'ACTUAL Y'," +
                "prod_percent_yield as '% YIELD'," +
                "prod_received_weight as 'RECEIVED W' " +
                "from flc.production WHERE prod_status = 'Processing'");
                    break;

                case "Finished":
                    _productionGridSource = Connection.dbTable(
                "SELECT prod_id as 'ID', " +
                "prod_name as 'NAME', " +
                "prod_category as 'CATEGORY', " +
                "prod_status as 'STATUS', " +
                "prod_theoretical_yield as 'THEORETICAL Y'," +
                "prod_actual_yield as 'ACTUAL Y'," +
                "prod_percent_yield as '% YIELD'," +
                "prod_received_weight as 'RECEIVED W' " +
                "from flc.production");
                    break;
            }
            _txtSearch = string.Empty;
            NotifyOfPropertyChange(null);
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
                "SELECT prod_id as 'ID', " +
                "prod_name as 'NAME', " +
                "prod_category as 'CATEGORY', " +
                "prod_status as 'STATUS', " +
                "prod_theoretical_yield as 'THEORETICAL Y'," +
                "prod_actual_yield as 'ACTUAL Y'," +
                "prod_percent_yield as '% YIELD'," +
                "prod_received_weight as 'RECEIVED W' " +
                "from flc.production");
            NotifyOfPropertyChange(null);
            base.OnActivate();
        }
    }
}