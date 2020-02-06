using BLM.Models;
using System.Data;
using System.Windows;

namespace BLM.ViewModels.Shipments.Forms
{
    internal class EditShipmentViewModel : Caliburn.Micro.Screen
    {
        private System.Int32 _itemGridSelectedIndex;
        private object _itemGridSelectedItem;
        private DataTable _itemGridSource;
        private string _lblCategory;
        private string _lblDateDue;
        private string _lblDeliveryAgent;
        private string _lblDestination;
        private string _lblItemCategory;
        private string _lblItemName;
        private string _lblItemQuantity;
        private string _lblItemSize;
        private string _lblOrigin;
        private string _lblTruck;
        private int _selectedShipmentID;
        private DataTable _shipmentData;

        public EditShipmentViewModel(int selectedShipmentID)
        {
            _selectedShipmentID = selectedShipmentID;
            _shipmentData = Connection.dbTable("Select * from shipments WHERE Shipment_ID = '" + _selectedShipmentID + "';");
        }

        public System.Int32 itemGridSelectedIndex
        {
            get { return _itemGridSelectedIndex; }
            set { _itemGridSelectedIndex = value; }
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

        public string lblCategory
        {
            get
            {
                return _shipmentData.Rows[0][2].ToString();
            }
            set { _lblCategory = value; }
        }

        public string lblDateDue
        {
            get
            {
                return _shipmentData.Rows[0][9].ToString();
            }
            set { _lblDateDue = value; }
        }

        public string lblDeliveryAgent
        {
            get
            {
                DataTable dt = Connection.dbTable("Select Name from users where User_ID = '" + _shipmentData.Rows[0][7].ToString() + "'");
                return dt.Rows[0][0].ToString();
            }
            set { _lblDeliveryAgent = value; }
        }

        public string lblDestination
        {
            get
            {
                return _shipmentData.Rows[0][5].ToString();
            }
            set { _lblDestination = value; }
        }

        public string lblItemCategory
        {
            get { return _lblItemCategory; }
            set { _lblItemCategory = value; }
        }

        public string lblItemName
        {
            get { return _lblItemName; }
            set { _lblItemName = value; }
        }

        public string lblItemQuantity
        {
            get { return _lblItemQuantity; }
            set { _lblItemQuantity = value; }
        }

        public string lblItemSize
        {
            get { return _lblItemSize; }
            set { _lblItemSize = value; }
        }

        public string lblOrigin
        {
            get
            {
                return _shipmentData.Rows[0][4].ToString();
            }
            set { _lblOrigin = value; }
        }

        public string lblTruck
        {
            get
            {
                DataTable dt = Connection.dbTable("Select Name from trucks where Truck_ID = '" + _shipmentData.Rows[0][1].ToString() + "'");
                return dt.Rows[0][0].ToString();
            }
            set { _lblTruck = value; }
        }

        public void btnCancel()
        {
            MessageBoxResult dialogResult = System.Windows.MessageBox.Show("Are you sure? Unsaved changes will be lost.", "!", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                TryClose();
            }
        }

        public void btnComplete()
        {
            try
            {
                DataRowView row = (DataRowView)_itemGridSelectedItem;
                row[6] = "Complete";
                _itemGridSelectedIndex++;
                NotifyOfPropertyChange(() => itemGridSelectedIndex);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public void btnIncomplete()
        {
            try
            {
                DataRowView row = (DataRowView)_itemGridSelectedItem;
                row[6] = "Incomplete";
                _itemGridSelectedIndex++;
                NotifyOfPropertyChange(() => itemGridSelectedIndex);
            }
            catch (System.Exception)
            {
            }
        }

        public void btnReturn()
        {
            try
            {
                DataRowView row = (DataRowView)_itemGridSelectedItem;
                row[6] = "For Return";
                _itemGridSelectedIndex++;
                NotifyOfPropertyChange(() => itemGridSelectedIndex);
            }
            catch (System.Exception)
            {
            }
        }

        public void btnSave()
        {
            if (_shipmentData.Rows[0][2].ToString() == "Inbound")
            {
                foreach (DataRow row in _itemGridSource.Rows)
                {
                    Connection.dbCommand(@"UPDATE `flc`.`shipment_items` SET `Status` = '" + row[6].ToString() + "' WHERE (`Shipment_Item_ID` = '" + row[0].ToString() + "');");
                }
                DataTable markedforReturn = Connection.dbTable("Select * from shipment_items where `Shipment_ID` = '" + _selectedShipmentID + "' and Status = 'For Return'");
                DataTable markedasIncomplete = Connection.dbTable("Select * from shipment_items where `Shipment_ID` = '" + _selectedShipmentID + "' and Status = 'Incomplete'");
                if (markedforReturn.Rows.Count > 0 || markedasIncomplete.Rows.Count > 0)
                {
                    System.Windows.MessageBox.Show("Some items are marked as INCOMPLETE or FOR RETURN, this shipment will be marked as PENDING");
                    Connection.dbCommand("UPDATE `flc`.`shipments` SET `Status` = 'Pending' WHERE (`Shipment_ID` = '" + _selectedShipmentID + "');");
                }
                else
                {
                    Connection.dbCommand("UPDATE `flc`.`shipments` SET `Status` = 'Complete' WHERE (`Shipment_ID` = '" + _selectedShipmentID + "');");
                    foreach (DataRow row in _itemGridSource.Rows)
                    {
                        DataTable currentQuantity = Connection.dbTable("SELECT Quantity FROM flc.inventory where Item_ID = " + row[7].ToString() + ";");
                        Connection.dbCommand("UPDATE `flc`.`inventory` SET `Quantity` = '" + (((int)currentQuantity.Rows[0][0]) + (int)row[3]).ToString() + "' WHERE (`Item_ID` = '" + row[0].ToString() + "');");
                        Connection.dbCommand("INSERT INTO `flc`.`system_log` (`Subject`, `Category`, `User_ID`, `Body`) VALUES ('" + row[1].ToString() + "(" + row[3].ToString() + ") was added to inventory', 'Inventory Update', '" + CurrentUser.User_ID.ToString() + "', '" + row[1].ToString() + "(" + row[3].ToString() + ") was added to inventory from Shipment no." + _selectedShipmentID.ToString() + " and approved by " + CurrentUser.name + " on " + System.DateTime.Now.ToString() + "');");
                    }
                }
            }
            else if (_shipmentData.Rows[0][2].ToString() == "Outbound")
            {
                foreach (DataRow row in _itemGridSource.Rows)
                {
                    Connection.dbCommand(@"UPDATE `flc`.`shipment_items` SET `Status` = '" + row[6].ToString() + "' WHERE (`Shipment_Item_ID` = '" + row[0].ToString() + "');");
                }
                DataTable markedforReturn = Connection.dbTable("Select * from shipment_items where `Shipment_ID` = '" + _selectedShipmentID + "' and Status = 'For Return'");
                DataTable markedasIncomplete = Connection.dbTable("Select * from shipment_items where `Shipment_ID` = '" + _selectedShipmentID + "' and Status = 'Incomplete'");
                if (markedforReturn.Rows.Count > 0 || markedasIncomplete.Rows.Count > 0)
                {
                    System.Windows.MessageBox.Show("Some items are marked as INCOMPLETE or FOR RETURN, this shipment will be marked as PENDING");
                    Connection.dbCommand("UPDATE `flc`.`shipments` SET `Status` = 'Pending' WHERE (`Shipment_ID` = '" + _selectedShipmentID + "');");
                }
                else
                {
                    Connection.dbCommand("UPDATE `flc`.`shipments` SET `Status` = 'Complete' WHERE (`Shipment_ID` = '" + _selectedShipmentID + "');");
                    foreach (DataRow row in _itemGridSource.Rows)
                    {
                        DataTable currentQuantity = Connection.dbTable("SELECT Quantity FROM flc.inventory where Item_ID = " + row[7].ToString() + ";");
                        Connection.dbCommand("UPDATE `flc`.`inventory` SET `Quantity` = '" + (((int)currentQuantity.Rows[0][0]) - (int)row[3]).ToString() + "' WHERE (`Item_ID` = '" + row[0].ToString() + "');");
                        Connection.dbCommand("INSERT INTO `flc`.`system_log` (`Subject`, `Category`, `User_ID`, `Body`) VALUES ('" + row[1].ToString() + "(" + row[3].ToString() + ") was reduced from inventory', 'Inventory Update', '" + CurrentUser.User_ID.ToString() + "', '" + row[1].ToString() + "(" + row[3].ToString() + ") was reduced from inventory from Shipment no." + _selectedShipmentID.ToString() + " and approved by " + CurrentUser.name + " on " + System.DateTime.Now.ToString() + "');");
                    }
                }
            }
            TryClose();
        }

        public void itemGridSelectionChanged()
        {
            try
            {
                DataRowView row = (DataRowView)_itemGridSelectedItem;
                _lblItemName = row[1].ToString();
                _lblItemCategory = row[2].ToString();
                _lblItemSize = row[4].ToString() + row[5].ToString();
                _lblItemQuantity = row[3].ToString();
                NotifyOfPropertyChange(null);
            }
            catch
            {
            }
        }

        protected override void OnActivate()
        {
            _itemGridSource = Connection.dbTable("SELECT `shipment_items`.`Shipment_Item_ID`, `inventory`.`Name`,`inventory`.`Category`,`shipment_items`.`Quantity`,`inventory`.`Size`,`inventory`.`Unit`,`shipment_items`.`Status` ,`inventory`.`Item_ID` FROM flc.inventory inner join flc.shipment_items on flc.inventory.Item_ID = flc.shipment_items.Item_ID where flc.shipment_items.Shipment_ID = '" + _selectedShipmentID + "';");
            base.OnActivate();
        }
    }
}