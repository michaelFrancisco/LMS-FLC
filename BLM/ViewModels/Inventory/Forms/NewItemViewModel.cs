using BLM.Models;
using Caliburn.Micro;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;

namespace BLM.ViewModels.Inventory.Forms
{
    internal class NewItemViewModel : Screen
    {
        private List<string> _cmbCategory;
        private string _selectedCategory;
        private string _selectedSupplier;
        private int _txtCriticalLevel;
        private string _txtName;
        private int _txtQuantity;
        private int _txtSize;
        private List<string> _txtSupplier;
        private string _txtUnit;

        private int _txtWeight;

        public List<string> cmbCategory
        {
            get { return new List<string> { "Raw Material", "Packaging", "Finished Product" }; }
            set { _cmbCategory = value; }
        }

        public string selectedCategory
        {
            get { return _selectedCategory; }
            set { _selectedCategory = value; }
        }

        public string selectedSupplier
        {
            get { return _selectedSupplier; }
            set { _selectedSupplier = value; }
        }

        public int txtCriticalLevel
        {
            get { return _txtCriticalLevel; }
            set { _txtCriticalLevel = value; }
        }

        public string txtName
        {
            get { return _txtName; }
            set { _txtName = value; }
        }

        public int txtQuantity
        {
            get { return _txtQuantity; }
            set { _txtQuantity = value; }
        }

        public int txtSize
        {
            get { return _txtSize; }
            set { _txtSize = value; }
        }

        public List<string> txtSupplier
        {
            get
            {
                DataTable dt = Connection.dbTable("select Distinct Name from supplier");
                List<string> list = dt.AsEnumerable().Select(r => r.Field<string>("Name")).ToList();
                return list;
            }
            set { _txtSupplier = value; }
        }

        public string txtUnit
        {
            get { return _txtUnit; }
            set { _txtUnit = value; }
        }

        public int txtWeight
        {
            get { return _txtWeight; }
            set { _txtWeight = value; }
        }

        public void btnCancel()
        {
            MessageBoxResult dialogResult = MessageBox.Show("Are you sure? Unsaved changes will be lost.", "!", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                TryClose();
            }
        }

        public void btnSave()
        {
            try
            {
                if (areRequiredFieldsComplete())
                {
                    DataTable _supplierID = Connection.dbTable("select ID from supplier where Name = '" + _selectedSupplier + "'");
                    Connection.dbCommand("INSERT INTO `flc`.`inventory` (`Name`, `Category`, `Quantity`, `Size`, `Unit`, `Critical_Level`, `Supplier_ID`, `Weight`) VALUES('" + _txtName + "', '" + _selectedCategory + "', '" + _txtQuantity + "', '" + _txtSize + "', '" + _txtUnit + "', '" + _txtCriticalLevel + "','" + _supplierID.Rows[0][0].ToString() + "', '" + _txtWeight + "');");
                    TryClose();
                }
                else
                {
                    MessageBox.Show("Please fill required fields");
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private bool areRequiredFieldsComplete()
        {
            if (
                _txtName == string.Empty ||
                _txtCriticalLevel.ToString() == string.Empty ||
                _txtQuantity.ToString() == string.Empty ||
                _txtSize.ToString() == string.Empty ||
                _txtUnit == string.Empty ||
                _selectedCategory == string.Empty
                )
                return false;
            else
                return true;
        }
    }
}