﻿using BLM.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace BLM.ViewModels.Shipments.Forms
{
    internal class NewShipmentViewModel : Screen
    {
        private DataTable _baseitemGridSource;
        private DataTable _baseshipmentGridSource;
        private bool _btnOKisEnabled;
        private bool _enabledSave;
        private bool _isAdding;
        private object _itemGridSelectedItem;
        private DataTable _itemGridSource;
        private int _maxQuantity;
        private int _quantity;
        private Visibility _QuantityBoxVisibility;
        private string _quantityToolTipText;
        private string _selectedCategory;
        private DateTime _selectedDate;
        private string _selectedDestination;
        private object _shipmentGridSelectedItem;
        private DataTable _shipmentGridSource;
        private string _tempo;
        private List<String> _txtCategory;
        private double _txtCurrentWeight;
        private List<string> _txtDestination;
        private int _txtEnteredWeight;
        private int _txtGrossWeight;
        private int _txtNetWeight;
        private int _txtQuantity;
        private string _txtQuantityLabel;
        private string _txtSearch;
        private int _txtTareWeight;
        private string _txtWeight;
        private Visibility _visibilityWeightWarning;
        private Visibility _WeightBoxVisibility;
        private DispatcherTimer dt1 = new DispatcherTimer();
        private SerialPort port1 = new SerialPort();

        public bool btnOKisEnabled
        {
            get { return _btnOKisEnabled; }
            set { _btnOKisEnabled = value; }
        }

        public bool enabledSave
        {
            get { return _enabledSave; }
            set { _enabledSave = value; }
        }

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

        public Visibility QuantityBoxVisibility
        {
            get { return _QuantityBoxVisibility; }
            set { _QuantityBoxVisibility = value; }
        }

        public string quantityToolTipText
        {
            get { return _quantityToolTipText; }
            set { _quantityToolTipText = value; }
        }

        public string selectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                if (selectedCategory == "Inbound")
                {
                    _itemGridSource = Connection.dbTable("select `inventory`.`ID`, `inventory`.`Name`, `inventory`.`Category`, `inventory`.`Size`,`inventory`.`Unit`, `supplier`.`Name`,`inventory`.`Weight` from inventory inner join supplier on `inventory`.`Supplier_ID` = `supplier`.`ID` where `inventory`.`Category` = 'Raw Material' OR `inventory`.`Category` = 'Packaging';");
                    _shipmentGridSource = Connection.dbTable("select `inventory`.`ID`, `inventory`.`Name`, `inventory`.`Category`, `inventory`.`Quantity`, `inventory`.`Size`,`inventory`.`Unit`, `supplier`.`Name`,`inventory`.`Weight` from inventory inner join supplier on `inventory`.`Supplier_ID` = `supplier`.`ID` where null;");
                    _baseitemGridSource = itemGridSource;
                    _baseshipmentGridSource = _shipmentGridSource;
                    NotifyOfPropertyChange(null);
                }
                else if (selectedCategory == "Outbound")
                {
                    _itemGridSource = Connection.dbTable("SELECT ID, Name, Category, Quantity, Size, Unit, Weight FROM `flc`.`inventory` where Quantity > 0 and `Category` = 'Finished Product';");
                    _shipmentGridSource = Connection.dbTable("SELECT ID, Name, Category, Quantity, Size, Unit, Weight FROM `flc`.`inventory` where null;");
                    _baseitemGridSource = itemGridSource;
                    _baseshipmentGridSource = shipmentGridSource;
                    NotifyOfPropertyChange(null);
                }
                updateWeight();
            }
        }

        public DateTime selectedDate
        {
            get { return _selectedDate; }
            set { _selectedDate = value; }
        }

        public string selectedDestination
        {
            get { return _selectedDestination; }
            set { _selectedDestination = value; }
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

        public double txtCurrentWeight
        {
            get { return _txtCurrentWeight; }
            set { _txtCurrentWeight = value; }
        }

        public List<string> txtDestination
        {
            get
            {
                DataTable dt = Connection.dbTable("select Distinct Name from client");
                List<string> list = dt.AsEnumerable().Select(r => r.Field<string>("Name")).ToList();
                return list;
            }
            set { _txtDestination = value; }
        }

        public int txtEnteredWeight
        {
            get { return _txtEnteredWeight; }
            set { _txtEnteredWeight = value; }
        }

        public int txtGrossWeight
        {
            get { return _txtGrossWeight; }
            set { _txtGrossWeight = value; }
        }

        public int txtNetWeight
        {
            get { return _txtNetWeight; }
            set { _txtNetWeight = value; }
        }

        public int txtQuantity
        {
            get { return _txtQuantity; }
            set
            {
                _txtQuantity = value;

                if ((_txtQuantity > _maxQuantity && _selectedCategory == "Outbound") || _txtQuantity <= 0)
                {
                    _quantityToolTipText = "Please input valid quantity";
                    _btnOKisEnabled = false;
                    NotifyOfPropertyChange(() => btnOKisEnabled);
                    NotifyOfPropertyChange(() => quantityToolTipText);
                }
                else
                {
                    _quantityToolTipText = string.Empty;
                    _btnOKisEnabled = true;
                    NotifyOfPropertyChange(() => btnOKisEnabled);
                    NotifyOfPropertyChange(() => quantityToolTipText);
                }
            }
        }

        public string txtQuantityLabel
        {
            get { return _txtQuantityLabel; }
            set { _txtQuantityLabel = value; }
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
                    dv = new DataView(_shipmentGridSource);
                    dv.RowFilter = "Name LIKE '%" + _txtSearch + "%'";
                    _shipmentGridSource = dv.ToTable();
                    NotifyOfPropertyChange(null);
                }
                else
                {
                    _shipmentGridSource = _baseshipmentGridSource;
                    _itemGridSource = _baseitemGridSource;
                    NotifyOfPropertyChange(null);
                }
            }
        }

        public int txtTareWeight
        {
            get { return _txtTareWeight; }
            set { _txtTareWeight = value; }
        }

        public string txtWeight
        {
            get { return _txtWeight; }
            set { _txtWeight = value; }
        }

        public Visibility visibilityWeightWarning
        {
            get { return _visibilityWeightWarning; }
            set { _visibilityWeightWarning = value; }
        }

        public Visibility WeightBoxVisibility
        {
            get { return _WeightBoxVisibility; }
            set { _WeightBoxVisibility = value; }
        }

        public void addItem()
        {
            try
            {
                if (_selectedCategory == "Outbound")
                {
                    DataRowView dataRowView = (DataRowView)_itemGridSelectedItem;
                    _txtQuantity = (int)dataRowView.Row[3];
                    _maxQuantity = (int)dataRowView.Row[3];
                    NotifyOfPropertyChange(() => txtQuantity);
                }
                _txtQuantityLabel = "Enter amount to be added";
                NotifyOfPropertyChange(() => txtQuantityLabel);
                _QuantityBoxVisibility = System.Windows.Visibility.Visible;
                NotifyOfPropertyChange(() => QuantityBoxVisibility);
                _isAdding = true;
            }
            catch
            {
            }
        }

        public void addWeight()
        {
            _WeightBoxVisibility = System.Windows.Visibility.Visible;

            try
            {
                port1.BaudRate = 9600;
                port1.PortName = "COM4";
                port1.Open();

                dt1.Tick += new EventHandler(timer_Tick);
                dt1.Interval = new TimeSpan(0, 0, 0);
                dt1.Start();
            }
            catch
            {
                MessageBox.Show("Please Check the connection of your weighing scale");
            }
            NotifyOfPropertyChange(null);
            base.OnActivate();
        }

        public void btnCancel()
        {
            MessageBoxResult dialogResult = MessageBox.Show("Are you sure? Unsaved changes will be lost.", "!", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                TryClose();
            }
        }

        public void btnCaptureWeight()
        {
            _tempo = "clicked";
            _txtGrossWeight = _txtEnteredWeight;
            NotifyOfPropertyChange(() => txtGrossWeight);
        }

        public void btnDone()
        {
            _txtWeight = _txtNetWeight.ToString();
            _tempo = "notClicked";
            _txtGrossWeight = 0;
            _txtNetWeight = 0;
            _txtTareWeight = 0;
            _txtEnteredWeight = 0;
            _WeightBoxVisibility = System.Windows.Visibility.Collapsed;
            NotifyOfPropertyChange(null);
        }

        public void btnOK()
        {
            try
            {
                _quantity = _txtQuantity;
                if (_selectedCategory == "Outbound" && _isAdding)
                {
                    moveOutboundItems(_itemGridSource, _shipmentGridSource, _itemGridSelectedItem);
                }
                else if (_selectedCategory == "Outbound" & !_isAdding)
                {
                    moveOutboundItems(_shipmentGridSource, _itemGridSource, _shipmentGridSelectedItem);
                }
                else if (_selectedCategory == "Inbound" && _isAdding)
                {
                    moveInboundItems(_itemGridSource, _shipmentGridSource, _itemGridSelectedItem);
                }
                else if (_selectedCategory == "Inbound" && !_isAdding)
                {
                    moveInboundItems(_shipmentGridSource, _itemGridSource, _shipmentGridSelectedItem);
                }
                _QuantityBoxVisibility = System.Windows.Visibility.Collapsed;
                NotifyOfPropertyChange(() => QuantityBoxVisibility);
                _txtQuantity = 1;
                NotifyOfPropertyChange(() => txtQuantity);
                updateWeight();
            }
            catch (Exception)
            {
                _QuantityBoxVisibility = System.Windows.Visibility.Collapsed;
                NotifyOfPropertyChange(() => QuantityBoxVisibility);
                _txtQuantity = 1;
                NotifyOfPropertyChange(() => txtQuantity);
            }
        }

        public void btnSave()
        {
            if (fieldsareComplete() && gridhasItems())
            {
                Connection.dbCommand(@"INSERT INTO `flc`.`shipments` (`Category`, `Status`, `Destination`, `Date_Due`, `Created_By`, `Weight`) VALUES ('" + _selectedCategory + "', 'Pending','" + _selectedDestination + "', '" + _selectedDate.ToString("yyyy-MM-dd") + "', '" + CurrentUser.User_ID + "','" + _txtCurrentWeight + "');");
                int shipmentID = getShipmentID();
                foreach (DataRow row in _shipmentGridSource.Rows)
                {
                    Connection.dbCommand(@"INSERT INTO `flc`.`shipment_items` (`Item_ID`, `Shipment_ID`, `Quantity`) VALUES ('" + row[0].ToString() + "', '" + shipmentID + "', '" + row[3].ToString() + "');");
                }
                TryClose();
            }
            else
            {
                MessageBox.Show("Please fill out all fields");
            }
        }

        public void editItem()
        {
            try
            {
                if (_selectedCategory == "Outbound")
                {
                    DataRowView dataRowView = (DataRowView)_shipmentGridSelectedItem;
                    _txtQuantity = (int)dataRowView.Row[3];
                    _maxQuantity = (int)dataRowView.Row[3];
                    NotifyOfPropertyChange(() => txtQuantity);
                }
                _txtQuantityLabel = "Enter amount to be reduced";
                NotifyOfPropertyChange(() => txtQuantityLabel);
                _QuantityBoxVisibility = System.Windows.Visibility.Visible;
                NotifyOfPropertyChange(() => QuantityBoxVisibility);
                _isAdding = false;
            }
            catch
            {
            }
        }

        public void EnteredWeight()
        {
            if (_tempo == "notClicked")
            {
                _txtGrossWeight = _txtEnteredWeight;
                _txtNetWeight = _txtGrossWeight - _txtTareWeight;
                NotifyOfPropertyChange(null);
            }
            else
            {
                _tempo = "clicked";
            }
        }

        public int existingIDRow(int ID, DataView Grid)
        {
            int count = 0;
            foreach (DataRowView dataRowView in Grid)
            {
                if (Convert.ToInt32(dataRowView.Row[0]) == ID)
                {
                    return count;
                }
                count++;
            }
            return -1;
        }

        public bool fieldsareComplete()
        {
            if (string.IsNullOrEmpty(_selectedCategory) || string.IsNullOrEmpty(_selectedDestination))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void moveInboundItems(DataTable fromSource, DataTable toSource, object fromSourceSelectedItem)
        {
            DataRowView dataRowView = (DataRowView)fromSourceSelectedItem;
            if (_isAdding)
            {
                if (existingIDRow(Convert.ToInt32(dataRowView.Row[0]), toSource.AsDataView()) > -1)
                {
                    int row = existingIDRow(Convert.ToInt32(dataRowView.Row[0]), toSource.AsDataView());
                    toSource.Rows[row][3] = (int)toSource.Rows[row][3] + _quantity;
                }
                else
                {
                    toSource.Rows.Add(dataRowView.Row[0], dataRowView.Row[1], dataRowView.Row[2], _quantity, dataRowView.Row[3], dataRowView.Row[4], dataRowView.Row[5], dataRowView.Row["Weight"]);
                }
            }
            else if (!_isAdding)
            {
                if (_quantity == (int)dataRowView.Row[3])
                {
                    fromSource.Rows.Remove(dataRowView.Row);
                }
                else
                {
                    dataRowView.Row[3] = (int)dataRowView.Row[3] - _quantity;
                }
                _baseshipmentGridSource = shipmentGridSource;
            }
            NotifyOfPropertyChange(null);
        }

        public void moveOutboundItems(DataTable fromSource, DataTable toSource, object fromSourceSelectedItem)
        {
            DataRowView dataRowView = (DataRowView)fromSourceSelectedItem;
            if (existingIDRow(Convert.ToInt32(dataRowView.Row[0]), toSource.AsDataView()) > -1)
            {
                int row = existingIDRow(Convert.ToInt32(dataRowView.Row[0]), toSource.AsDataView());
                toSource.Rows[row][3] = (int)toSource.Rows[row][3] + _quantity;
            }
            else
            {
                toSource.Rows.Add(dataRowView.Row[0], dataRowView.Row[1], dataRowView.Row[2], _quantity.ToString(), dataRowView.Row[4], dataRowView.Row[5], dataRowView.Row["Weight"]);
            }
            if (_quantity == (int)dataRowView.Row[3])
            {
                fromSource.Rows.Remove(dataRowView.Row);
            }
            else
            {
                dataRowView.Row[3] = (int)dataRowView.Row[3] - _quantity;
            }
            _baseshipmentGridSource = shipmentGridSource;
            NotifyOfPropertyChange(null);
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                Int32.TryParse(port1.ReadLine(), out int result);
                if (result > -1)
                {
                    _txtEnteredWeight = result;
                    NotifyOfPropertyChange(() => txtEnteredWeight);
                }
            }
            catch
            { }

            try
            {
                if (_txtTareWeight > -1)
                {
                    _txtNetWeight = _txtGrossWeight - _txtTareWeight;
                    NotifyOfPropertyChange(() => txtNetWeight);
                }
            }
            catch
            {
            }
        }

        protected override void OnActivate()
        {
            _tempo = "notClicked";
            _QuantityBoxVisibility = System.Windows.Visibility.Collapsed;
            _btnOKisEnabled = true;
            _txtQuantity = 1;
            _selectedDate = DateTime.Now;
            _WeightBoxVisibility = System.Windows.Visibility.Collapsed;
            _visibilityWeightWarning = System.Windows.Visibility.Collapsed;
            NotifyOfPropertyChange(null);
            _enabledSave = true;
            base.OnActivate();
        }

        protected override void OnDeactivate(bool close)
        {
            dt1.Stop();
            base.OnDeactivate(close);
        }

        private int getShipmentID()
        {
            DataTable dt = Connection.dbTable("SELECT max(ID) FROM flc.shipments;;");
            return Convert.ToInt32(dt.Rows[0][0].ToString());
        }

        private bool gridhasItems()
        {
            if (_shipmentGridSource.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void updateWeight()
        {
            if (_shipmentGridSource.Rows.Count > 0)
            {
                _txtCurrentWeight = 0;
                foreach (DataRow row in _shipmentGridSource.Rows)
                {
                    _txtCurrentWeight += ((double.Parse(row["Weight"].ToString()) * (double.Parse(row["Quantity"].ToString()))) / 1000);
                }
                if (_txtCurrentWeight > 3100)
                {
                    _visibilityWeightWarning = System.Windows.Visibility.Visible;
                    _enabledSave = false;
                }
                else
                {
                    _visibilityWeightWarning = System.Windows.Visibility.Collapsed;
                    _enabledSave = true;
                }
                NotifyOfPropertyChange(null);
            }
            else
            {
                _txtCurrentWeight = 0;
                NotifyOfPropertyChange(() => txtCurrentWeight);
            }
        }
    }
}