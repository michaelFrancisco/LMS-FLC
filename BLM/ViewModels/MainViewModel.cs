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
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace BLM.ViewModels
{
    internal class MainViewModel : Conductor<Screen>
    {
        private readonly IWindowManager windowManager = new WindowManager();
        private Brush _brushDashboard;
        private Brush _brushInventory;
        private Brush _brushLogs;
        private Brush _brushOrders;
        private Brush _brushProduction;
        private Brush _brushRequest;
        private Brush _brushScale;
        private Brush _brushShipments;
        private Brush _brushTracking;
        private Visibility _dashboardVisibility;
        private Visibility _inventoryVisibility;
        private Visibility _logsVisibility;
        private List<string> _notificationDateComboBox;
        private DataTable _notificationGridSource;
        private string _notificationsDateComboBoxSelectedItem;
        private object _notificationSelectedItem;
        private string _notificationsText;
        private Visibility _notifVisibility;
        private Visibility _productionVisibility;
        private Visibility _requestsVisibility;
        private Visibility _scaleVisibility;
        private Visibility _shipmentsVisibility;
        private int _sidebarSelectedIndex;
        private double _sidebarWidth;
        private Visibility _trackingVisibility;
        private string _txtNotifCount;
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

        public Visibility dashboardVisibility
        {
            get { return _dashboardVisibility; }
            set { _dashboardVisibility = value; }
        }

        public Visibility inventoryVisibility
        {
            get { return _inventoryVisibility; }
            set { _inventoryVisibility = value; }
        }

        public Visibility logsVisibility
        {
            get { return _logsVisibility; }
            set { _logsVisibility = value; }
        }

        public List<string> notificationDateComboBox
        {
            get
            {
                DataTable dt = Connection.dbTable("select date_format(Timestamp, '%c/%d/%Y') from system_log group by date_format(Timestamp, '%c %d %Y');");
                List<string> list = dt.AsEnumerable().Select(r => r.Field<string>("date_format(Timestamp, '%c/%d/%Y')")).ToList();
                list.Insert(0, "Unread Notifications");
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
                if (_notificationsDateComboBoxSelectedItem == "Unread Notifications")
                {
                    _notificationGridSource = Connection.dbTable("select * from system_log where Log_ID not in (select System_Log_ID from system_log_read where User_ID = " + CurrentUser.User_ID + ");");
                    NotifyOfPropertyChange(() => notificationGridSource);

                }
                else
                {
                    _notificationGridSource = Connection.dbTable("select Log_ID,Subject from system_log where date_format(Timestamp, '%c/%d/%Y') = '" + notificationsDateComboBoxSelectedItem + "';");
                    NotifyOfPropertyChange(() => notificationGridSource);
                }
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

        public Visibility notifVisibility
        {
            get { return _notifVisibility; }
            set { _notifVisibility = value; }
        }

        public Visibility productionVisibility
        {
            get { return _productionVisibility; }
            set { _productionVisibility = value; }
        }

        public Visibility requestsVisibility
        {
            get { return _requestsVisibility; }
            set { _requestsVisibility = value; }
        }

        public Visibility scaleVisibility
        {
            get { return _scaleVisibility; }
            set { _scaleVisibility = value; }
        }

        public Visibility shipmentsVisibility
        {
            get { return _shipmentsVisibility; }
            set { _shipmentsVisibility = value; }
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

        public Visibility trackingVisibility
        {
            get { return _trackingVisibility; }
            set { _trackingVisibility = value; }
        }

        public string txtNotifCount
        {
            get { return _txtNotifCount; }
            set { _txtNotifCount = value; }
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
            windowManager.ShowWindow(new LoginViewModel(), null, null);
            TryClose();
        }

        public void btnLogs()
        {
        }

        public void btnMessages()
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName.ToString();
            path += @"\BLM\ChatClientCS\bin\Debug\SignalChat.exe";
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

        public void initializeSidebar()
        {
            switch (CurrentUser.user_level)
            {
                case "Dispensing Officer":
                    _dashboardVisibility = Visibility.Collapsed;
                    _inventoryVisibility = Visibility.Visible;
                    _requestsVisibility = Visibility.Collapsed;
                    _productionVisibility = Visibility.Collapsed;
                    _trackingVisibility = Visibility.Collapsed;
                    _shipmentsVisibility = Visibility.Collapsed;
                    _logsVisibility = Visibility.Collapsed;
                    _scaleVisibility = Visibility.Visible;
                    ActivateItem(new InventoryViewModel());
                    break;

                case "Dispatching Officer":
                    _dashboardVisibility = Visibility.Collapsed;
                    _inventoryVisibility = Visibility.Collapsed;
                    _requestsVisibility = Visibility.Visible;
                    _productionVisibility = Visibility.Collapsed;
                    _trackingVisibility = Visibility.Visible;
                    _shipmentsVisibility = Visibility.Visible;
                    _logsVisibility = Visibility.Collapsed;
                    _scaleVisibility = Visibility.Visible;
                    ActivateItem(new ShipmentsViewModel());
                    break;

                case "Production Officer":
                    _dashboardVisibility = Visibility.Collapsed;
                    _inventoryVisibility = Visibility.Collapsed;
                    _requestsVisibility = Visibility.Collapsed;
                    _productionVisibility = Visibility.Visible;
                    _trackingVisibility = Visibility.Collapsed;
                    _shipmentsVisibility = Visibility.Collapsed;
                    _logsVisibility = Visibility.Collapsed;
                    _scaleVisibility = Visibility.Visible;
                    ActivateItem(new ProductionViewModel());
                    break;

                case "IT Admin":
                    _dashboardVisibility = Visibility.Visible;
                    _inventoryVisibility = Visibility.Visible;
                    _requestsVisibility = Visibility.Visible;
                    _productionVisibility = Visibility.Visible;
                    _trackingVisibility = Visibility.Visible;
                    _shipmentsVisibility = Visibility.Visible;
                    _logsVisibility = Visibility.Visible;
                    _scaleVisibility = Visibility.Visible;
                    break;
            }
        }

        public void notificationsGridSelectionChanged()
        {
            try
            {
                DataRowView row = (DataRowView)_notificationSelectedItem;
                DataTable dt = Connection.dbTable("select Body from system_log where Log_ID = '" + row[0].ToString() + "'");
                _notificationsText = dt.Rows[0][0].ToString();
                NotifyOfPropertyChange(() => notificationsText);
                dt = Connection.dbTable("SELECT * FROM flc.system_log_read where System_Log_ID = " + row[0].ToString() + " AND User_ID = " + CurrentUser.User_ID + ";");
                if (dt.Rows.Count == 0)
                {
                    Connection.dbCommand("INSERT INTO `flc`.`system_log_read` (`System_Log_ID`, `User_ID`) VALUES ('" + row[0].ToString() + "', '" + CurrentUser.User_ID + "');");
                }
                refreshNotifications();
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
            dt = Connection.dbTable("select * from system_log where Log_ID not in (select System_Log_ID from system_log_read where User_ID = " + CurrentUser.User_ID+ ");");
            if (dt.Rows.Count != 0)
            {
                _txtNotifCount = dt.Rows.Count.ToString();
                _notifVisibility = Visibility.Visible;
                NotifyOfPropertyChange(() => txtNotifCount);
                NotifyOfPropertyChange(() => notifVisibility);
            }
            else
            {
                _notifVisibility = Visibility.Hidden;
                NotifyOfPropertyChange(() => notifVisibility);
            }
        }

        protected override void OnActivate()
        {
            dt.Tick += new EventHandler(timer_Tick);
            dt.Interval = new TimeSpan(0, 0, 25);
            dt.Start();
            refreshNotifications();
            initializeSidebar();
            base.OnActivate();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            refreshNotifications();
        }
    }
}