using BLM.Models;
using BLM.ViewModels.Requests.Forms;
using BLM.ViewModels.Shipments.Forms;
using Caliburn.Micro;
using System;
using System.Data;
using System.Windows;

namespace BLM.ViewModels.Requests
{
    internal class RequestsViewModel : Screen
    {
        private readonly IWindowManager windowManager = new WindowManager();
        private DataTable _baseshipmentGridSource;
        private object _requestsGridSelectedItem;
        private DataTable _requestsGridSource;
        private string _selectedCategory;
        private string _txtSearch;

        public object requestsGridSelectedItem
        {
            get { return _requestsGridSelectedItem; }
            set { _requestsGridSelectedItem = value; }
        }

        public DataTable requestsGridSource
        {
            get { return _requestsGridSource; }
            set { _requestsGridSource = value; }
        }

        public string txtSearch
        {
            get { return _txtSearch; }
            set
            {
                _txtSearch = value;
                if (!string.IsNullOrEmpty(_txtSearch))
                {
                    DataView dv = new DataView(_requestsGridSource);
                    dv.RowFilter = "Name LIKE '%" + _txtSearch + "%'";
                    _requestsGridSource = dv.ToTable();
                    NotifyOfPropertyChange(null);
                }
                else
                {
                    _requestsGridSource = _baseshipmentGridSource;
                    NotifyOfPropertyChange(null);
                }
            }
        }

        public void btnComplete()
        {
            _requestsGridSource = Connection.dbTable("Select `request_production`.`id`,`inventory`.`Name`,`request_production`.`status`, `request_production`.`theoretical_yield` from `flc`.`request_production` inner join `flc`.`inventory` on `flc`.`request_production`.`inventory_Item_ID` = `flc`.`inventory`.`Name` WHERE `request_production`.`status` = 'complete';");
            NotifyOfPropertyChange(null);
            _selectedCategory = "Complete";
        }

        public void btnExport()
        {
        }

        public void btnPending()
        {
            _requestsGridSource = Connection.dbTable("Select `request_production`.`id`,`inventory`.`Name`,`request_production`.`status`, `request_production`.`theoretical_yield`,`request_production`.`due_date` from `flc`.`request_production` inner join `flc`.`inventory` on `flc`.`request_production`.`inventory_Item_ID` = `flc`.`inventory`.`Item_ID` where `request_production`.`status` = 'pending';");
            NotifyOfPropertyChange(null);
            _selectedCategory = "Pending";
        }

        public void btnProcessing()
        {
            _requestsGridSource = Connection.dbTable("Select `request_production`.`id`,`inventory`.`Name`,`request_production`.`status`, `request_production`.`theoretical_yield` from `flc`.`request_production` inner join `flc`.`inventory` on `flc`.`request_production`.`inventory_Item_ID` = `flc`.`inventory`.`Name` WHERE `request_production`.`status` = 'processing';");
            NotifyOfPropertyChange(null);
            _selectedCategory = "Processing";
        }

        public void btnRefresh()
        {
            switch (_selectedCategory)
            {
                case "Pending":
                    _requestsGridSource = Connection.dbTable("Select `request_production`.`id`,`inventory`.`Name`,`request_production`.`status`, `request_production`.`theoretical_yield`,`request_production`.`due_date` from `flc`.`request_production` inner join `flc`.`inventory` on `flc`.`request_production`.`inventory_Item_ID` = `flc`.`inventory`.`Item_ID` where `request_production`.`status` = 'pending';");
                    _baseshipmentGridSource = _requestsGridSource;
                    break;

                case "Processing":
                    _requestsGridSource = Connection.dbTable("Select `request_production`.`id`,`inventory`.`Name`,`request_production`.`status`, `request_production`.`theoretical_yield` from `flc`.`request_production` inner join `flc`.`inventory` on `flc`.`request_production`.`inventory_Item_ID` = `flc`.`inventory`.`Name` WHERE `request_production`.`status` = 'processing';");
                    _baseshipmentGridSource = _requestsGridSource;
                    break;

                case "Complete":
                    _requestsGridSource = Connection.dbTable("Select `request_production`.`id`,`inventory`.`Name`,`request_production`.`status`, `request_production`.`theoretical_yield` from `flc`.`request_production` inner join `flc`.`inventory` on `flc`.`request_production`.`inventory_Item_ID` = `flc`.`inventory`.`Name` WHERE `request_production`.`status` = 'complete';");
                    _baseshipmentGridSource = _requestsGridSource;
                    break;

                case "Request":
                    _requestsGridSource = Connection.dbTable(@"SELECT `inventory`.`Item_ID`,`inventory`.`Name`, `inventory`.`Quantity` as 'Stock on Hand' FROM flc.inventory where Category = 'Finished Product';");
                    _baseshipmentGridSource = _requestsGridSource;
                    break;
            }
            _txtSearch = string.Empty;
            NotifyOfPropertyChange(null);
        }

        public void btnRequest()
        {
            _requestsGridSource = Connection.dbTable(@"SELECT `inventory`.`Item_ID`,`inventory`.`Name`, `inventory`.`Quantity` as 'Stock on Hand' FROM flc.inventory where Category = 'Finished Product';");
            NotifyOfPropertyChange(null);
            _selectedCategory = "Request";
        }

        public void showItem()
        {
            try
            {
                DataRowView dataRowView = (DataRowView)_requestsGridSelectedItem;
                if (_selectedCategory == "Request")
                {
                    windowManager.ShowWindow(new NewRequestViewModel(Convert.ToInt32(dataRowView.Row[0])), null, null);
                }
                else if (_selectedCategory == "Pending")
                {
                    MessageBoxResult dialogResult = MessageBox.Show("Do you want to cancel this request?", "!", MessageBoxButton.YesNo);
                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        Connection.dbCommand("DELETE FROM `flc`.`request_production` WHERE (`id` = '" + dataRowView.Row[0].ToString() + "');");
                    }
                }
            }
            catch
            {
            }
        }

        protected override void OnActivate()
        {
            _requestsGridSource = Connection.dbTable("Select `request_production`.`id`,`inventory`.`Name`,`request_production`.`status`, `request_production`.`theoretical_yield` from `flc`.`request_production` inner join `flc`.`inventory` on `flc`.`request_production`.`inventory_Item_ID` = `flc`.`inventory`.`Name`;");
            _baseshipmentGridSource = _requestsGridSource;
            _selectedCategory = "All";
            NotifyOfPropertyChange(null);
            base.OnActivate();
        }
    }
}