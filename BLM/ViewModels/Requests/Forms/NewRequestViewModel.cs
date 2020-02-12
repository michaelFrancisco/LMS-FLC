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
        private DateTime _selecteddateDue;
        private string _txtName;

        private int _txtQuantity;

        public NewRequestViewModel(int itemID)
        {
            _itemID = itemID;
            DataTable dt = Connection.dbTable("Select Name from Inventory where Item_ID = '" + _itemID + "'");
            _txtName = dt.Rows[0][0].ToString();
            _dateDue = DateTime.Now;
            NotifyOfPropertyChange(null);
        }

        public DateTime dateDue
        {
            get { return _dateDue; }
            set { _dateDue = value; }
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
                    Connection.dbCommand("INSERT INTO `flc`.`request_production` (`inventory_Item_ID`, `status`, `theoretical_yield`, `due_date`) VALUES ('" + _itemID + "', 'pending', '" + _txtQuantity + "', '" + _dateDue.ToString("yyyy-MM-dd") + "');");
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