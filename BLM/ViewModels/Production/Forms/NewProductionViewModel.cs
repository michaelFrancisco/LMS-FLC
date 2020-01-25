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
        private Visibility _QuantityBoxVisibility;
        private DataTable _receivedGridSource;
        private DataTable _tempoTable;
        private string _txtID;
        private string _txtProductName;
        private string _txtRFID;
        private string _txtTheoreticalYield;

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
            set { _txtProductName = value; }
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
            set { _txtTheoreticalYield = value; }
        }

        public void btnConfirm()
        {
            foreach (DataRow row in _receivedGridSource.Rows)
            {
                Connection.dbCommand("INSERT INTO `flc`.`production` (`prod_item_name`, `prod_category`, `prod_theoretical_yield`, `prod_actual_yield`, `prod_percent_yield`, `prod_qty`, `prod_received_weight`, `prod_size`, `prod_unit`, `prod_status`, `prod_rfid`, `prod_name`)" +
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
                "FROM inventory_production WHERE status = 'pending' and rfid = " + _txtRFID + "");
        }

        public void btnOK()
        {
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
                "FROM inventory_production WHERE status = 'pending' and rfid = " + _txtRFID + "");

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
                "FROM inventory_production WHERE status = 'pending' and rfid = " + _txtRFID + "");
            NotifyOfPropertyChange(() => receivedGridSource);

            Connection.dbCommand("UPDATE `flc`.`inventory_production` SET `status` = 'received' WHERE(`rfid` = '" + _txtRFID + "');");

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
                "FROM inventory_production WHERE status = 'pending' and rfid = " + _txtRFID + "");
            NotifyOfPropertyChange(() => itemGridSource);
            btnConfirm();
        }

        protected override void OnActivate()
        {
            NotifyOfPropertyChange(null);
            base.OnActivate();
        }

        public void btnCancel()
        {
            TryClose();
            NotifyOfPropertyChange(null);
        }
    }
}