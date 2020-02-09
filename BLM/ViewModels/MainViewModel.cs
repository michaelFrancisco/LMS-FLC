using BLM.Models;
using BLM.ViewModels.Inventory;
using BLM.ViewModels.Production;
using BLM.ViewModels.Requests;
using BLM.ViewModels.Scale;
using BLM.ViewModels.Shipments;
using BLM.ViewModels.Tracking;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Windows.Threading;

namespace BLM.ViewModels
{
    internal class MainViewModel : Conductor<Screen>
    {
        private Brush _brushDashboard;
        private Brush _brushInventory;
        private Brush _brushLogs;
        private Brush _brushOrders;
        private Brush _brushProduction;
        private Brush _brushRequest;
        private Brush _brushScale;
        private Brush _brushShipments;
        private Brush _brushTracking;
        private List<string> _notificationDateComboBox;
        private DataTable _notificationGridSource;
        private string _notificationsDateComboBoxSelectedItem;
        private object _notificationSelectedItem;
        private string _notificationsText;
        private int _sidebarSelectedIndex;
        private double _sidebarWidth;
        private DispatcherTimer dt = new DispatcherTimer();

        public MainViewModel()
        {
            dt.Tick += new EventHandler(timer_Tick);
            dt.Interval = new System.TimeSpan(0, 0, 5);
            dt.Start();
        }

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

        public Brush brushRequest
        {
            get { return _brushRequest; }
            set { _brushRequest = value; }
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

        public List<string> notificationDateComboBox
        {
            get
            {
                DataTable dt = Connection.dbTable("select date_format(Timestamp, '%c/%d/%Y') from system_log group by date_format(Timestamp, '%c %d %Y');");
                List<string> list = dt.AsEnumerable().Select(r => r.Field<string>("date_format(Timestamp, '%c/%d/%Y')")).ToList();
                return list;
            }
            set { _notificationDateComboBox = value; }
        }

        public DataTable notificationGridSource
        {
            get { return _notificationGridSource; }
            set { _notificationGridSource = value; }
        }

        public string notificationsDateComboBoxSelectedItem
        {
            get { return _notificationsDateComboBoxSelectedItem; }
            set
            {
                _notificationsDateComboBoxSelectedItem = value;
                _notificationGridSource = Connection.dbTable("select Log_ID,Subject from system_log where date_format(Timestamp, '%c/%d/%Y') = '" + notificationsDateComboBoxSelectedItem + "';");
                NotifyOfPropertyChange(() => notificationGridSource);
            }
        }

        public object notificationSelectedItem
        {
            get { return _notificationSelectedItem; }
            set { _notificationSelectedItem = value; }
        }

        public string notificationsText
        {
            get { return _notificationsText; }
            set { _notificationsText = value; }
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
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.ToString();
            path += @"\ChatClientCS\bin\Debug\SignalChat.exe";
            AppDomain ChatDomain = AppDomain.CreateDomain("ChatDomain");
            ChatDomain.ExecuteAssembly(path);
        }

        public void btnNotifications()
        {
            if (_sidebarWidth == 0)
            {
                _sidebarWidth = 370;
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

        public void btnRequests()
        {
            ActivateItem(new RequestsViewModel());
            clearColors();
            _brushRequest = Brushes.DarkTurquoise;
            NotifyOfPropertyChange(null);
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
            _brushProduction = null;
            _brushScale = null;
            _brushShipments = null;
            _brushTracking = null;
            _brushRequest = null;
            NotifyOfPropertyChange(null);
        }

        public void notificationsGridSelectionChanged()
        {
            try
            {
                DataRowView row = (DataRowView)_notificationSelectedItem;
                DataTable dt = Connection.dbTable("select Body from system_log where Log_ID = '" + row[0].ToString() + "'");
                _notificationsText = dt.Rows[0][0].ToString();
                NotifyOfPropertyChange(() => notificationsText);
            }
            catch
            {
            }
        }

        public void refreshNotifications()
        {
            DataTable dt = Connection.dbTable("select date_format(Timestamp, '%c/%d/%Y') from system_log group by date_format(Timestamp, '%c %d %Y');");
            List<string> list = dt.AsEnumerable().Select(r => r.Field<string>("date_format(Timestamp, '%c/%d/%Y')")).ToList();
            _notificationDateComboBox = list;
            NotifyOfPropertyChange(() => notificationDateComboBox);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            refreshNotifications();
        }
    }
}