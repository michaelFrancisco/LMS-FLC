using BLM.Models;
using Caliburn.Micro;
using System.Data;
using System.Windows;

namespace BLM.ViewModels.Shipments.Forms
{
    internal class EditShipmentViewModel : Screen
    {
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
            _shipmentData = Connection.dbTable("Select * from shipments;");
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
                return _shipmentData.Rows[0][1].ToString();
            }
            set { _lblCategory = value; }
        }

        public string lblDateDue
        {
            get
            {
                return _shipmentData.Rows[0][7].ToString();
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
                return _shipmentData.Rows[0][4].ToString();
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
                return _shipmentData.Rows[0][3].ToString();
            }
            set { _lblOrigin = value; }
        }

        protected override void OnActivate()
        {
            _itemGridSource = Connection.dbTable("SELECT `shipment_items`.`Shipment_Item_ID`, `inventory`.`Name`,`inventory`.`Category`,`shipment_items`.`Quantity`,`inventory`.`Size`,`inventory`.`Unit`,`shipment_items`.`Status` FROM flc.inventory inner join flc.shipment_items on flc.inventory.Item_ID = flc.shipment_items.Item_ID where flc.shipment_items.Shipment_ID = '" + _selectedShipmentID + "';");
            base.OnActivate();
        }

        public void btnComplete()
        {
            try
            {
                DataRowView row = (DataRowView)_itemGridSelectedItem;
                row[6] = "Complete";
            }
            catch (System.Exception)
            {
            }
        }

        public void btnIncomplete()
        {
            try
            {
                DataRowView row = (DataRowView)_itemGridSelectedItem;
                row[6] = "Incomplete";
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
            }
            catch (System.Exception)
            {
            }
        }

        public void btnSave()
        {
            foreach (DataRow row in _itemGridSource.Rows)
            {
                Connection.dbCommand(@"UPDATE `flc`.`shipment_items` SET `Status` = '" + row[6].ToString() + "' WHERE (`Shipment_Item_ID` = '" + row[0].ToString() + "');");
            }
            DataTable markedforReturn = Connection.dbTable("Select * from shipment_items where `Shipment_ID` = '" + _selectedShipmentID + "' and Status = 'For Return'");
            DataTable markedasIncomplete = Connection.dbTable("Select * from shipment_items where `Shipment_ID` = '" + _selectedShipmentID + "' and Status = 'Incomplete'");
            if (markedforReturn.Rows.Count > 0 || markedasIncomplete.Rows.Count > 0)
            {
                MessageBox.Show("Some items are marked as INCOMPLETE or FOR RETURN, this shipment will be marked as INCOMPLETE");
                Connection.dbCommand("UPDATE `flc`.`shipments` SET `Status` = 'Incomplete' WHERE (`Shipment_ID` = '" + _selectedShipmentID + "');");
            }
            else
            {
                Connection.dbCommand("UPDATE `flc`.`shipments` SET `Status` = 'Complete' WHERE (`Shipment_ID` = '" + _selectedShipmentID + "');");
            }
            TryClose();
        }

        public void btnCancel()
        {
            MessageBoxResult dialogResult = MessageBox.Show("Are you sure? Unsaved changes will be lost.", "!", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                TryClose();
            }
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

        public string lblTruck
        {
            get
            {
                DataTable dt = Connection.dbTable("Select Name from trucks where Truck_ID = '" + _shipmentData.Rows[0][7].ToString() + "'");
                return dt.Rows[0][0].ToString();
            }
            set { _lblTruck = value; }
        }
    }
}