using BLM.Models;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace BLM.ViewModels.Scale
{
    internal class ScaleViewModel : Screen
    {
        private List<string> _cbItems;
        private string _cbSelectedItem;
        private int _txtEnteredWeight1;
        private int _txtTareWeight1;
        private int _txtNetWeight1;

        private DispatcherTimer dt = new DispatcherTimer();

        private SerialPort port = new SerialPort();

        private decimal _txtTheoreticalYield;

        public decimal txtTheoreticalYield
        {
            get { return _txtTheoreticalYield; }
            set { _txtTheoreticalYield = value; }
        }
        private decimal _txtActualYield;

        public decimal txtActualYield
        {
            get { return _txtActualYield; }
            set { _txtActualYield = value; }
        }

        private decimal _txtPercentYield;

        public decimal txtPercentYield
        {
            get { return _txtPercentYield; }
            set { _txtPercentYield = value; }
        }

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
                    _txtTareWeight1 = (int)dt.Rows[0][0];
                    NotifyOfPropertyChange(() => txtTareWeight1);
                }
                catch
                {
                }
            }
        }

        public int txtEnteredWeight1
        {
            get { return _txtEnteredWeight1; }
            set { _txtEnteredWeight1 = value; }
        }

        public int txtTareWeight1
        {
            get { return _txtTareWeight1; }
            set { _txtTareWeight1 = value; }
        }

        public int txtNetWeight1
        {
            get { return _txtNetWeight1; }
            set { _txtNetWeight1 = value; }
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                Int32.TryParse(port.ReadLine(), out int result);
                if (result > -1)
                {
                    _txtEnteredWeight1 = result;
                    NotifyOfPropertyChange(() => txtEnteredWeight1);
                }
            }
            catch
            { }

            try
            {
                if (_txtTareWeight1 > -1)
                {
                    _txtNetWeight1 = _txtEnteredWeight1 / _txtTareWeight1;
                    NotifyOfPropertyChange(() => txtNetWeight1);
                }
            }
            catch
            {
            }
        }

        protected override void OnActivate()
        {
            try
            {
                port.BaudRate = 9600;
                port.PortName = "COM4";
                port.Open();

                dt.Tick += new EventHandler(timer_Tick);
                dt.Interval = new TimeSpan(0, 0, 0);
                dt.Start();
            }
            catch
            {
               MessageBox.Show("Please Check the connection of your weighing scale");
            }
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