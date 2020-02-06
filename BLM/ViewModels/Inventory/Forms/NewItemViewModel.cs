using BLM.Models;
using Caliburn.Micro;
using System.Collections.Generic;
using System.Windows;

namespace BLM.ViewModels.Inventory.Forms
{
    internal class NewItemViewModel : Screen
    {
        private List<string> _cmbCategory;
        private string _selectedCategory;
        private int _txtCriticalLevel;
        private string _txtName;
        private int _txtQuantity;
        private int _txtSize;
        private string _txtUnit;

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
                    Connection.dbCommand("INSERT INTO `flc`.`inventory` (`Name`, `Category`, `Quantity`, `Size`, `Unit`, `Critical_Level`) VALUES('" + _txtName + "', '" + _selectedCategory + "', '" + _txtQuantity + "', '" + _txtSize + "', '" + _txtUnit + "', '" + _txtCriticalLevel + "');");
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