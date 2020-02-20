using BLM.Models;
using Caliburn.Micro;
using System;
using System.Data;
using System.Windows;

namespace BLM.ViewModels.Requests.Forms
{
    internal class NewRequestViewModel : Screen
    {
        private DateTime _dateDue;
        private int _itemID;
        private object _materialsGridSelectedItem;
        private DataTable _materialsGridSource;
        private DateTime _selecteddateDue;
        private string _txtName;

        private int _txtQuantity;

        public NewRequestViewModel(int itemID)
        {
            _itemID = itemID;
            DataTable dt = Connection.dbTable("Select Name from Inventory where ID = '" + _itemID + "'");
            _txtName = dt.Rows[0][0].ToString();
            dt = Connection.dbTable("SELECT `inventory`.`Name`, `recipe`.`Quantity` AS 'Required Quantity', `inventory`.`Quantity` AS 'Stock on Hand' FROM `flc`.`inventory` INNER JOIN `flc`.`recipe` ON `inventory`.`ID` = `recipe`.`Ingredient_ID` WHERE `recipe`.`Item_ID` = '" + _itemID + "'");
            _materialsGridSource = dt;
            _dateDue = DateTime.Now;
            NotifyOfPropertyChange(null);
        }

        public DateTime dateDue
        {
            get { return _dateDue; }
            set { _dateDue = value; }
        }

        public object materialsGridSelectedItem
        {
            get { return _materialsGridSelectedItem; }
            set { _materialsGridSelectedItem = value; }
        }

        public DataTable materialsGridSource
        {
            get { return _materialsGridSource; }
            set { _materialsGridSource = value; }
        }

        public DateTime selecteddateDue
        {
            get { return _selecteddateDue; }
            set { _selecteddateDue = value; }
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
                    Connection.dbCommand("INSERT INTO `flc`.`production_requests` (`Recipe_ID`, `status`, `theoretical_yield`, `due_date`, `Requested_By`) VALUES ('" + _itemID + "', 'pending', '" + _txtQuantity + "', '" + _dateDue.ToString("yyyy-MM-dd") + "', '" + CurrentUser.User_ID + "');");
                    Connection.dbCommand(@"INSERT INTO `flc`.`system_log` (`User_ID`, `Subject`, `Body`, `Category`) VALUES ('" + CurrentUser.User_ID + "', '" + _txtName + "(x" + _txtQuantity + ") was requested','" + _txtName + "(x" + _txtQuantity + ") was requested by " + CurrentUser.name + " on " + DateTime.Now.ToString() + "', 'Production Request');");
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
            if (string.IsNullOrEmpty(_txtQuantity.ToString()) || _txtQuantity < 1)
                return false;
            else
                return true;
        }
    }
}