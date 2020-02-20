using BLM.Models;
using Caliburn.Micro;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        private string _txtRequest;
        private Visibility _warningVisibility;

        public NewRequestViewModel(int itemID)
        {
            _itemID = itemID;
            DataTable dt = Connection.dbTable("Select Name from Inventory where ID = '" + _itemID + "'");
            _txtName = dt.Rows[0][0].ToString();
            _materialsGridSource = Connection.dbTable("SELECT `inventory`.`Name`, `recipe`.`Quantity` AS 'Required Quantity', `inventory`.`Quantity` AS 'Stock on Hand',`inventory`.`ID`,`supplier`.`Email`,`supplier`.`Name` FROM `flc`.`inventory` INNER JOIN `flc`.`recipe` ON `inventory`.`ID` = `recipe`.`Ingredient_ID` inner join `flc`.`supplier` on `supplier`.`ID`=`inventory`.`Supplier_ID` WHERE `recipe`.`Item_ID` = '" + _itemID + "';");
            _dateDue = DateTime.Now;
            _warningVisibility = Visibility.Hidden;
            _txtRequest = "Request Production";
            raiseWarningIfNotEnoughMaterials();
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
            set
            {
                _txtQuantity = value;
                _materialsGridSource = Connection.dbTable("SELECT `inventory`.`Name`, `recipe`.`Quantity` AS 'Required Quantity', `inventory`.`Quantity` AS 'Stock on Hand',`inventory`.`ID`,`supplier`.`Email`,`supplier`.`Name` FROM `flc`.`inventory` INNER JOIN `flc`.`recipe` ON `inventory`.`ID` = `recipe`.`Ingredient_ID` inner join `flc`.`supplier` on `supplier`.`ID`=`inventory`.`Supplier_ID` WHERE `recipe`.`Item_ID` = '" + _itemID + "';; ");
                foreach (DataRow row in _materialsGridSource.Rows)
                {
                    row[1] = int.Parse(row[1].ToString()) * _txtQuantity;
                }
                raiseWarningIfNotEnoughMaterials();
                NotifyOfPropertyChange(() => materialsGridSource);
            }
        }

        public string txtRequest
        {
            get { return _txtRequest; }
            set { _txtRequest = value; }
        }

        public Visibility warningVisibility
        {
            get { return _warningVisibility; }
            set { _warningVisibility = value; }
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
                if (areRequiredFieldsComplete() && hasEnoughItems())
                {
                    Connection.dbCommand("INSERT INTO `flc`.`production_requests` (`Recipe_ID`, `status`, `theoretical_yield`, `due_date`, `Requested_By`) VALUES ('" + _itemID + "', 'pending', '" + _txtQuantity + "', '" + _dateDue.ToString("yyyy-MM-dd") + "', '" + CurrentUser.User_ID + "');");
                    Connection.dbCommand(@"INSERT INTO `flc`.`system_log` (`User_ID`, `Subject`, `Body`, `Category`) VALUES ('" + CurrentUser.User_ID + "', '" + _txtName + "(x" + _txtQuantity + ") was requested','" + _txtName + "(x" + _txtQuantity + ") was requested by " + CurrentUser.name + " on " + DateTime.Now.ToString() + "', 'Production Request');");
                    TryClose();
                }
                else if (!hasEnoughItems())
                {
                    emailSuppliers();
                    TryClose();
                }
                else if (!areRequiredFieldsComplete())
                {
                    MessageBox.Show("Please fill required fields");
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public List<MissingMaterial> GetListOfMissingMaterials()
        {
            List<MissingMaterial> missingMaterialsList = new List<MissingMaterial>();
            foreach (DataRow row in _materialsGridSource.Rows)
            {
                if (int.Parse(row[1].ToString()) > int.Parse(row[2].ToString()))
                {
                    MissingMaterial missingMaterial = new MissingMaterial();
                    missingMaterial.MaterialName = row[0].ToString();
                    missingMaterial.Email = row[4].ToString();
                    missingMaterial.RequiredQuantity = int.Parse(row[1].ToString()) - int.Parse(row[2].ToString());
                    missingMaterial.SupplierName = row[5].ToString();
                    missingMaterialsList.Add(missingMaterial);
                }
            }
            return missingMaterialsList;
        }

        private bool areRequiredFieldsComplete()
        {
            if (string.IsNullOrEmpty(_txtQuantity.ToString()) || _txtQuantity < 1)
                return false;
            else
                return true;
        }

        private bool hasEnoughItems()
        {
            foreach (DataRow row in _materialsGridSource.Rows)
            {
                if (int.Parse(row[1].ToString()) > int.Parse(row[2].ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        private void raiseWarningIfNotEnoughMaterials()
        {
            if (hasEnoughItems())
            {
                _warningVisibility = Visibility.Hidden;
                _txtRequest = "Request Production";
            }
            else
            {
                _warningVisibility = Visibility.Visible;
                _txtRequest = "Order from supplier";
            }
            NotifyOfPropertyChange(() => txtRequest);
            NotifyOfPropertyChange(() => warningVisibility);
        }

        private void emailSuppliers()
        {
            var emailGroups = from MissingMaterial in GetListOfMissingMaterials() group MissingMaterial by MissingMaterial.Email;
            ArrayList materials = new ArrayList();
            foreach (var group in emailGroups)
            {
                string subject = "Request for materials";
                string email = group.Key;
                string name = "";
                string body = @"We would like to request the following materials: ";
                foreach(var material in group)
                {
                    name = material.SupplierName;
                    body += System.Environment.NewLine + material.MaterialName + "(x" + material.RequiredQuantity + ")";
                }
                body += System.Environment.NewLine + "We hope to receive your reply as soon as possible.";
                body += System.Environment.NewLine + "Thank you.";
                body += System.Environment.NewLine + "[THIS IS AN AUTOMATED MESSAGE - PLEASE DO NOT REPLY DIRECTLY TO THIS EMAIL]";
                Connection.sendEmail(subject, body, name, email);
            }
        }

        

        public class MissingMaterial
        {
            public string SupplierName;
            public string Email;
            public string MaterialName;
            public int RequiredQuantity;
        }
    }
}