using BLM.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;

namespace BLM.ViewModels.Shipments.Forms
{
    internal class NewShipmentViewModel : Screen
    {
        private object _itemGridSelectedItem;
        private DataTable _itemGridSource;
        private string _selectedCategory;
        private string _selectedOrigin;
        private object _shipmentGridSelectedItem;
        private DataTable _shipmentGridSource;
        private List<String> _txtCategory;
        private List<String> _txtOrigin;
        private DataTable _baseitemGridSource;

        private string _txtSearch;

        public object itemGridSelectedItem
        {
            get { return _itemGridSelectedItem; }
            set { _itemGridSelectedItem = value; }
        }

        public DataTable itemGridSource
        {
            get { return _itemGridSource; }
            set { _itemGridSource = value; }
        }

        public string selectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                if (selectedCategory == "Inbound")
                {
                    _itemGridSource = Connection.dbTable("select `inventory`.`Item_ID`, `inventory`.`Name`, `inventory`.`Category`, `inventory`.`Size`,`inventory`.`Unit`, `supplier`.`Supplier_Name` from inventory inner join supplier on `inventory`.`Supplier_ID` = `supplier`.`Supplier_ID`;");
                    _shipmentGridSource = Connection.dbTable("select `inventory`.`Item_ID`, `inventory`.`Name`, `inventory`.`Category`, `inventory`.`Size`,`inventory`.`Unit`, `supplier`.`Supplier_Name` from inventory inner join supplier on `inventory`.`Supplier_ID` = `supplier`.`Supplier_ID` where null;");
                    _baseitemGridSource = itemGridSource;
                    NotifyOfPropertyChange(() => itemGridSource);
                    NotifyOfPropertyChange(() => shipmentGridSource);
                }
                else if (selectedCategory == "Outbound")
                {
                    _itemGridSource = Connection.dbTable("SELECT Item_ID, Name, Category, Quantity, Size, Unit FROM `flc`.`inventory` where Quantity > 0;");
                    _shipmentGridSource = Connection.dbTable("SELECT Item_ID, Name, Category, Quantity, Size, Unit FROM `flc`.`inventory` where null;");
                    _baseitemGridSource = itemGridSource;
                    NotifyOfPropertyChange(() => itemGridSource);
                    NotifyOfPropertyChange(() => shipmentGridSource);
                }
            }
        }

        public string selectedOrigin
        {
            get { return _selectedOrigin; }
            set { _selectedOrigin = value; }
        }

        public object shipmentGridSelectedItem
        {
            get { return _shipmentGridSelectedItem; }
            set { _shipmentGridSelectedItem = value; }
        }

        public DataTable shipmentGridSource
        {
            get { return _shipmentGridSource; }
            set { _shipmentGridSource = value; }
        }

        public List<String> txtCategory
        {
            get { return new List<string> { "Inbound", "Outbound" }; }
            set { _txtCategory = value; }
        }

        public List<String> txtOrigin
        {
            get
            {
                DataTable dt = Connection.dbTable("select Origin from shipments");
                List<string> list = dt.AsEnumerable().Select(r => r.Field<string>("Origin")).ToList();
                return list;
            }
            set { _txtOrigin = value; }
        }

        public string txtSearch
        {
            get { return _txtSearch; }
            set
            {
                _txtSearch = value;
                if (!string.IsNullOrEmpty(_txtSearch))
                {
                    DataView dv = new DataView(_itemGridSource);
                    dv.RowFilter = "Name LIKE '%" + _txtSearch + "%'";
                    _itemGridSource = dv.ToTable();
                    NotifyOfPropertyChange(null);
                }
                else
                {
                    _itemGridSource = _baseitemGridSource;
                    NotifyOfPropertyChange(null);
                }
            }
        }

        public void addItem()
        {
            if (_selectedCategory == "Outbound")
            {
                DataRowView dataRowView = (DataRowView)_itemGridSelectedItem;
                _shipmentGridSource.Rows.Add(dataRowView.Row[0], dataRowView.Row[1], dataRowView.Row[2], dataRowView.Row[3], dataRowView.Row[4], dataRowView.Row[5]);
                _itemGridSource.Rows.Remove(dataRowView.Row);
                NotifyOfPropertyChange(null);
            }
            else if (_selectedCategory == "Inbound")
            {
            }
        }

        public void btnCancel()
        {
            MessageBoxResult dialogResult = MessageBox.Show("Are you sure? Unsaved changes will be lost.", "!", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                TryClose();
            }
        }
        protected override void OnActivate()
        {
        }
    }
}