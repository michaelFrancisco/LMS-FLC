using BLM.Models;
using BLM.ViewModels.Production;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLM.ViewModels.Logging
{
    class SelectReceivingOrderViewModel : Screen
    {
        private DataTable _baseordersGridSource;
        private object _ordersGridSelectedItem;
        private DataTable _ordersGridSource;

        private string _selectedOrderID;

        public DataTable baseordersGridSource
        {
            get { return _ordersGridSource; }
            set { _ordersGridSource = value; }
        }

        public object ordersGridSelectedItem
        {
            get { return _ordersGridSelectedItem; }
            set { _ordersGridSelectedItem = value; }
        }

        public DataTable ordersGridSource
        {
            get { return _ordersGridSource; }
            set { _ordersGridSource = value; }
        }

        public void showReceivingView()
        {
            DataRowView dataRowView = (DataRowView)_ordersGridSelectedItem;
            _selectedOrderID = dataRowView.Row[1].ToString();
            var conductor = this.Parent as IConductor;
            conductor.ActivateItem(new ReceivingViewModel(_selectedOrderID));
        }

        protected override void OnActivate()
        {
            _ordersGridSource = Connection.dbTable("SELECT `company_order`.`Company_Order_ID`, `company_order`.`Batch_ID`,`supplier`.`Supplier_Name`, `company_order`.`Category`, `company_order`.`Receive_By` from company_order inner join supplier on `company_order`.`Supplier_Id` = `supplier`.`Supplier_Id`;");
            _baseordersGridSource = _ordersGridSource;
            NotifyOfPropertyChange(null);
            base.OnActivate();
        }

    }
}
