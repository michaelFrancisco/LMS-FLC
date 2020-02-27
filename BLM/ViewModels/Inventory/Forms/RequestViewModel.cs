using BLM.Models;
using Caliburn.Micro;
using System;
using System.Data;
using System.Windows;

namespace BLM.ViewModels.Inventory.Forms
{
    internal class RequestViewModel : Screen
    {
        private readonly IWindowManager windowManager = new WindowManager();
        private DateTime _dateDue;
        private object _materialsGridSelectedItem;
        private DataTable _materialsGridSource;
        private int _recipeID;
        private DateTime _selecteddateDue;
        private int _selectedRequestID;
        private string _txtName;
        private int _txtQuantity;
        private string _txtRequest;

        public RequestViewModel(int selectedRequestID)
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
            MessageBoxResult dialogResult = MessageBox.Show("All raw materials are complete and in good condition?", "!", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                Connection.dbCommand("UPDATE `flc`.`production_requests` SET `Status` = 'Raw Materials delivered to Production team. Awaiting confirmation' WHERE (`ID` = '" + _selectedRequestID + "');");
                foreach (DataRow row in _materialsGridSource.Rows)
                {
                    DataTable currentQuantity = Connection.dbTable("SELECT Quantity FROM flc.inventory where ID = " + row[2].ToString() + ";");
                    Connection.dbCommand("UPDATE `flc`.`inventory` SET `Quantity` = '" + (((int)currentQuantity.Rows[0][0]) - (int)row[1]).ToString() + "' WHERE (`ID` = '" + row[2].ToString() + "');");
                    Connection.dbCommand("INSERT INTO `flc`.`system_log` (`Subject`, `Category`, `User_ID`, `Body`) VALUES ('" + row[0].ToString() + "(x" + row[1].ToString() + ") was reduced from inventory', 'Inventory Update', '" + CurrentUser.User_ID.ToString() + "', '" + row[0].ToString() + "(x" + row[1].ToString() + ") was reduced from inventory from Request no." + _selectedRequestID.ToString() + " and approved by " + CurrentUser.name + " on " + System.DateTime.Now.ToString() + "');");
                }
                TryClose();
            }
        }

        protected override void OnActivate()
        {
            DataTable dt = Connection.dbTable("SELECT `inventory`.`Name`, `production_requests`.`Theoretical_Yield`, `production_requests`.`Due_Date`,`production_requests`.`Recipe_ID` FROM `flc`.`inventory` INNER JOIN `flc`.`production_requests` ON `inventory`.`ID` = `production_requests`.`Recipe_ID` where `production_requests`.`ID` = '" + _selectedRequestID + "'; ");
            _txtName = dt.Rows[0][0].ToString();
            _txtQuantity = (int)dt.Rows[0][1];
            _dateDue = (DateTime)dt.Rows[0][2];
            _recipeID = Int32.Parse(dt.Rows[0][3].ToString());
            _materialsGridSource = Connection.dbTable("SELECT `inventory`.`Name`, `recipe`.`Quantity` AS 'Required Quantity',`inventory`.`ID` FROM `flc`.`inventory` INNER JOIN `flc`.`recipe` ON `inventory`.`ID` = `recipe`.`Ingredient_ID` inner join `flc`.`supplier` on `supplier`.`ID`=`inventory`.`Supplier_ID` WHERE `recipe`.`Item_ID` = '" + dt.Rows[0][3] + "'");
            foreach (DataRow row in _materialsGridSource.Rows)
            {
                row[1] = int.Parse(row[1].ToString()) * _txtQuantity;
            }
            NotifyOfPropertyChange(null);
            base.OnActivate();
        }
    }
}