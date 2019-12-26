using BLM.Models;
using Caliburn.Micro;
using System.Data;

namespace BLM.ViewModels.Logging
{
    internal class ReceivingViewModel : Screen
    {
        private DataTable _baseordersGridSource;
        private string _orderID;
        private object _ordersGridSelectedItem;
        private DataTable _ordersGridSource;

        public ReceivingViewModel(string orderID)
        {
            _orderID = orderID;
        }

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

        protected override void OnActivate()
        {
            _ordersGridSource = Connection.dbTable("SELECT * from client_order_items where Batch_ID = " + _orderID + "");
            _baseordersGridSource = _ordersGridSource;
            NotifyOfPropertyChange(null);
            base.OnActivate();
        }

        private void cancelButton()
        {
            var conductor = this.Parent as IConductor;
            conductor.ActivateItem(new SelectReceivingOrderViewModel());
        }

        private void saveButton()
        {
            var conductor = this.Parent as IConductor;
            conductor.ActivateItem(new SelectReceivingOrderViewModel());
        }
    }
}