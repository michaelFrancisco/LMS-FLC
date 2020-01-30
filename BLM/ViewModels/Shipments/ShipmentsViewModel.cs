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
        private DataTable _baseshipmentGridSource;
        private string _selectedCategory;
        private object _shipmentsGridSelectedItem;

        private DataTable _shipmentsGridSource;
        private string _txtSearch;
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

        public string txtSearch
        {
            get { return _txtSearch; }
            set
            {
                _txtSearch = value;
                if (!string.IsNullOrEmpty(_txtSearch))
                {
                    DataView dv = new DataView(_shipmentsGridSource);
                    dv.RowFilter = "Origin LIKE '%" + _txtSearch + "%' OR Destination LIKE '%" + _txtSearch + "%' OR Truck LIKE '%" + _txtSearch + "%' OR 'Delivery Agent' LIKE '%" + _txtSearch + "%'";
                    _shipmentsGridSource = dv.ToTable();
                    NotifyOfPropertyChange(null);
                }
                else
                {
                    _shipmentsGridSource = _baseshipmentGridSource;
                    NotifyOfPropertyChange(null);
                }
            }
        }
        public void btnAll()
        {
            _shipmentsGridSource = Connection.dbTable(@"SELECT `shipments`.`Shipment_ID`,`shipments`.`Category`,`shipments`.`Status`,`shipments`.`Origin`,`shipments`.`Destination`,`shipments`.`Date_Due`,`trucks`.`Name` AS `Truck`,`users`.`Name` AS `Delivery Agent`FROM shipments INNER JOIN users ON `shipments`.`Delivery_Agent_ID` = `users`.`User_ID` INNER JOIN trucks ON `shipments`.`Truck_ID` = `trucks`.`Truck_ID`");
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
            _shipmentsGridSource = Connection.dbTable(@"SELECT `shipments`.`Shipment_ID`,`shipments`.`Category`,`shipments`.`Status`,`shipments`.`Origin`,`shipments`.`Destination`,`shipments`.`Date_Due`,`trucks`.`Name` AS `Truck`,`users`.`Name` AS `Delivery Agent`FROM shipments INNER JOIN users ON `shipments`.`Delivery_Agent_ID` = `users`.`User_ID` INNER JOIN trucks ON `shipments`.`Truck_ID` = `trucks`.`Truck_ID` where `shipments`.`Category` = 'Inbound'");
            NotifyOfPropertyChange(null);
            _selectedCategory = "Inbound";
        }

        public void btnOutbound()
        {
            _shipmentsGridSource = Connection.dbTable(@"SELECT `shipments`.`Shipment_ID`,`shipments`.`Category`,`shipments`.`Status`,`shipments`.`Origin`,`shipments`.`Destination`,`shipments`.`Date_Due`,`trucks`.`Name` AS `Truck`,`users`.`Name` AS `Delivery Agent`FROM shipments INNER JOIN users ON `shipments`.`Delivery_Agent_ID` = `users`.`User_ID` INNER JOIN trucks ON `shipments`.`Truck_ID` = `trucks`.`Truck_ID` where `shipments`.`Category` = 'Outbound'");
            NotifyOfPropertyChange(null);
            _selectedCategory = "Outbound";
        }

        public void btnRefresh()
        {
            switch (_selectedCategory)
            {
                case "Inbound":
                    _shipmentsGridSource = Connection.dbTable(@"SELECT `shipments`.`Shipment_ID`,`shipments`.`Category`,`shipments`.`Status`,`shipments`.`Origin`,`shipments`.`Destination`,`shipments`.`Date_Due`,`trucks`.`Name` AS `Truck`,`users`.`Name` AS `Delivery Agent`FROM shipments INNER JOIN users ON `shipments`.`Delivery_Agent_ID` = `users`.`User_ID` INNER JOIN trucks ON `shipments`.`Truck_ID` = `trucks`.`Truck_ID` where `shipments`.`Category` = 'Inbound'");
                    _baseshipmentGridSource = _shipmentsGridSource;
                    break;

                case "Outbound":
                    _shipmentsGridSource = Connection.dbTable(@"SELECT `shipments`.`Shipment_ID`,`shipments`.`Category`,`shipments`.`Status`,`shipments`.`Origin`,`shipments`.`Destination`,`shipments`.`Date_Due`,`trucks`.`Name` AS `Truck`,`users`.`Name` AS `Delivery Agent`FROM shipments INNER JOIN users ON `shipments`.`Delivery_Agent_ID` = `users`.`User_ID` INNER JOIN trucks ON `shipments`.`Truck_ID` = `trucks`.`Truck_ID` where `shipments`.`Category` = 'Outbound'");
                    _baseshipmentGridSource = _shipmentsGridSource;
                    break;

                case "All":
                    _shipmentsGridSource = Connection.dbTable(@"SELECT `shipments`.`Shipment_ID`,`shipments`.`Category`,`shipments`.`Status`,`shipments`.`Origin`,`shipments`.`Destination`,`shipments`.`Date_Due`,`trucks`.`Name` AS `Truck`,`users`.`Name` AS `Delivery Agent`FROM shipments INNER JOIN users ON `shipments`.`Delivery_Agent_ID` = `users`.`User_ID` INNER JOIN trucks ON `shipments`.`Truck_ID` = `trucks`.`Truck_ID`");
                    _baseshipmentGridSource = _shipmentsGridSource;
                    break;
            }
            _txtSearch = string.Empty;
            NotifyOfPropertyChange(null);
        }

        public void showItem()
        {
            //try
            //{
                DataRowView dataRowView = (DataRowView) _shipmentsGridSelectedItem;
                windowManager.ShowWindow(new EditShipmentViewModel(Convert.ToInt32(dataRowView.Row[0])), null, null);
            //}
            //catch
            //{

            //}
        }

        protected override void OnActivate()
        {
            _shipmentsGridSource = Connection.dbTable(@"SELECT `shipments`.`Shipment_ID`,`shipments`.`Category`,`shipments`.`Status`,`shipments`.`Origin`,`shipments`.`Destination`,`shipments`.`Date_Due`,`trucks`.`Name` AS `Truck`,`users`.`Name` AS `Delivery Agent`FROM shipments INNER JOIN users ON `shipments`.`Delivery_Agent_ID` = `users`.`User_ID` INNER JOIN trucks ON `shipments`.`Truck_ID` = `trucks`.`Truck_ID`");
            _baseshipmentGridSource = _shipmentsGridSource;
            _selectedCategory = "All";
            NotifyOfPropertyChange(null);
            base.OnActivate();
        }

        
    }
}