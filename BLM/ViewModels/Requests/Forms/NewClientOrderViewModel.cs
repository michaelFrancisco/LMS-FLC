using BLM.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;

namespace BLM.ViewModels.Requests.Forms
{
    internal class NewClientOrderViewModel : Screen
    {
        private readonly IWindowManager windowManager = new WindowManager();
        private DateTime _dateDue;
        private int _itemGridSelectedIndex;
        private object _itemGridSelectedItem;
        private DataTable _itemGridSource;
        private DataTable _materialsGridSource;
        private string _selectedClient;
        private DateTime _selectedDate;
        private string _selectedItem;
        private string _txtAddress;
        private List<string> _txtClient;
        private string _txtContactPerson;
        private double _txtCurrentWeight;
        private int _txtEditedQuantity;
        private string _txtEmail;
        private string _txtPhoneNumber;
        private int _txtQuantity;
        private List<string> _txtSearch;
        private double _txtTotal;
        private Visibility _visibilityEmail;
        private Visibility _visibilityNotEnoughWarning;
        private Visibility _visibilityWeightWarning;

        public DateTime dateDue
        {
            get
            {
                return _dateDue;
            }

            set
            {
                _dateDue = value;
            }
        }

        public int itemGridSelectedIndex
        {
            get
            {
                return _itemGridSelectedIndex;
            }

            set
            {
                _itemGridSelectedIndex = value;
            }
        }

        public object itemGridSelectedItem
        {
            get { return _itemGridSelectedItem; }
            set { _itemGridSelectedItem = value; }
        }

        public DataTable itemGridSource
        {
            get
            {
                return _itemGridSource;
            }

            set
            {
                _itemGridSource = value;
            }
        }

        public DataTable materialsGridSource
        {
            get
            {
                return _materialsGridSource;
            }

            set
            {
                _materialsGridSource = value;
            }
        }

        public string selectedClient
        {
            get
            {
                return _selectedClient;
            }

            set
            {
                _selectedClient = value;
                try
                {
                    DataTable dt = Connection.dbTable("select Distinct Name from client");
                    List<string> list = dt.AsEnumerable().Select(r => r.Field<string>("Name")).ToList();
                    if (!list.Contains(value))
                    {
                        _selectedClient = string.Empty;
                    }
                    else
                    {
                        dt = Connection.dbTable("Select * from client where Name = '" + value + "'");
                        _txtAddress = dt.Rows[0]["Address"].ToString();
                        _txtContactPerson = dt.Rows[0]["Contact_Person"].ToString();
                        _txtEmail = dt.Rows[0]["Email"].ToString();
                        _txtPhoneNumber = dt.Rows[0]["Contact_Number"].ToString();
                    }
                    NotifyOfPropertyChange(null);
                }
                catch
                {
                }
            }
        }

        public DateTime selectedDate
        {
            get
            {
                return DateTime.Now;
            }

            set
            {
                _selectedDate = value;
            }
        }

        public string selectedItem
        {
            get
            {
                return _selectedItem;
            }

            set
            {
                _selectedItem = value;
            }
        }

        public string txtAddress
        {
            get
            {
                return _txtAddress;
            }

            set
            {
                _txtAddress = value;
            }
        }

        public List<string> txtClient
        {
            get
            {
                DataTable dt = Connection.dbTable("select Distinct Name from client");
                List<string> list = dt.AsEnumerable().Select(r => r.Field<string>("Name")).ToList();
                return list;
            }
            set
            {
                _txtClient = value;
            }
        }

        public string txtContactPerson
        {
            get
            {
                return _txtContactPerson;
            }

            set
            {
                _txtContactPerson = value;
            }
        }

        public double txtCurrentWeight
        {
            get
            {
                return _txtCurrentWeight;
            }

            set
            {
                _txtCurrentWeight = value;
            }
        }

        public int txtEditedQuantity
        {
            get { return _txtEditedQuantity; }
            set
            { _txtEditedQuantity = value; }
        }

        public string txtEmail
        {
            get
            {
                return _txtEmail;
            }

            set
            {
                _txtEmail = value;
            }
        }

        public string txtPhoneNumber
        {
            get
            {
                return _txtPhoneNumber;
            }

            set
            {
                _txtPhoneNumber = value;
            }
        }

        public int txtQuantity
        {
            get { return _txtQuantity; }
            set { _txtQuantity = value; }
        }

