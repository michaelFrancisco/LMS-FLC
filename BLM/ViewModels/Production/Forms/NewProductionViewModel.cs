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

        private Visibility _QuantityBoxVisibility;

        private DataTable _receivedGridSource;
        private string _txtID;
        private string _txtProductName;

        private string _txtRFID;

        private int _txtTheoreticalYield;

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

        public int txtTheoreticalYield
        {
            get { return _txtTheoreticalYield; }
            set { _txtTheoreticalYield = value; }
        }

        private DataTable _tempoTable;

        public DataTable templTable
        {
            get { return _tempoTable; }
            set { _tempoTable = value; }
        }


        public void btnConfirm()
        {
            foreach (DataRow row in _receivedGridSource.Rows)
            {
                Connection.dbCommand("INSERT INTO `flc`.`production` (`prod_name`, `prod_category`, `prod_qty`, `prod_received_weight`, `prod_size`, `prod_unit`,`prod_size`,`prod_size`)" +
                    "VALUES('" + row[0] + "', '" + row[1] + "', '" + row[2] + "', '" + row[3] + "', '" + row[4] + "','" + row[5] + "','" + _txtProductName + "','" + _txtTheoreticalYield + "');");
            }
            _receivedGridSource = Connection.dbTable("Select item_name as 'ITEM', category as 'CATEGORY', quantity as 'QUANTITY', weight as 'WEIGHT', size as 'SIZE', unit as 'UNIT' from flc.inventory_production where rfid='" + _txtRFID + "' And status='pending'");

            NotifyOfPropertyChange(() => receivedGridSource);
        }
        public void btnOK()
        {
            _itemGridSource = Connection.dbTable("Select * from flc.inventory_production where rfid='" + _txtRFID + "' And status='pending'");
            _txtID = _txtRFID;
       _tempoTable = Connection.dbTable("Select product_name from flc.inventory_production where rfid='" + _txtRFID + "' And status='pending'");
            _txtProductName = _tempoTable;
            NotifyOfPropertyChange(() => txtID);
            NotifyOfPropertyChange(() => itemGridSource);
            NotifyOfPropertyChange(() => txtRFID);
            _QuantityBoxVisibility = System.Windows.Visibility.Collapsed;
            NotifyOfPropertyChange(() => QuantityBoxVisibility);
        }

        public void btnReceive()
        {
            _receivedGridSource = Connection.dbTable("Select item_name as 'ITEM', category as 'CATEGORY', quantity as 'QUANTITY', weight as 'WEIGHT', size as 'SIZE', unit as 'UNIT' from flc.inventory_production where rfid='" + _txtRFID + "' And status='pending'");
            Connection.dbCommand("UPDATE `flc`.`inventory_production` SET `status` = 'received' WHERE(`rfid` = '" + _txtRFID + "');");
            _itemGridSource = Connection.dbTable("Select * from flc.inventory_production where rfid='" + _txtRFID + "' And status='pending'");
            NotifyOfPropertyChange(() => itemGridSource);
            NotifyOfPropertyChange(() => receivedGridSource);
        }
        protected override void OnActivate()
        {
            NotifyOfPropertyChange(null);
            base.OnActivate();
        }
    }
}