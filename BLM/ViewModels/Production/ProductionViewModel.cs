using BLM.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLM.ViewModels.Production
{
    internal class ProductionViewModel : Screen
    {
        
        private readonly IWindowManager windowManager = new WindowManager();
        private object _shipmentsGridSelectedItem;

        private DataTable _productionGridSource;

        private string _selectedCategory;

        private string _txtSearch;

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

        public object shipmentsGridSelectedItem
        {
            get { return _shipmentsGridSelectedItem; }
            set { _shipmentsGridSelectedItem = value; }
        }

        public DataTable productionGridSource
        {
            get { return _productionGridSource; }
            set { _productionGridSource = value; }
        }

        public void btnAll()
        {
            _productionGridSource = Connection.dbTable("SELECT * from shipments");
            NotifyOfPropertyChange(null);
            _selectedCategory = "All";
        }

        public void btnCreate()
        {
           // windowManager.ShowWindow(new NewShipmentViewModel(), null, null);
        }

        public void btnExport()
        {
        }

        public void btnInbound()
        {
            _productionGridSource = Connection.dbTable("SELECT * from shipments where Category = 'Inbound'");
            NotifyOfPropertyChange(null);
            _selectedCategory = "Inbound";
        }

        public void btnOutbound()
        {
            _productionGridSource = Connection.dbTable("SELECT * from shipments where Category = 'Outbound'");
            NotifyOfPropertyChange(null);
            _selectedCategory = "Outbound";
        }

        public void btnRefresh()
        {
            switch (_selectedCategory)
            {
                case "Inbound":
                    _productionGridSource = Connection.dbTable("SELECT * from shipments where Category = 'Inbound'");
                    break;

                case "Outbound":
                    _productionGridSource = Connection.dbTable("SELECT * from shipments where Category = 'Outbound'");
                    break;

                case "All":
                    _productionGridSource = Connection.dbTable("SELECT * from shipments");
                    break;
            }
            _txtSearch = string.Empty;
            NotifyOfPropertyChange(null);
        }

        public void showItem()
        {
            try
            {
                DataRowView dataRowView = (DataRowView)_shipmentsGridSelectedItem;
               // windowManager.ShowWindow(new EditShipmentViewModel(Convert.ToInt32(dataRowView.Row[0])), null, null);
            }
            catch
            {
            }
        }

        protected override void OnActivate()
        {
            _productionGridSource = Connection.dbTable("SELECT * from shipments");
            _selectedCategory = "All";
            NotifyOfPropertyChange(null);
            base.OnActivate();
        }
    }
}

