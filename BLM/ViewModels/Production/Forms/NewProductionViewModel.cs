using BLM.Models;
using Caliburn.Micro;
using System;
using System.Data;
using System.Windows;

namespace BLM.ViewModels.Production.Forms
{
    internal class NewProductionViewModel : Screen
    {
        private DataTable _materialsGridSource;
        private DateTime _dateDue;
        private DateTime _selecteddateDue;
        private int _selectedRequestID;
        private int _txtQuantity;
        private object _materialsGridSelectedItem;
        private readonly IWindowManager windowManager = new WindowManager();
        private string _txtName;
        private string _txtRequest;

        public NewProductionViewModel(int selectedRequestID)
        {
            _selectedRequestID = selectedRequestID;
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

        public string txtRequest
        {
            get { return _txtRequest; }
            set { _txtRequest = value; }
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
            //Connection.dbCommand("INSERT INTO `flc`.`production_requests` (`Recipe_ID`, `status`, `theoretical_yield`, `due_date`, `Requested_By`) VALUES ('" + _itemID + "', 'Pending', '" + _txtQuantity + "', '" + _dateDue.ToString("yyyy-MM-dd") + "', '" + CurrentUser.User_ID + "');");
            //Connection.dbCommand(@"INSERT INTO `flc`.`system_log` (`User_ID`, `Subject`, `Body`, `Category`) VALUES ('" + CurrentUser.User_ID + "', '" + _txtName + "(x" + _txtQuantity + ") was requested','" + _txtName + "(x" + _txtQuantity + ") was requested by " + CurrentUser.name + " on " + DateTime.Now.ToString() + "', 'Production Request');");
            TryClose();
        }

        protected override void OnActivate()
        {
            DataTable dt = Connection.dbTable("SELECT `inventory`.`Name`, `production_requests`.`Theoretical_Yield`, `production_requests`.`Due_Date` FROM `flc`.`inventory` INNER JOIN `flc`.`production_requests` ON `inventory`.`ID` = `production_requests`.`Recipe_ID` where `production_requests`.`ID` = '" + _selectedRequestID + "'; ");
            _txtName = dt.Rows[0][0].ToString();
            _txtQuantity = (int)dt.Rows[0][1];
            _dateDue = (DateTime)dt.Rows[0][2];
            _materialsGridSource = Connection.dbTable("SELECT `inventory`.`ID`, `inventory`.`Name`, `recipe`.`Quantity` AS 'Required Quantity' FROM `flc`.`inventory` INNER JOIN `flc`.`recipe` ON `inventory`.`ID` = `recipe`.`Ingredient_ID` INNER JOIN `flc`.`supplier` ON `supplier`.`ID` = `inventory`.`Supplier_ID` WHERE `inventory`.`ID` = '" + dt.Rows[0][3].ToString() + "'");
            NotifyOfPropertyChange(null);
            base.OnActivate();
        }
    }
}