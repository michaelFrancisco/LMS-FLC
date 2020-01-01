using BLM.Models;
using Caliburn.Micro;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace BLM.ViewModels.Inventory.Forms
{
    internal class EditItemViewModel : Screen
    {
        private List<string> _cmbCategory;
        private string _selectedCategory;
        private int _selectedItemID;
        private int _txtCriticalLevel;
        private string _txtName;
        private int _txtQuantity;
        private string _txtRFID;
        private int _txtSize;
        private string _txtUnit;

        public EditItemViewModel(int selectedItemID)
        {
            _selectedItemID = selectedItemID;
        }

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

        public string txtRFID
        {
            get { return _txtRFID; }
            set { _txtRFID = value; }
        }

        public int txtSize
        {
            get { return _txtSize; }
            set { _txtSize = value; }
        }

        public string txtUnit
        {
            get { return _txtUnit; }
            set { _txtUnit = value; }
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
                    Connection.dbCommand("UPDATE `flc`.`inventory` SET `Name` = '" + _txtName + "', `Category` = '" + _selectedCategory + "', `Quantity` = '" + _txtQuantity + "', `Size` = '" + _txtSize + "', `Unit` = '" + _txtUnit + "', `Critical_Level` = '" + _txtCriticalLevel + "', `RFID` = '" + _txtRFID + "' WHERE (`Item_ID` = '" + _selectedItemID + "');");
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

        protected override void OnActivate()
        {
            initializeValues();
            base.OnActivate();
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

        private void initializeValues()
        {
            DataTable dt = Connection.dbTable("select * from inventory where Item_ID =" + _selectedItemID + ";");
            _txtName = dt.Rows[0][1].ToString();
            _selectedCategory = dt.Rows[0][2].ToString();
            _txtQuantity = (int)dt.Rows[0][3];
            _txtSize = (int)dt.Rows[0][4];
            _txtUnit = dt.Rows[0][5].ToString();
            _txtCriticalLevel = (int)dt.Rows[0][6];
            _txtRFID = dt.Rows[0][7].ToString();
            NotifyOfPropertyChange(null);
        }
    }
}