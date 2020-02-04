using BLM.Models;
using BLM.ViewModels.Inventory;
using BLM.ViewModels.Production;
using BLM.ViewModels.Scale;
using BLM.ViewModels.Shipments;
using BLM.ViewModels.Tracking;
using Caliburn.Micro;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        private int _sidebarSelectedIndex;

        private double _sidebarWidth;

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

        public int sidebarSelectedIndex
        {
            get { return _sidebarSelectedIndex; }
            set { _sidebarSelectedIndex = value; }
        }

        public double sidebarWidth
        {
            get { return _sidebarWidth; }
            set { _sidebarWidth = value; }
        }

        public void btnDashboard()
        {
            ActivateItem(new DashboardViewModel());
            clearColors();
            _brushDashboard = Brushes.DarkTurquoise;
            NotifyOfPropertyChange(null);
        }

        public void btnInventory()
        {
            ActivateItem(new InventoryViewModel());
            clearColors();
            _brushInventory = Brushes.DarkTurquoise;
            NotifyOfPropertyChange(null);
        }

        public void btnLogout()
        {
        }

        public void btnLogs()
        {
        }

        public void btnMessages()
        {
            if (_sidebarWidth == 0)
            {
                _sidebarWidth = 350;
                NotifyOfPropertyChange(() => sidebarWidth);
            }
            else
            {
                _sidebarWidth = 0;
                NotifyOfPropertyChange(() => sidebarWidth);
            }
            _sidebarSelectedIndex = 1;
            NotifyOfPropertyChange(() => sidebarSelectedIndex);
        }

        private List<string> _notificationDateComboBox;

        public List<string> notificationDateComboBox
        {
            get 
            {
                DataTable dt = Connection.dbTable("select date_format(Timestamp, '%c/%d/%Y') from system_log group by date_format(Timestamp, '%c %d %Y');");
                List<string> list = dt.AsEnumerable().Select(r => r.Field<string>("Timestamp")).ToList();
                return list;
            }
            set { _notificationDateComboBox = value; }
        }

        public void btnNotifications()
        {
            if (_sidebarWidth == 0)
            {
                _sidebarWidth = 350;
                NotifyOfPropertyChange(() => sidebarWidth);
            }
            else
            {
                _sidebarWidth = 0;
                NotifyOfPropertyChange(() => sidebarWidth);
            }
            _sidebarSelectedIndex = 0;
            NotifyOfPropertyChange(() => sidebarSelectedIndex);
        }

        public void btnProduction()
        {
            ActivateItem(new ProductionViewModel());
            clearColors();
            _brushProduction = Brushes.DarkTurquoise;
            NotifyOfPropertyChange(null);
        }

        public void btnProfile()
        {
            if (_sidebarWidth == 0)
            {
                _sidebarWidth = 350;
                NotifyOfPropertyChange(() => sidebarWidth);
            }
            else
            {
                _sidebarWidth = 0;
                NotifyOfPropertyChange(() => sidebarWidth);
            }
            _sidebarSelectedIndex = 2;
            NotifyOfPropertyChange(() => sidebarSelectedIndex);
        }

        public void btnScale()
        {
            ActivateItem(new ScaleViewModel());
            clearColors();
            _brushScale = Brushes.DarkTurquoise;
            NotifyOfPropertyChange(null);
        }

        public void btnShipments()
        {
            ActivateItem(new ShipmentsViewModel());
            clearColors();
            _brushShipments = Brushes.DarkTurquoise;
            NotifyOfPropertyChange(null);
        }

        public void btnTracking()
        {
            ActivateItem(new TrackingMenuViewModel());
            clearColors();
            _brushTracking = Brushes.DarkTurquoise;
            NotifyOfPropertyChange(null);
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

        protected override void OnActivate()
        {
            base.OnActivate();
        }
    }
}