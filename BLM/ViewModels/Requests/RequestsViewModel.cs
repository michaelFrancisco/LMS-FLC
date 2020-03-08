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
            _requestsGridSource = Connection.dbTable("Select `production_requests`.`ID`,`inventory`.`Name`,`production_requests`.`Status`, `production_requests`.`Theoretical_Yield` from `flc`.`production_requests` inner join `flc`.`inventory` on `flc`.`production_requests`.`Recipe_ID` = `flc`.`inventory`.`ID` where Status = 'Finished';");
            NotifyOfPropertyChange(null);
            _selectedCategory = "Complete";
        }

        public void btnExport()
        {
        }

        public void btnPending()
        {
            _requestsGridSource = Connection.dbTable("Select `production_requests`.`ID`,`inventory`.`Name`,`production_requests`.`Status`, `production_requests`.`Theoretical_Yield` from `flc`.`production_requests` inner join `flc`.`inventory` on `flc`.`production_requests`.`Recipe_ID` = `flc`.`inventory`.`ID` where Status = 'Pending';");
            NotifyOfPropertyChange(null);
            _selectedCategory = "Pending";
        }

        public void btnProcessing()
        {
            _requestsGridSource = Connection.dbTable("Select `production_requests`.`ID`,`inventory`.`Name`,`production_requests`.`Status`, `production_requests`.`Theoretical_Yield` from `flc`.`production_requests` inner join `flc`.`inventory` on `flc`.`production_requests`.`Recipe_ID` = `flc`.`inventory`.`ID` where Status = 'Processing' or Status = 'Waiting for Raw Materials' or Status = 'Raw Materials delivered to Production team. Awaiting confirmation' or Status = 'Currently being processed by the Production Team' or Status = 'Finished by the Production Team. Waiting for Dispensing officer to transfer to inventory.';");
            NotifyOfPropertyChange(null);
            _selectedCategory = "Processing";
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
            NotifyOfPropertyChange(null);
            _selectedCategory = "Request";
        }

        public void showItem()
        {
            try
            {
                DataRowView dataRowView = (DataRowView)_requestsGridSelectedItem;
                switch (_selectedCategory)
                {
                    case "Request":
                        windowManager.ShowWindow(new NewRequestViewModel(Convert.ToInt32(dataRowView.Row[0])), null, null);
                        break;

                    case "Pending":
                        MessageBoxResult dialogResult = MessageBox.Show("Do you want to cancel this request?", "!", MessageBoxButton.YesNo);
                        if (dialogResult == MessageBoxResult.Yes)
                        {
                            Connection.dbCommand("DELETE FROM `flc`.`production_requests` WHERE (`ID` = '" + dataRowView.Row[0].ToString() + "');");
                        }
                        break;
                }
            }
            catch
            {
            }
        }

        protected override void OnActivate()
        {
            _requestsGridSource = Connection.dbTable("SELECT `inventory`.`ID`,`inventory`.`Name`, `inventory`.`Quantity` as 'Stock on Hand' FROM flc.inventory where Category = 'Finished Product';");
            _baseshipmentGridSource = _requestsGridSource;
            _selectedCategory = "Request";
            NotifyOfPropertyChange(null);
            base.OnActivate();
        }
    }
}