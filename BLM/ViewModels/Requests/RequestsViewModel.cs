using BLM.Models;
using BLM.ViewModels.Requests.Forms;
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

        private Visibility _visibilityCancel;

        private Visibility _visibilityRequest;



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

        public Visibility visibilityCancel
        {
            get { return _visibilityCancel; }
            set { _visibilityCancel = value; }
        }

        public Visibility visibilityRequest
        {
            get { return _visibilityRequest; }
            set { _visibilityRequest = value; }
        }

        public void btnCancelRequest()
        {
            MessageBoxResult dialogResult = MessageBox.Show("Do you want to cancel this request?", "!", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                DataRowView dataRowView = (DataRowView)_requestsGridSelectedItem;
                Connection.dbCommand("DELETE FROM `flc`.`production_requests` WHERE (`ID` = '" + dataRowView.Row[0].ToString() + "');");
            }
        }

        public void btnComplete()
        {
            _requestsGridSource = Connection.dbTable("Select `production_requests`.`ID`,`inventory`.`Name`,`production_requests`.`Status`, `production_requests`.`Theoretical_Yield` from `flc`.`production_requests` inner join `flc`.`inventory` on `flc`.`production_requests`.`Recipe_ID` = `flc`.`inventory`.`ID` where Status = 'Finished';");
            _visibilityCancel = Visibility.Collapsed;
            _visibilityRequest = Visibility.Collapsed;
            _selectedCategory = "Complete";
            NotifyOfPropertyChange(null);
        }

        public void btnExport()
        {
        }

        public void btnManualRequest()
        {
            try
            {
                DataRowView dataRowView = (DataRowView)_requestsGridSelectedItem;
                windowManager.ShowWindow(new NewRequestViewModel(Convert.ToInt32(dataRowView.Row[0])), null, null);
            }
            catch
            {
            }
        }

        public void btnNewClientOrder()
        {
            windowManager.ShowWindow(new NewClientOrderViewModel(), null, null);

        }

        public void btnPending()
        {
            _requestsGridSource = Connection.dbTable("Select `production_requests`.`ID`,`inventory`.`Name`,`production_requests`.`Status`, `production_requests`.`Theoretical_Yield` from `flc`.`production_requests` inner join `flc`.`inventory` on `flc`.`production_requests`.`Recipe_ID` = `flc`.`inventory`.`ID` where Status = 'Pending';");
            _visibilityCancel = Visibility.Visible;
            _visibilityRequest = Visibility.Collapsed;
            _selectedCategory = "Pending";
            NotifyOfPropertyChange(null);
        }

        public void btnProcessing()
        {
            _requestsGridSource = Connection.dbTable("Select `production_requests`.`ID`,`inventory`.`Name`,`production_requests`.`Status`, `production_requests`.`Theoretical_Yield` from `flc`.`production_requests` inner join `flc`.`inventory` on `flc`.`production_requests`.`Recipe_ID` = `flc`.`inventory`.`ID` where Status = 'Processing' or Status = 'Waiting for Raw Materials' or Status = 'Raw Materials delivered to Production team. Awaiting confirmation' or Status = 'Currently being processed by the Production Team' or Status = 'Finished by the Production Team. Waiting for Dispensing officer to transfer to inventory.';");
            _visibilityCancel = Visibility.Collapsed;
            _visibilityRequest = Visibility.Collapsed;
            _selectedCategory = "Processing";
            NotifyOfPropertyChange(null);
        }

        public void btnRefresh()
        {
            switch (_selectedCategory)
            {
                case "Pending":
                    _requestsGridSource = Connection.dbTable("Select `production_requests`.`ID`,`inventory`.`Name`,`production_requests`.`Status`, `production_requests`.`Theoretical_Yield` from `flc`.`production_requests` inner join `flc`.`inventory` on `flc`.`production_requests`.`Recipe_ID` = `flc`.`inventory`.`ID` where Status = 'Pending';");
                    _baseshipmentGridSource = _requestsGridSource;
                    break;

                case "Processing":
                    _requestsGridSource = Connection.dbTable("Select `production_requests`.`ID`,`inventory`.`Name`,`production_requests`.`Status`, `production_requests`.`Theoretical_Yield` from `flc`.`production_requests` inner join `flc`.`inventory` on `flc`.`production_requests`.`Recipe_ID` = `flc`.`inventory`.`ID` where Status = 'Processing' or Status = 'Waiting for Raw Materials' or Status = 'Raw Materials delivered to Production team. Awaiting confirmation' or Status = 'Currently being processed by the Production Team' or Status = 'Finished by the Production Team. Waiting for Dispensing officer to transfer to inventory.';");
                    _baseshipmentGridSource = _requestsGridSource;
                    break;

                case "Complete":
                    _requestsGridSource = Connection.dbTable("Select `production_requests`.`ID`,`inventory`.`Name`,`production_requests`.`Status`, `production_requests`.`Theoretical_Yield` from `flc`.`production_requests` inner join `flc`.`inventory` on `flc`.`production_requests`.`Recipe_ID` = `flc`.`inventory`.`ID` where Status = 'Finished';");
                    _baseshipmentGridSource = _requestsGridSource;
                    break;

                case "Request":
                    _requestsGridSource = Connection.dbTable("SELECT `inventory`.`ID`,`inventory`.`Name`, `inventory`.`Quantity` as 'Stock on Hand' FROM flc.inventory where Category = 'Finished Product';");
                    _baseshipmentGridSource = _requestsGridSource;
                    break;
            }
            _txtSearch = string.Empty;
            NotifyOfPropertyChange(null);
        }

        public void btnRequest()
        {
            _requestsGridSource = Connection.dbTable("SELECT `inventory`.`ID`,`inventory`.`Name`, `inventory`.`Quantity` as 'Stock on Hand' FROM flc.inventory where Category = 'Finished Product';");
            _visibilityCancel = Visibility.Collapsed;
            _visibilityRequest = Visibility.Visible;
            _selectedCategory = "Request";
            NotifyOfPropertyChange(null);
        }

        protected override void OnActivate()
        {
            _requestsGridSource = Connection.dbTable("SELECT `inventory`.`ID`,`inventory`.`Name`, `inventory`.`Quantity` as 'Stock on Hand' FROM flc.inventory where Category = 'Finished Product';");
            _baseshipmentGridSource = _requestsGridSource;
            _selectedCategory = "Request";
            _visibilityCancel = Visibility.Collapsed;
            _visibilityRequest = Visibility.Visible;
            NotifyOfPropertyChange(null);
            base.OnActivate();
        }
    }
}