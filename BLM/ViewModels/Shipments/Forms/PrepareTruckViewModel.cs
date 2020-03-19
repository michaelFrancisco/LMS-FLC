using BLM.Models;
using BLM.Views.Shipments.Forms;
using Caliburn.Micro;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLM.ViewModels.Shipments.Forms
{
    internal class PrepareTruckViewModel : Screen
    {
        private DataTable _destinationGridSource;
        private object _destinationGridSelectedItem;
        private DataTable _shipmentGridSource;
        private object _shipmentGridSelectedItem;
        private List<string> _txtCategory;
        private string _txtCategorySelectedItem;
        private string _txtDistance;
        private List<string> _txtDriver;
        private string _txtDriverSelectedItem;
        private string _txtEstimatedTime;
        private string _txtShipmentDetails;
        private List<string> _txtTruck;
        private string _txtTruckSelectedItem;

        private string _txtWeight;

        public DataTable destinationGridSource
        {
            get { return _destinationGridSource; }
            set { _destinationGridSource = value; }
        }

        public object destinationGridSelectedItem
        {
            get { return _destinationGridSelectedItem; }
            set { _destinationGridSelectedItem = value; }
        }

        public DataTable shipmentGridSource
        {
            get { return _shipmentGridSource; }
            set { _shipmentGridSource = value; }
        }

        public object shipmentGridSelectedItem
        {
            get { return _shipmentGridSelectedItem; }
            set { _shipmentGridSelectedItem = value; }
        }

        public List<string> txtCategory
        {
            get { return new List<string> { "Inbound", "Outbound" }; }
            set { _txtCategory = value; }
        }

        public string txtCategorySelectedItem
        {
            get { return _txtCategorySelectedItem; }
            set
            {
                _txtCategorySelectedItem = value;
                if (_txtCategorySelectedItem == "Inbound")
                {
                    _shipmentGridSource = Connection.dbTable("Select * from shipments where Category = 'Inbound' AND Status = 'Ready'");
                    NotifyOfPropertyChange(() => shipmentGridSource);
                }
                else if (_txtCategorySelectedItem == "Outbound")
                {
                    _shipmentGridSource = Connection.dbTable("Select * from shipments where Category = 'Outbound' AND Status = 'Ready'");
                    NotifyOfPropertyChange(() => shipmentGridSource);
                }
                _destinationGridSource = Connection.dbTable("Select * from shipments where null");
                NotifyOfPropertyChange(() => destinationGridSource);
            }
        }

        public string txtDistance
        {
            get { return _txtDistance; }
            set { _txtDistance = value; }
        }

        public List<string> txtDriver
        {
            get
            {
                DataTable dt = Connection.dbTable("select Distinct Name from users where User_Level = 'Delivery Agent'");
                List<string> list = dt.AsEnumerable().Select(r => r.Field<string>("Name")).ToList();
                return list;
            }
            set { _txtDriver = value; }
        }

        public string txtDriverSelectedItem
        {
            get { return _txtDriverSelectedItem; }
            set { _txtDriverSelectedItem = value; }
        }

        public string txtEstimatedTime
        {
            get { return _txtEstimatedTime; }
            set { _txtEstimatedTime = value; }
        }

        public string txtShipmentDetails
        {
            get { return _txtShipmentDetails; }
            set { _txtShipmentDetails = value; }
        }

        public List<string> txtTruck
        {
            get
            {
                DataTable dt = Connection.dbTable("select Distinct Name from trucks");
                List<string> list = dt.AsEnumerable().Select(r => r.Field<string>("Name")).ToList();
                return list;
            }
            set { _txtTruck = value; }
        }

        public string txtTruckSelectedItem
        {
            get { return _txtTruckSelectedItem; }
            set { _txtTruckSelectedItem = value; }
        }

        public string txtWeight
        {
            get { return _txtWeight; }
            set { _txtWeight = value; }
        }

        public void btnAddShipment()
        {
            DataRowView row = (DataRowView)_shipmentGridSelectedItem;
            _destinationGridSource.ImportRow(row.Row);
            double lat = double.Parse(Connection.dbTable("select Latitude from client where Name = '" + row["Destination"].ToString() + "'").Rows[0]["Latitude"].ToString());
            double lng = double.Parse(Connection.dbTable("select Longitude from client where Name = '" + row["Destination"].ToString() + "'").Rows[0]["Longitude"].ToString());
            PrepareTruckView.destinations.Add(new PointLatLng(lat, lng));
            NotifyOfPropertyChange(() => destinationGridSource);
        }

        public void btnDispatchTruck()
        {
        }

        public void shipmentGridSelectionChanged()
        {
            DataRowView row = (DataRowView)_shipmentGridSelectedItem;
            string address = Connection.dbTable("Select Address from client where Name = '" + row["Destination"] + "'").Rows[0]["Address"].ToString();
            _txtShipmentDetails = "Destination: " + row["Destination"].ToString() + Environment.NewLine;
            _txtShipmentDetails += "Address: " + address + Environment.NewLine;
            _txtShipmentDetails += "Due Date: " + row["Date_Due"].ToString() + Environment.NewLine;
            _txtShipmentDetails += "Total Weight: " + row["Weight"].ToString() + Environment.NewLine;
            _txtShipmentDetails += "Items: " + Environment.NewLine;
            DataTable shipmentItems = Connection.dbTable("SELECT inventory.Name, shipment_items.Quantity FROM flc.shipment_items inner join inventory on shipment_items.Item_ID = inventory.ID where Shipment_ID = '" + row["ID"].ToString() + "'");
            foreach (DataRow item in shipmentItems.Rows)
            {
                _txtShipmentDetails += item["Name"].ToString() + "(x" + item["Quantity"].ToString() + ")" + Environment.NewLine;
            }
            NotifyOfPropertyChange(null);
        }
    }
}