using Caliburn.Micro;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Threading;

namespace BLM.ViewModels.Tracking
{
    internal class Data
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    internal class TrackingViewModel : Screen
    {
        //private int _currentTruck;
        //private GMapControl _map;
        //private PointLatLng _mapPosition;
        //private GMapProvider _mapProvider;
        //private string _txtLocation1;
        //private string _txtLocation2;
        //private string _txtLocation3;
        //private IFirebaseClient client;
        //GMapOverlay markers = new GMapOverlay("markers");


        //private IFirebaseConfig config = new FirebaseConfig
        //{
        //    AuthSecret = "0UZRAqH7hUK7nvXBGMzrCvOVUDG1n1hA9zTQqlAq",
        //    BasePath = "https://blm-transportation-tracker.firebaseio.com/"
        //};

        //public GMapControl map
        //{
        //    get { return _map; }
        //    set { _map = value; }
        //}

        //public PointLatLng mapPosition
        //{
        //    get { return _mapPosition; }
        //    set { _mapPosition = value; }
        //}

        //public GMapProvider mapProvider
        //{
        //    get { return GMapProviders.GoogleMap; }
        //    set { _mapProvider = value; }
        //}

        //public string txtLocation1
        //{
        //    get { return _txtLocation1; }
        //    set { _txtLocation1 = value; }
        //}

        //public string txtLocation2
        //{
        //    get { return _txtLocation2; }
        //    set { _txtLocation2 = value; }
        //}

        //public string txtLocation3
        //{
        //    get { return _txtLocation3; }
        //    set { _txtLocation3 = value; }
        //}

        //public void btnTruck1()
        //{
        //    _currentTruck = 1;
        //    _mapPosition = getLocation(_currentTruck);
        //    NotifyOfPropertyChange(() => mapPosition);
        //}

        //public void btnTruck2()
        //{
        //    _currentTruck = 2;
        //    _mapPosition = getLocation(_currentTruck);
        //    NotifyOfPropertyChange(() => mapPosition);
        //}

        //public void btnTruck3()
        //{
        //    _currentTruck = 3;
        //    _mapPosition = getLocation(_currentTruck);
        //    NotifyOfPropertyChange(() => mapPosition);
        //}

        //public PointLatLng getLocation(int truck)
        //{
        //    client = new FireSharp.FirebaseClient(config);
        //    FirebaseResponse response = null;
        //    if (truck == 1)
        //    {
        //        response = client.Get("locations/420");
        //    }
        //    else if (truck == 2)
        //    {
        //        response = client.Get("locations/ednis");
        //    }
        //    else if (truck == 3)
        //    {
        //        response = client.Get("locations/goods");
        //    }
        //    Data obj = response.ResultAs<Data>();
        //    return new PointLatLng(obj.latitude, obj.longitude);
        //}

        //protected override void OnActivate()
        //{
        //    _currentTruck = 1;
        //    DispatcherTimer dt = new DispatcherTimer();
        //    dt.Tick += new EventHandler(timer_Tick);
        //    dt.Interval = new TimeSpan(0, 0, 5);
        //    dt.Start();
        //    GMapProviders.GoogleMap.ApiKey = @"AIzaSyB8B3hq7jeZtvEPtFdEoZ3Jd5IaZh2Hp3g";
        //    _map.MinZoom = 15;
        //    GMapProviders.GoogleMap.MaxZoom = 20;
        //    base.OnActivate();
        //}

        //private void updateMarkers()
        //{
        //    markers.Markers.Clear();
        //    GMapMarker a = new GMarkerGoogle(getLocation(1), new Bitmap("/BLM;component/Resources/Icons/Bounty_Hunter_minimap_icon.png"));
        //    GMapMarker b = new GMarkerGoogle(getLocation(2), new Bitmap("/BLM;component/Resources/Icons/Lich_minimap_icon.png"));
        //    GMapMarker c = new GMarkerGoogle(getLocation(3), new Bitmap("/BLM;component/Resources/Icons/Lone_Druid_minimap_icon.png"));
        //    markers.Markers.Add(a);
        //    markers.Markers.Add(b);
        //    markers.Markers.Add(c);
        //    _map.Overlays.Add(markers);
        //    NotifyOfPropertyChange(() => map);
        //}

        //private void changeLocationtxt()
        //{
        //    List<Placemark> plc = null;
        //    var st = GMapProviders.GoogleMap.GetPlacemarks(getLocation(1), out plc);
        //    if (st == GeoCoderStatusCode.OK && plc != null)
        //    {
        //        foreach (var pl in plc)
        //        {
        //            if (!string.IsNullOrEmpty(pl.PostalCodeNumber))
        //            {
        //                _txtLocation1 = "Location: " + pl.Address;
        //                NotifyOfPropertyChange(() => txtLocation1);
        //            }
        //        }
        //    }
        //    st = GMapProviders.GoogleMap.GetPlacemarks(getLocation(2), out plc);
        //    if (st == GeoCoderStatusCode.OK && plc != null)
        //    {
        //        foreach (var pl in plc)
        //        {
        //            if (!string.IsNullOrEmpty(pl.PostalCodeNumber))
        //            {
        //                _txtLocation2 = "Location: " + pl.Address;
        //                NotifyOfPropertyChange(() => txtLocation2);
        //            }
        //        }
        //    }
        //    st = GMapProviders.GoogleMap.GetPlacemarks(getLocation(3), out plc);
        //    if (st == GeoCoderStatusCode.OK && plc != null)
        //    {
        //        foreach (var pl in plc)
        //        {
        //            if (!string.IsNullOrEmpty(pl.PostalCodeNumber))
        //            {
        //                _txtLocation3 = "Location: " + pl.Address;
        //                NotifyOfPropertyChange(() => txtLocation3);
        //            }
        //        }
        //    }
        //}

        //private void timer_Tick(object sender, EventArgs e)
        //{
        //    _mapPosition = getLocation(_currentTruck);
        //    changeLocationtxt();
        //    NotifyOfPropertyChange(() => mapPosition);
        //}
    }
}