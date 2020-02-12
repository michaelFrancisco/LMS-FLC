using BLM.Models;
using Caliburn.Micro;
using System.Data;
using System.Windows;

namespace BLM.ViewModels.Production.Forms
{
    internal class NewProductionViewModel : Screen
    {
        private bool _btnOkIsClicked;
        private DataTable _itemGridSource;
        private Visibility _newproductionviewVisibility;
        private object _productionGridSelectedItem;
        private Visibility _QuantityBoxVisibility;
        private DataTable _receivedGridSource;
        private DataTable _tempoTable;
        private string _txtID;
        private string _txtProductName;
        private string _txtRFID;
        private string _txtTheoreticalYield;

        public NewProductionViewModel(string nameColumn, string theoretical)
        {
            _itemGridSource = Connection.dbTable(nameColumn);
            _txtProductName = _itemGridSource.Rows[0][0].ToString();
            _txtTheoreticalYield = theoretical;
            NotifyOfPropertyChange(null);
        }

        public bool btnOkIsClicked
        {
            get { return _btnOkIsClicked; }
            set { _btnOkIsClicked = value; }
        }

        public DataTable itemGridSource
        {
            get { return _itemGridSource; }
            set { _itemGridSource = value; }
        }

        public Visibility newproductionviewVisibility
        {
            get { return _newproductionviewVisibility; }
            set { _newproductionviewVisibility = value; }
        }

        public object productionGridSelectedItem
        {
            get { return _productionGridSelectedItem; }
            set { _productionGridSelectedItem = value; }
        }

        public Visibility QuantityBoxVisibility
        {
            get { return _QuantityBoxVisibility; }
            set { _QuantityBoxVisibility = value; }
        }

        public DataTable receivedGridSource
        {
            get { return _receivedGridSource; }
            set { _receivedGridSource = value; }
        }

        public DataTable templTable
        {
            get { return _tempoTable; }
            set { _tempoTable = value; }
        }

        public string txtID
        {
            get { return _txtID; }
            set { _txtID = value; }
        }

        public string txtProductName
        {
            get { return _txtProductName; }
            set
            {
                _txtProductName = value;
            }
        }

        public string txtRFID
        {
            get { return _txtRFID; }
            set
            {
                _txtRFID = value;
            }
        }

        public string txtTheoreticalYield
        {
            get { return _txtTheoreticalYield; }
            set
            {
                _txtTheoreticalYield = value;
            }
        }

        public void btnCancel()
        {
            TryClose();
            NotifyOfPropertyChange(null);
        }

        public void btnConfirm()
        {
            foreach (DataRow row in _receivedGridSource.Rows)
            {
                Connection.dbCommand("INSERT INTO `flc`.`production` (`item_name`, `category`, `theoretical_yield`, `actual_yield`, `percent_yield`, `qty`, `received_weight`, `size`, `unit`, `status`, `rfid`, `name`)" +
                    "VALUES('" + row[0] + "', '" + row[1] + "', '" + row[2] + "', '" + row[3] + "', '" + row[4] + "', '" + row[5] + "', '" + row[6] + "', '" + row[7] + "', '" + row[8] + "', '" + row[9] + "', '" + row[10] + "', '" + row[11] + "');");
            }
            _receivedGridSource = Connection.dbTable(
                "SELECT item_name as 'NAME'," +
                "category as 'CATEGORY'," +
                "theoretical_yield as 'THEORETICAL'," +
                "actual_yield as 'ACTUAL'," +
                "percent_yield as 'PERCENT'," +
                "quantity as 'QUANTITY'," +
                "weight as 'WEIGHT'," +
                "size as 'SIZE'," +
                "unit as 'UNIT'," +
                "status as 'STATUS'," +
                "rfid as 'RFID'," +
                "product_name " +
                "FROM request_production WHERE status = 'pending' and rfid = " + _txtRFID + "");
        }

        public void btnOK()
        {
            _itemGridSource = Connection.dbTable("SELECT item_name as 'NAME', category as 'CATEGORY', theoretical_yield as 'THEORETICAL', actual_yield as 'ACTUAL', percent_yield as 'PERCENT', quantity as 'QUANTITY', weight as 'WEIGHT', size as 'SIZE', unit as 'UNIT', status as 'STATUS', rfid as 'RFID', product_name FROM request_production WHERE status = 'pending';");
            _txtID = _txtRFID;
            //putting Product Name in textbox
            _txtProductName = _itemGridSource.Rows[0][11].ToString();
            _txtTheoreticalYield = itemGridSource.Rows[0][2].ToString();
            _QuantityBoxVisibility = System.Windows.Visibility.Collapsed;
            NotifyOfPropertyChange(null);
        }

        public void btnReceive()
        {
            _receivedGridSource = Connection.dbTable(
                "SELECT item_name as 'NAME'," +
                "category as 'CATEGORY'," +
                "theoretical_yield as 'THEORETICAL'," +
                "actual_yield as 'ACTUAL'," +
                "percent_yield as 'PERCENT'," +
                "quantity as 'QUANTITY'," +
                "weight as 'WEIGHT'," +
                "size as 'SIZE'," +
                "unit as 'UNIT'," +
                "status as 'STATUS'," +
                "rfid as 'RFID'," +
                "product_name " +
                "FROM request_production WHERE status = 'pending' and rfid = " + _txtRFID + "");
            NotifyOfPropertyChange(() => receivedGridSource);

            Connection.dbCommand("UPDATE `flc`.`request_production` SET `status` = 'received' WHERE(`rfid` = '" + _txtRFID + "');");

            _itemGridSource = Connection.dbTable(
                "SELECT item_name as 'NAME'," +
                "category as 'CATEGORY'," +
                "theoretical_yield as 'THEORETICAL'," +
                "actual_yield as 'ACTUAL'," +
                "percent_yield as 'PERCENT'," +
                "quantity as 'QUANTITY'," +
                "weight as 'WEIGHT'," +
                "size as 'SIZE'," +
                "unit as 'UNIT'," +
                "status as 'STATUS'," +
                "rfid as 'RFID'," +
                "product_name " +
                "FROM request_production WHERE status = 'pending' and rfid = " + _txtRFID + "");
            NotifyOfPropertyChange(() => itemGridSource);
            btnConfirm();
        }

        protected override void OnActivate()
        {
            foreach (DataRow row in _itemGridSource.Rows)
            {
                // string requiredQuantity = row.Row[2].ToString();
                //                    DataTable currentQuantity = Connection.dbTable("SELECT `Required Quantity` FROM flc.recipe where name = " + row.Rows[2].ToString() + ";");
                _itemGridSource = Connection.dbTable("select a.`Name`, b.`item_name`, b.`size` * '" + _txtTheoreticalYield + "' as 'Required Quantity', b.`unit` from flc.inventory as a inner join flc.recipe as b on a.`Item_ID` = b.`inventory_Item_ID` where a.`Name` like '%" + _txtProductName + "%'");

                NotifyOfPropertyChange(null);
            }
            NotifyOfPropertyChange(null);
            base.OnActivate();
        }
    }
}