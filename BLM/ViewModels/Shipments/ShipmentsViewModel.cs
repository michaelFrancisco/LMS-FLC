using BLM.Models;
using BLM.ViewModels.Shipments.Forms;
using Caliburn.Micro;
using System;
using System.Data;

namespace BLM.ViewModels.Shipments
{
    internal class ShipmentsViewModel : Screen
    {
        private readonly IWindowManager windowManager = new WindowManager();
        private object _shipmentsGridSelectedItem;

        private DataTable _shipmentsGridSource;

        private string _selectedCategory;

        private string _txtSearch;

        public string txtSearch
        {
            get { return _txtSearch; }
            set
            {
                _txtSearch = value;
                DataView dv = new DataView(_shipmentsGridSource);
                dv.RowFilter = "Origin LIKE '%" + _txtSearch + "%' OR Destination LIKE '%" + _txtSearch + "%'";
                _shipmentsGridSource = dv.ToTable();
                NotifyOfPropertyChange(null);
            }
        }

        public object shipmentsGridSelectedItem
        {
            get { return _shipmentsGridSelectedItem; }
            set { _shipmentsGridSelectedItem = value; }
        }

        public DataTable shipmentsGridSource
        {
            get { return _shipmentsGridSource; }
            set { _shipmentsGridSource = value; }
        }

        public void btnAll()
        {
            _shipmentsGridSource = Connection.dbTable("SELECT * from shipments");
            NotifyOfPropertyChange(null);
            _selectedCategory = "All";
        }

        public void btnCreate()
        {
            windowManager.ShowWindow(new NewShipmentViewModel(), null, null);
        }

        public void btnExport()
        {
        }

        public void btnInbound()
        {
            _shipmentsGridSource = Connection.dbTable("SELECT * from shipments where Category = 'Inbound'");
            NotifyOfPropertyChange(null);
            _selectedCategory = "Inbound";
        }

        public void btnOutbound()
        {
            _shipmentsGridSource = Connection.dbTable("SELECT * from shipments where Category = 'Outbound'");
            NotifyOfPropertyChange(null);
            _selectedCategory = "Outbound";
        }

        public void btnRefresh()
        {
            switch (_selectedCategory)
            {
                case "Inbound":
                    _shipmentsGridSource = Connection.dbTable("SELECT * from shipments where Category = 'Inbound'");
                    break;

                case "Outbound":
                    _shipmentsGridSource = Connection.dbTable("SELECT * from shipments where Category = 'Outbound'");
                    break;

                case "All":
                    _shipmentsGridSource = Connection.dbTable("SELECT * from shipments");
                    break;
            }
            _txtSearch = string.Empty;
            NotifyOfPropertyChange(null);
        }

        public void showItem()
        {
            DataRowView dataRowView = (DataRowView)_shipmentsGridSelectedItem;
            windowManager.ShowWindow(new EditShipmentViewModel(Convert.ToInt32(dataRowView.Row[0])), null, null);
        }

        protected override void OnActivate()
        {
            _shipmentsGridSource = Connection.dbTable("SELECT * from shipments");
            _selectedCategory = "All";
            NotifyOfPropertyChange(null);
            base.OnActivate();
        }
    }
}