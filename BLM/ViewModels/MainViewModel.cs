using BLM.ViewModels.Inventory;
using BLM.ViewModels.Production;
using BLM.ViewModels.Scale;
using BLM.ViewModels.Shipments;
using BLM.ViewModels.Tracking;
using Caliburn.Micro;
using System.Windows.Media;

namespace BLM.ViewModels
{
    internal class MainViewModel : Conductor<Screen>
    {
        private Brush _brushDashboard;
        private Brush _brushInventory;
        private Brush _brushLogs;
        private Brush _brushOrders;
        private Brush _brushProduction;
        private Brush _brushScale;
        private Brush _brushShipments;
        private Brush _brushTracking;

        public Brush brushDashboard
        {
            get { return _brushDashboard; }
            set { _brushDashboard = value; }
        }

        public Brush brushInventory
        {
            get { return _brushInventory; }
            set { _brushInventory = value; }
        }

        public Brush brushLogs
        {
            get { return _brushLogs; }
            set { _brushLogs = value; }
        }

        public Brush brushOrders
        {
            get { return _brushOrders; }
            set { _brushOrders = value; }
        }

        public Brush brushProduction
        {
            get { return _brushProduction; }
            set { _brushProduction = value; }
        }

        public Brush brushScale
        {
            get { return _brushScale; }
            set { _brushScale = value; }
        }

        public Brush brushShipments
        {
            get { return _brushShipments; }
            set { _brushShipments = value; }
        }

        public Brush brushTracking
        {
            get { return _brushTracking; }
            set { _brushTracking = value; }
        }

        public void btnDashboard()
        {
            ActivateItem(new DashboardViewModel());

        }

        public void btnInventory()
        {
            ActivateItem(new InventoryViewModel());
        }

        public void btnLogout()
        {
        }

        public void btnLogs()
        {
        }

        public void btnOrders()
        {
        }

        public void btnProduction()
        {
            ActivateItem(new ProductionViewModel());
        }

        public void btnScale()
        {
            ActivateItem(new ScaleViewModel());
        }

        public void btnShipments()
        {
            ActivateItem(new ShipmentsViewModel());
        }

        public void btnTracking()
        {
            ActivateItem(new TrackingMenuViewModel());
        }

        public void clearColors()
        {
            _brushDashboard = null;
            _brushInventory = null;
            _brushLogs = null;
            _brushOrders = null;
            _brushProduction = null;
            _brushScale = null;
            _brushShipments = null;
            _brushTracking = null;
            NotifyOfPropertyChange(null);
        }
    }
}