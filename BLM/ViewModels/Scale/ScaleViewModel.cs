using BLM.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Windows.Threading;

namespace BLM.ViewModels.Scale
{
    internal class ScaleViewModel : Screen
    {
        private List<string> _cbItems;
        private string _cbSelectedItem;
        private int _txtInputWeight;
        private int _txtItemWeight;
        private int _txtTotal;

        private DispatcherTimer dt = new DispatcherTimer();

        private SerialPort port = new SerialPort();

        public List<string> cbItems
        {
            get
            {
                DataTable dt = Connection.dbTable("select Name from inventory");
                List<string> list = dt.AsEnumerable().Select(r => r.Field<string>("Name")).ToList();
                return list;
            }
            set { _cbItems = value; }
        }

        public string cbSelectedItem
        {
            get { return _cbSelectedItem; }
            set
            {
                _cbSelectedItem = value;
                try
                {
                    DataTable dt = Connection.dbTable("Select Weight from inventory where Name ='" + _cbSelectedItem + "'");
                    _txtItemWeight = (int)dt.Rows[0][0];
                    NotifyOfPropertyChange(() => txtItemWeight);
                }
                catch
                {
                }
            }
        }

        public int txtInputWeight
        {
            get { return _txtInputWeight; }
            set { _txtInputWeight = value; }
        }

        public int txtItemWeight
        {
            get { return _txtItemWeight; }
            set { _txtItemWeight = value; }
        }

        public int txtTotal
        {
            get { return _txtTotal; }
            set { _txtTotal = value; }
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                Int32.TryParse(port.ReadLine(), out int result);
                if (result > -1)
                {
                    _txtInputWeight = result;
                    NotifyOfPropertyChange(() => txtInputWeight);
                }
            }
            catch
            { }

            try
            {
                if (_txtItemWeight > -1)
                {
                    _txtTotal = _txtInputWeight / _txtItemWeight;
                    NotifyOfPropertyChange(() => txtTotal);
                }
            }
            catch
            {
            }
        }

        protected override void OnActivate()
        {
            port.BaudRate = 9600;
            port.PortName = "COM4";
            port.Open();

            dt.Tick += new EventHandler(timer_Tick);
            dt.Interval = new TimeSpan(0, 0, 0);
            dt.Start();
            NotifyOfPropertyChange(null);
            base.OnActivate();
        }

        protected override void OnDeactivate(bool close)
        {
            dt.Stop();
            base.OnDeactivate(close);
        }
    }
}