using BLM.Models;
using Caliburn.Micro;
using System;
using System.Data;
using System.Windows;

namespace BLM.ViewModels.Inventory.Forms
{
    internal class RequestViewModel : Screen
    {
        private DataTable _requestGridSource;
        private string _txtMO;

        public RequestViewModel(string MO_ID)
        {
            _txtMO = MO_ID.ToString();
            _requestGridSource = Connection.dbTable("SELECT b.inventory_Item_ID, b.item_name, a.recipe_id, a.quantity, c.request_production_id FROM mo_recipe AS a INNER JOIN recipe AS b ON a.recipe_id = b.id inner join manufacturing_order as c on a.manufacturing_order_id = c.id where a.manufacturing_order_id = '" + MO_ID + "';");

            NotifyOfPropertyChange(null);
        }

        public DataTable requestGridSource
        {
            get { return _requestGridSource; }
            set { _requestGridSource = value; }
        }

        public string txtMO
        {
            get { return _txtMO; }
            set { _txtMO = value; }
        }

        public void btnApprove()
        {
            bool hasEnoughItems = true;
            foreach (DataRow row in _requestGridSource.Rows)
            {
                DataTable dt = Connection.dbTable("select `inventory`.`Item_ID`,`inventory`.`Quantity` from `flc`.`inventory` where `inventory`.`Name` = '" + row[1].ToString() + "';");
                int currentQuantity = (int)dt.Rows[0][1];
                int requestedQuantity = int.Parse(row[3].ToString());
                int itemID = int.Parse(dt.Rows[0][0].ToString());
                currentQuantity -= requestedQuantity;
                if (currentQuantity < 0)
                {
                    hasEnoughItems = false;
                }
            }
            if (hasEnoughItems)
            {
                foreach (DataRow row in _requestGridSource.Rows)
                {
                    DataTable dt = Connection.dbTable("select `inventory`.`Item_ID`,`inventory`.`Quantity` from `flc`.`inventory` where `inventory`.`Name` = '" + row[1].ToString() + "';");
                    int currentQuantity = (int)dt.Rows[0][1];
                    int requestedQuantity = int.Parse(row[3].ToString());
                    int itemID = int.Parse(dt.Rows[0][0].ToString());
                    Connection.dbCommand("UPDATE `flc`.`inventory` SET `Quantity` = '" + (currentQuantity - requestedQuantity) + "' WHERE (`Item_ID` = '" + itemID + "');");
                    Connection.dbCommand("INSERT INTO `flc`.`system_log` (`User_ID`, `Subject`, `Body`) VALUES ('" + CurrentUser.User_ID + "', '" + row[1].ToString() + "(" + requestedQuantity + ") was reduced from inventory', '" + row[1].ToString() + "(" + requestedQuantity + ") was reduced from inventory from Manufacturing Order no." + _txtMO + " and approved by " + CurrentUser.name + " on " + DateTime.Now.ToString() + "');");
                }
                Connection.dbCommand("UPDATE `flc`.`manufacturing_order` SET `status` = 'processing' WHERE (`id` = '" + _txtMO + "');");
                Connection.dbCommand("UPDATE `flc`.`request_production` SET `status` = 'processing' WHERE (`id` = '" + _requestGridSource.Rows[0][4] + "');");
            }
            else
            {
                MessageBox.Show("Not enough items!");
            }
        }
    }
}