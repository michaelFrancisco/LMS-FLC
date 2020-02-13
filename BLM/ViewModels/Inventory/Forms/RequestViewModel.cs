using BLM.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLM.ViewModels.Inventory.Forms
{
    internal class RequestViewModel : Screen
    {
        private DataTable _requestGridSource;
        private string _txtMO;

        public string txtMO
        {
            get { return _txtMO; }
            set { _txtMO = value; }
        }

        public RequestViewModel(string MO_ID)
        {
            _txtMO = MO_ID.ToString();
            _requestGridSource = Connection.dbTable(
                "select b.inventory_Item_ID, " +
                "b.item_name, " +
                "a.recipe_id, " +
                "a.quantity from mo_recipe as a " +
                 "inner join recipe as b " +
                 "on a.recipe_id = b.id " +
                 "where a.manufacturing_order_id = '" + MO_ID + "'; ");

            NotifyOfPropertyChange(null);
        }
        public DataTable requestGridSource
        {
            get { return _requestGridSource; }
            set { _requestGridSource = value; }
        }

    }
}
