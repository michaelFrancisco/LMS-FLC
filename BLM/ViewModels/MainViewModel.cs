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
        private Visibility _dashboardVisibility;
        private Visibility _inventoryVisibility;
        private Visibility _logsVisibility;
        private List<string> _notificationDateComboBox;
        private DataTable _notificationGridSource;
        private string _notificationsDateComboBoxSelectedItem;
        private object _notificationSelectedItem;
        private string _notificationsText;
        private Visibility _notificationsVisibility;
        private Visibility _productionVisibility;
        private Visibility _requestsVisibility;
        private Visibility _scaleVisibility;
        private Visibility _shipmentsVisibility;
        private int _sidebarSelectedIndex;
        private Visibility _trackingVisibility;
        private string _txtNotifCount;
        private DispatcherTimer dt = new DispatcherTimer();

        public MainViewModel()
        {
            dt.Tick += new EventHandler(timer_Tick);
            dt.Interval = new System.TimeSpan(0, 0, 5);
            dt.Start();
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
                DataTable dt = Connection.dbTable("select date_format(Timestamp, '%c/%d/%Y') from system_log group by date_format(Timestamp, '%c %d %Y') ORDER BY date_format(Timestamp, '%c/%d/%Y') DESC;");
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
                    _notificationGridSource = Connection.dbTable("select ID,Subject from system_log where ID not in (select System_Log_ID from system_log_read where User_ID = " + CurrentUser.User_ID + ");");
                    foreach (DataRow row in _notificationGridSource.Rows)
                    {
                        DataTable dt = Connection.dbTable("select Body from system_log where ID = '" + row[0].ToString() + "'");
                        _notificationsText = dt.Rows[0][0].ToString();
                        NotifyOfPropertyChange(() => notificationsText);
                        dt = Connection.dbTable("SELECT * FROM flc.system_log_read where System_Log_ID = " + row[0].ToString() + " AND User_ID = " + CurrentUser.User_ID + ";");
                        if (dt.Rows.Count == 0)
                        {
                            Connection.dbCommand("INSERT INTO `flc`.`system_log_read` (`System_Log_ID`, `User_ID`) VALUES ('" + row[0].ToString() + "', '" + CurrentUser.User_ID + "');");
                        }
                    }
                    NotifyOfPropertyChange(() => notificationGridSource);
                }
                else
                {
                    _notificationGridSource = Connection.dbTable("select ID,Subject from system_log where date_format(Timestamp, '%c/%d/%Y') = '" + notificationsDateComboBoxSelectedItem + "';");
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
            get { return _notificationsVisibility; }
            set { _notificationsVisibility = value; }
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
            NotifyOfPropertyChange(null);
        }

        public void btnInventory()
        {
            ActivateItem(new InventoryViewModel());
            NotifyOfPropertyChange(null);
        }

        public void btnLogout()
        {
            MessageBoxResult dialogResult = System.Windows.MessageBox.Show("Logout?.", "!", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                windowManager.ShowWindow(new LoginViewModel(), null, null);
                TryClose();
            }
        }

        public void btnLogs()
        {
        }

        public void btnMessages()
        {
            _sidebarSelectedIndex = 1;
            NotifyOfPropertyChange(() => sidebarSelectedIndex);
        }

        public void btnNotifications()
        {
            _notificationsDateComboBoxSelectedItem = string.Empty;
            _sidebarSelectedIndex = 0;
            refreshNotifications();
            NotifyOfPropertyChange(() => notificationsDateComboBoxSelectedItem);
            NotifyOfPropertyChange(() => sidebarSelectedIndex);
        }

        public void btnProduction()
        {
            ActivateItem(new ProductionViewModel());
            NotifyOfPropertyChange(null);
        }

        public void btnProfile()
        {
            _sidebarSelectedIndex = 2;
            NotifyOfPropertyChange(() => sidebarSelectedIndex);
        }

        public void btnRequests()
        {
            ActivateItem(new RequestsViewModel());
            NotifyOfPropertyChange(null);
        }

        public void btnScale()
        {
            ActivateItem(new ScaleViewModel());
            NotifyOfPropertyChange(null);
        }

        public void btnShipments()
        {
            ActivateItem(new ShipmentsViewModel());
            NotifyOfPropertyChange(null);
        }

        public void btnTracking()
        {
            ActivateItem(new TrackingMenuViewModel());
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
                DataTable dt = Connection.dbTable("select Body from system_log where ID = '" + row[0].ToString() + "'");
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
            dt = Connection.dbTable("select * from system_log where ID not in (select System_Log_ID from system_log_read where User_ID = " + CurrentUser.User_ID + ");");
            if (dt.Rows.Count != 0)
            {
                _txtNotifCount = dt.Rows.Count.ToString();
                _notificationsVisibility = Visibility.Visible;
                NotifyOfPropertyChange(() => txtNotifCount);
                NotifyOfPropertyChange(() => notifVisibility);
            }
            else
            {
                _notificationsVisibility = Visibility.Hidden;
                NotifyOfPropertyChange(() => notifVisibility);
            }
        }

        protected override void OnActivate()
        {
            dt.Tick += new EventHandler(timer_Tick);
            dt.Interval = new TimeSpan(0, 0, 5);
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