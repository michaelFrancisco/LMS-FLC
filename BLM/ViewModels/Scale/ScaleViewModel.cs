using BLM.Models;
using Caliburn.Micro;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace BLM.ViewModels.Scale
{
    internal class ScaleViewModel : Screen
    {
        private List<string> _cbItems;
        private string _cbSelectedItem;
        private decimal _txtActualYield;
        private int _txtEnteredWeight1;
        private int _txtNetWeight1;
        private decimal _txtPercentYield;
        private int _txtTareWeight1;
        private decimal _txtTheoreticalYield;
        private DispatcherTimer dt = new DispatcherTimer();

        private SerialPort port = new SerialPort();
        private int read;

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

        

        public decimal txtActualYield
        {
            get { return _txtActualYield; }
            set { _txtActualYield = value; }
        }

        public int txtEnteredWeight1
        {
            get { return _txtEnteredWeight1; }
            set { _txtEnteredWeight1 = value; }
        }

        public int txtNetWeight1
        {
            get { return _txtNetWeight1; }
            set { _txtNetWeight1 = value; }
        }

        public decimal txtPercentYield
        {
            get { return _txtPercentYield; }
            set { _txtPercentYield = value; }
        }

        public int txtTareWeight1
        {
            get { return _txtTareWeight1; }
            set { _txtTareWeight1 = value; }
        }

        public decimal txtTheoreticalYield
        {
            get { return _txtTheoreticalYield; }
            set { _txtTheoreticalYield = value; }
        }
        public void btnGetWeight()
        {

            StiReport report = new StiReport();
            report.Load(@"C:\Users\TOYBITS\source\repos\michaelFrancisco\BLM\BLM\Resources\Report.mrt");
            report.Show();
            //Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            //int average = 0;
            //for (int i = 0; i < 100; i++)
            //{
            //    average += read;
            //}
            //average /= 100;
            //_txtEnteredWeight1 = average;
            //NotifyOfPropertyChange(() => txtEnteredWeight1);
            //Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
        }
        public void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                Int32.TryParse(port.ReadLine(), out int result);
                if (result > -1)
                {
                    read = result;
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