        public List<string> txtSearch
        {
            get
            {
                DataTable dt = Connection.dbTable("select Distinct Name from inventory where Category = 'Finished Product'");
                List<string> list = dt.AsEnumerable().Select(r => r.Field<string>("Name")).ToList();
                return list;
            }
            set
            {
                _txtSearch = value;
            }
        }

        public double txtTotal
        {
            get
            {
                return _txtTotal;
            }

            set
            {
                _txtTotal = value;
            }
        }

        public Visibility visibilityEmail
        {
            get { return _visibilityEmail; }
            set { _visibilityEmail = value; }
        }

        public Visibility visibilityNotEnoughWarning
        {
            get
            {
                return _visibilityNotEnoughWarning;
            }

            set
            {
                _visibilityNotEnoughWarning = value;
            }
        }

        public Visibility visibilityWeightWarning
        {
            get
            {
                return _visibilityWeightWarning;
            }

            set
            {
                _visibilityWeightWarning = value;
            }
        }

        public static void editQuantity(int editedQuantity, object itemGridSelectedItem)
        {
            DataRow row = (DataRow)itemGridSelectedItem;
        }

        public void btnAdd()
        {
            try
            {
                if (_itemGridSource.AsEnumerable().Any(row => _selectedItem == row.Field<String>("Name")))
                {
                    MessageBox.Show("Item already included!");
                }
                else if (_txtQuantity > 0)
                {
                    DataTable dt = Connection.dbTable(@"select * from inventory where Name = '" + _selectedItem + "'");
                    int ID = int.Parse(dt.Rows[0]["ID"].ToString());
                    dt.Rows[0]["Quantity"] = _txtQuantity;
                    dt.Columns.Add("Unit Price");
                    dt.Rows[0]["Unit Price"] = dt.Rows[0]["Price"];
                    dt.Rows[0]["Price"] = double.Parse(dt.Rows[0]["Price"].ToString()) * _txtQuantity;
                    _itemGridSource.ImportRow(dt.Rows[0]);
                    updateValues();
                }
                else
                {
                    MessageBox.Show("Invalid Quantity");
                }

                NotifyOfPropertyChange(null);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void btnCancel()
        {
        }

        public void btnDeleteItem()
        {
            _itemGridSource.Rows.RemoveAt(_itemGridSelectedIndex);
            updateValues();
        }

        public void btnEdit()
        {
            try
            {
                _txtEditedQuantity = int.Parse(_itemGridSource.Rows[_itemGridSelectedIndex]["Quantity"].ToString());
                NotifyOfPropertyChange(null);
            }
            catch
            {
            }
        }

        public void btnEditItem()
        {
            try
            {
                DataRowView itemGridSelectedItem = (DataRowView)_itemGridSelectedItem;
                itemGridSelectedItem.Row["Quantity"] = _txtEditedQuantity;
                updateValues();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void btnEmail()
        {
            windowManager.ShowWindow(new EmailPreviewViewModel(GetListOfMissingMaterials()), null, null);
        }

        public void btnSave()
        {
            DataTable clientID = Connection.dbTable("Select ID from client where Name = '" + _selectedClient + "'");
            Connection.dbCommand(@"INSERT INTO `flc`.`client_order` (`Client_ID`, `Processed_By`, `Date_Due`) VALUES ('" + clientID.Rows[0]["ID"].ToString() + "', '" + CurrentUser.User_ID + "', '" + _dateDue.ToString("yyyy-MM-dd") + "');");
            DataTable orderID = Connection.dbTable("select Max(ID) from client_order");
            foreach (DataRow iRow in _itemGridSource.Rows)
            {
                Connection.dbCommand("INSERT INTO `flc`.`production_requests` (`Order_ID`,`Recipe_ID`, `Status`, `theoretical_yield`, `due_date`, `Requested_By`) VALUES ('" + orderID.Rows[0][0].ToString() + "','" + iRow["ID"] + "', 'Waiting for Raw Materials', '" + iRow["ID"] + "', '" + _dateDue.ToString("yyyy-MM-dd") + "', '" + CurrentUser.User_ID + "');");
            }
        }

        public List<MissingMaterial> GetListOfMissingMaterials()
        {
            List<MissingMaterial> missingMaterialsList = new List<MissingMaterial>();
            foreach (DataRow row in _materialsGridSource.Rows)
            {
                if (int.Parse(row["Required Quantity"].ToString()) > int.Parse(row["Stock on Hand"].ToString()))
                {
                    MissingMaterial missingMaterial = new MissingMaterial();
                    missingMaterial.MaterialName = row["Name"].ToString();
                    missingMaterial.Email = row["Email"].ToString();
                    missingMaterial.RequiredQuantity = int.Parse(row["Required Quantity"].ToString()) - int.Parse(row["Stock on Hand"].ToString());
                    missingMaterial.SupplierName = row["Supplier Name"].ToString();
                    missingMaterialsList.Add(missingMaterial);
                }
            }
            return missingMaterialsList;
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            _itemGridSource = Connection.dbTable("Select * from inventory where null");
            _materialsGridSource = Connection.dbTable("SELECT `inventory`.`Name`, `recipe`.`Quantity` AS 'Required Quantity', `inventory`.`Quantity` AS 'Stock on Hand', `supplier`.`Name`  as 'Supplier Name', `supplier`.`Email` FROM `flc`.`inventory` INNER JOIN `flc`.`recipe` ON `inventory`.`ID` = `recipe`.`Ingredient_ID` INNER JOIN `flc`.`supplier` ON `inventory`.`Supplier_ID` = `supplier`.`ID` WHERE null");
            DataColumn col = _itemGridSource.Columns.Add("Unit Price");
            col.SetOrdinal(5);
            _txtTotal = 0;
            _txtCurrentWeight = 0;
            _visibilityNotEnoughWarning = Visibility.Collapsed;
            _visibilityEmail = Visibility.Collapsed;
            _visibilityWeightWarning = Visibility.Collapsed;
            NotifyOfPropertyChange(null);
        }

        private void updateValues()
        {
            _materialsGridSource.Clear();
            _visibilityNotEnoughWarning = Visibility.Collapsed;
            _visibilityEmail = Visibility.Collapsed;
            double weight = 0;
            double price = 0;
            foreach (DataRow iRow in _itemGridSource.Rows)
            {
                iRow["Price"] = double.Parse(iRow["Price"].ToString()) * double.Parse(iRow["Quantity"].ToString());
                price += (double.Parse(iRow["Price"].ToString()) / 1000);
                weight += double.Parse(iRow["Weight"].ToString()) * double.Parse(iRow["Quantity"].ToString());
                DataTable dt = Connection.dbTable("SELECT `inventory`.`Name`, `recipe`.`Quantity` AS 'Required Quantity', `inventory`.`Quantity` AS 'Stock on Hand', `supplier`.`Name` as 'Supplier Name', `supplier`.`Email` FROM `flc`.`inventory` INNER JOIN `flc`.`recipe` ON `inventory`.`ID` = `recipe`.`Ingredient_ID` INNER JOIN `flc`.`supplier` ON `inventory`.`Supplier_ID` = `supplier`.`ID` WHERE `recipe`.`Item_ID` = '" + iRow["ID"].ToString() + "'; ");
                foreach (DataRow row in dt.Rows)
                {
                    bool hasMaterial = false;
                    int mRowIndex = 0;
                    foreach (DataRow mRow in _materialsGridSource.Rows)
                    {
                        if (mRow["Name"].ToString() == row["Name"].ToString())
                        {
                            hasMaterial = true;
                            break;
                        }
                        mRowIndex++;
                    }
                    if (hasMaterial)
                    {
                        _materialsGridSource.Rows[mRowIndex]["Required Quantity"] = (double.Parse(row["Required Quantity"].ToString()) * double.Parse(iRow["Quantity"].ToString())) + double.Parse(_materialsGridSource.Rows[mRowIndex]["Required Quantity"].ToString());
                    }
                    else
                    {
                        row["Required Quantity"] = double.Parse(row["Required Quantity"].ToString()) * double.Parse(iRow["Quantity"].ToString());
                        _materialsGridSource.ImportRow(row);
                        if (_visibilityNotEnoughWarning == Visibility.Collapsed && double.Parse(row["Required Quantity"].ToString()) > double.Parse(row["Stock on Hand"].ToString()))
                        {
                            _visibilityNotEnoughWarning = Visibility.Visible;
                            _visibilityEmail = Visibility.Visible;
                        }
                    }
                }
            }
            _txtCurrentWeight = weight;
            _txtTotal = price;
            if (_txtCurrentWeight > 3100)
            {
                _visibilityWeightWarning = Visibility.Visible;
            }
            else
            {
                _visibilityWeightWarning = Visibility.Collapsed;
            }
            NotifyOfPropertyChange(null);
        }
    }
}