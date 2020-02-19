using BLM.Models;
using BLM.ViewModels.Shipments.Forms;
using Caliburn.Micro;
using System;
using System.Data;
using System.Windows;

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

        public void btnComplete()
        {
            _shipmentsGridSource = Connection.dbTable(@"SELECT `shipments`.`ID`,`shipments`.`Category`,`shipments`.`Status`,`shipments`.`Origin`,`shipments`.`Destination`,`shipments`.`Date_Due`,`trucks`.`Name` AS `Truck`,`users`.`Name` AS `Delivery Agent`FROM shipments INNER JOIN users ON `shipments`.`Delivery_Agent_ID` = `users`.`ID` INNER JOIN trucks ON `shipments`.`Truck_ID` = `trucks`.`ID` where Status = 'Complete' order by ID Desc;");
            NotifyOfPropertyChange(null);
            _selectedCategory = "Complete";
        }

        public void btnCreate()
        {
            windowManager.ShowWindow(new NewShipmentViewModel(), null, null);
        }

        public void btnExport()
        {
        }

        public void btnPending()
        {
            _shipmentsGridSource = Connection.dbTable(@"SELECT `shipments`.`ID`,`shipments`.`Category`,`shipments`.`Status`,`shipments`.`Origin`,`shipments`.`Destination`,`shipments`.`Date_Due`,`trucks`.`Name` AS `Truck`,`users`.`Name` AS `Delivery Agent`FROM shipments INNER JOIN users ON `shipments`.`Delivery_Agent_ID` = `users`.`ID` INNER JOIN trucks ON `shipments`.`Truck_ID` = `trucks`.`ID` where Status = 'Pending' order by ID Desc;");
            NotifyOfPropertyChange(null);
            _selectedCategory = "Pending";
        }

        public void btnTransit()
        {
            _shipmentsGridSource = Connection.dbTable(@"SELECT `shipments`.`ID`,`shipments`.`Category`,`shipments`.`Status`,`shipments`.`Origin`,`shipments`.`Destination`,`shipments`.`Date_Due`,`trucks`.`Name` AS `Truck`,`users`.`Name` AS `Delivery Agent`FROM shipments INNER JOIN users ON `shipments`.`Delivery_Agent_ID` = `users`.`ID` INNER JOIN trucks ON `shipments`.`Truck_ID` = `trucks`.`ID` where Status = 'In Transit' order by ID Desc;");
            NotifyOfPropertyChange(null);
            _selectedCategory = "Transit";
        }

        public void btnRefresh()
        {
            switch (_selectedCategory)
            {
                case "Pending":
                    _shipmentsGridSource = Connection.dbTable(@"SELECT `shipments`.`ID`,`shipments`.`Category`,`shipments`.`Status`,`shipments`.`Origin`,`shipments`.`Destination`,`shipments`.`Date_Due`,`trucks`.`Name` AS `Truck`,`users`.`Name` AS `Delivery Agent`FROM shipments INNER JOIN users ON `shipments`.`Delivery_Agent_ID` = `users`.`ID` INNER JOIN trucks ON `shipments`.`Truck_ID` = `trucks`.`ID` where Status = 'Pending' order by ID Desc;");
                    _baseshipmentGridSource = _shipmentsGridSource;
                    break;

                case "Transit":
                    _shipmentsGridSource = Connection.dbTable(@"SELECT `shipments`.`ID`,`shipments`.`Category`,`shipments`.`Status`,`shipments`.`Origin`,`shipments`.`Destination`,`shipments`.`Date_Due`,`trucks`.`Name` AS `Truck`,`users`.`Name` AS `Delivery Agent`FROM shipments INNER JOIN users ON `shipments`.`Delivery_Agent_ID` = `users`.`ID` INNER JOIN trucks ON `shipments`.`Truck_ID` = `trucks`.`ID` where Status = 'In Transit' order by ID Desc;");
                    _baseshipmentGridSource = _shipmentsGridSource;
                    break;

                case "Complete":
                    _shipmentsGridSource = Connection.dbTable(@"SELECT `shipments`.`ID`,`shipments`.`Category`,`shipments`.`Status`,`shipments`.`Origin`,`shipments`.`Destination`,`shipments`.`Date_Due`,`trucks`.`Name` AS `Truck`,`users`.`Name` AS `Delivery Agent`FROM shipments INNER JOIN users ON `shipments`.`Delivery_Agent_ID` = `users`.`ID` INNER JOIN trucks ON `shipments`.`Truck_ID` = `trucks`.`ID` where Status = 'Complete' order by ID Desc;");
                    _baseshipmentGridSource = _shipmentsGridSource;
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
                if (dataRowView.Row["Status"].ToString() == "Pending")
                {
                    windowManager.ShowWindow(new EditShipmentViewModel(Convert.ToInt32(dataRowView.Row[0])), null, null);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        protected override void OnActivate()
        {
            _shipmentsGridSource = Connection.dbTable(@"SELECT `shipments`.`ID`,`shipments`.`Category`,`shipments`.`Status`,`shipments`.`Origin`,`shipments`.`Destination`,`shipments`.`Date_Due`,`trucks`.`Name` AS `Truck`,`users`.`ID` AS `Delivery Agent`FROM shipments INNER JOIN users ON `shipments`.`Delivery_Agent_ID` = `users`.`ID` INNER JOIN trucks ON `shipments`.`Truck_ID` = `trucks`.`ID` where Status = 'Pending' order by ID Desc;");
            _baseshipmentGridSource = _shipmentsGridSource;
            _selectedCategory = "All";
            NotifyOfPropertyChange(null);
            base.OnActivate();
        }
    }
}