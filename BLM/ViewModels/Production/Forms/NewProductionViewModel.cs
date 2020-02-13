using BLM.Models;
using Caliburn.Micro;
using System;
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
        private string _txtMO;
        private string _txtProductName;
        private string _txtRFID;
        private string _txtTheoreticalYield;

     

        public NewProductionViewModel(string nameColumn, string theoretical, string id, string Item_ID, string Name)
        {
            _itemGridSource = Connection.dbTable(nameColumn);
            _txtProductName = Name.ToString();
            _txtTheoreticalYield = theoretical;
            _id = id;
            NotifyOfPropertyChange(null);
        }

        public string _id { get; set; }

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

        public string txtMO
        {
            get { return _txtMO; }
            set { _txtMO = value; }
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
           this.TryClose();
            NotifyOfPropertyChange(null);
        }

        public void btnConfirm()
        {
            //foreach (DataRow row in _receivedGridSource.Rows)
            //{
            //    Connection.dbCommand("INSERT INTO `flc`.`production` (`item_name`, `category`, `theoretical_yield`, `actual_yield`, `percent_yield`, `qty`, `received_weight`, `size`, `unit`, `status`, `rfid`, `name`)" +
            //        "VALUES('" + row[0] + "', '" + row[1] + "', '" + row[2] + "', '" + row[3] + "', '" + row[4] + "', '" + row[5] + "', '" + row[6] + "', '" + row[7] + "', '" + row[8] + "', '" + row[9] + "', '" + row[10] + "', '" + row[11] + "');");
            //}
            //_receivedGridSource = Connection.dbTable(
            //    "SELECT item_name as 'NAME'," +
            //    "category as 'CATEGORY'," +
            //    "theoretical_yield as 'THEORETICAL'," +
            //    "actual_yield as 'ACTUAL'," +
            //    "percent_yield as 'PERCENT'," +
            //    "quantity as 'QUANTITY'," +
            //    "weight as 'WEIGHT'," +
            //    "size as 'SIZE'," +
            //    "unit as 'UNIT'," +
            //    "status as 'STATUS'," +
            //    "rfid as 'RFID'," +
            //    "product_name " +
            //    "FROM request_production WHERE status = 'pending' and rfid = " + _txtRFID + "");
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
        //    _receivedGridSource = Connection.dbTable(
        //        "SELECT item_name as 'NAME'," +
        //        "category as 'CATEGORY'," +
        //        "theoretical_yield as 'THEORETICAL'," +
        //        "actual_yield as 'ACTUAL'," +
        //        "percent_yield as 'PERCENT'," +
        //        "quantity as 'QUANTITY'," +
        //        "weight as 'WEIGHT'," +
        //        "size as 'SIZE'," +
        //        "unit as 'UNIT'," +
        //        "status as 'STATUS'," +
        //        "rfid as 'RFID'," +
        //        "product_name " +
        //        "FROM request_production WHERE status = 'pending' and rfid = " + _txtRFID + "");
        //    NotifyOfPropertyChange(() => receivedGridSource);

        //    Connection.dbCommand("UPDATE `flc`.`request_production` SET `status` = 'received' WHERE(`rfid` = '" + _txtRFID + "');");

        //    _itemGridSource = Connection.dbTable(
        //        "SELECT item_name as 'NAME'," +
        //        "category as 'CATEGORY'," +
        //        "theoretical_yield as 'THEORETICAL'," +
        //        "actual_yield as 'ACTUAL'," +
        //        "percent_yield as 'PERCENT'," +
        //        "quantity as 'QUANTITY'," +
        //        "weight as 'WEIGHT'," +
        //        "size as 'SIZE'," +
        //        "unit as 'UNIT'," +
        //        "status as 'STATUS'," +
        //        "rfid as 'RFID'," +
        //        "product_name " +
        //        "FROM request_production WHERE status = 'pending' and rfid = " + _txtRFID + "");
        //    NotifyOfPropertyChange(() => itemGridSource);
        //    btnConfirm();
        }
        public void btnSend()
        {

            try
            {
                Connection.dbCommand(
   "INSERT INTO `flc`.`manufacturing_order` " +
   "(`request_production_id`) VALUES ('" + _id + "');");

                foreach (DataRow row in _itemGridSource.Rows)
                {
                    DataTable recipe_id = Connection.dbTable(
                        "select a.`id` as 'Recipe_id', " +
                        "a.`item_name`, " +
                        "c.`id`, " +
                        "c.`request_production_id` " +
                        "from flc.recipe as a " +
                        "inner join mo_recipe as b " +
                        "on a.id = b.recipe_id " +
                        "inner join manufacturing_order as c " +
                        "inner join request_production as d " +
                        "on c.request_production_id = d.id " +
                        "inner join inventory as e " +
                        "on d.inventory_Item_ID = e.Item_ID " +
                        "where a.inventory_Item_ID = '" + row[4] + "' " +
                        "and request_production_id = '" + _id + "';");

                    Connection.dbCommand(
                        "INSERT INTO `flc`.`mo_recipe` " +
                        "(`manufacturing_order_id`, `recipe_id`, `quantity`) " +
                        "VALUES ('" + Int32.Parse(_txtMO) + "', '" + recipe_id.Rows[0][0] + "', '" + row[2] + "');");
                }
                MessageBox.Show("Manufacturing Order Successfully Created!");
                this.TryClose();
            }
            catch (Exception)
            {
                MessageBox.Show("The product recipe for ('"+ _txtProductName +"') is no longer exist.");
            }
        }
        protected override void OnActivate()
        {
            foreach (DataRow row in _itemGridSource.Rows)
            {
                DataTable txtMO = Connection.dbTable("select max(`id`) + 1 from flc.`manufacturing_order`;");
                _txtMO = txtMO.Rows[0][0].ToString();
                NotifyOfPropertyChange(null);
            }
            NotifyOfPropertyChange(null);
            base.OnActivate();
        }
    }
}