using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BLM.Views.Tracking
{
    public partial class TrackingView : UserControl
    {
        private static ImageBrush brushA = new ImageBrush();
        private static ImageBrush brushB = new ImageBrush();
        private static ImageBrush brushC = new ImageBrush();
        private int _currentTruck;
        private IFirebaseClient client;
        DispatcherTimer dt = new DispatcherTimer();


        private IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "0UZRAqH7hUK7nvXBGMzrCvOVUDG1n1hA9zTQqlAq",
            BasePath = "https://blm-transportation-tracker.firebaseio.com/"
        };

        private Rectangle mapMarkerIconA = new Rectangle
        {
            Width = 32,
            Height = 32,
            Fill = brushA,
        };

        private Rectangle mapMarkerIconB = new Rectangle
        {
            Width = 32,
            Height = 32,
            Fill = brushB,
        };

        private Rectangle mapMarkerIconC = new Rectangle
        {
            Width = 32,
            Height = 32,
            Fill = brushC,
        };

        

        public TrackingView()
        {
            InitializeComponent();

            _currentTruck = 1;
            brushA.ImageSource = new BitmapImage(new Uri(@"C:\Users\Michael C. Francisco\source\repos\michaelFrancisco\BLM\BLM\Resources\Icons\icons8-truck-96.png"));
            brushB.ImageSource = new BitmapImage(new Uri(@"C:\Users\Michael C. Francisco\source\repos\michaelFrancisco\BLM\BLM\Resources\Icons\icons8-truck-96(1).png"));
            brushC.ImageSource = new BitmapImage(new Uri(@"C:\Users\Michael C. Francisco\source\repos\michaelFrancisco\BLM\BLM\Resources\Icons\icons8-truck-96(2).png"));

            dt.Tick += new EventHandler(timer_Tick);
            dt.Interval = new TimeSpan(0, 0, 1);
            dt.Start();

            map.MapProvider = GMapProviders.GoogleMap;
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyB8B3hq7jeZtvEPtFdEoZ3Jd5IaZh2Hp3g";
            map.MouseWheelZoomType = MouseWheelZoomType.ViewCenter;
            map.MinZoom = 10;
            map.MaxZoom = 18;
        }

        public PointLatLng getLocation(int truck)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = null;
            if (truck == 1)
            {
                response = client.Get("locations/420");
            }
            else if (truck == 2)
            {
                response = client.Get("locations/ednis");
            }
            else if (truck == 3)
            {
                response = client.Get("locations/goods");
            }
            Data obj = response.ResultAs<Data>();
            return new PointLatLng(obj.latitude, obj.longitude);
        }

        private void changeLocationtxt()
        {
            List<Placemark> plc = null;
            var st = GMapProviders.GoogleMap.GetPlacemarks(getLocation(1), out plc);
            if (st == GeoCoderStatusCode.OK && plc != null)
            {
                foreach (var pl in plc)
                {
                    if (!string.IsNullOrEmpty(pl.PostalCodeNumber))
                    {
                        txtLocation1.Text = "Location: " + pl.Address;
                    }
                }
            }
            st = GMapProviders.GoogleMap.GetPlacemarks(getLocation(2), out plc);
            if (st == GeoCoderStatusCode.OK && plc != null)
            {
                foreach (var pl in plc)
                {
                    if (!string.IsNullOrEmpty(pl.PostalCodeNumber))
                    {
                        txtLocation2.Text = "Location: " + pl.Address;
                    }
                }
            }
            st = GMapProviders.GoogleMap.GetPlacemarks(getLocation(3), out plc);
            if (st == GeoCoderStatusCode.OK && plc != null)
            {
                foreach (var pl in plc)
                {
                    if (!string.IsNullOrEmpty(pl.PostalCodeNumber))
                    {
                        txtLocation3.Text = "Location: " + pl.Address;
                    }
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            map.Position = getLocation(_currentTruck);
            updateMarkers();
            changeLocationtxt();
        }

        private void updateMarkers()
        {
            map.Markers.Clear();
            GMapMarker a = new GMapMarker(getLocation(1));
            GMapMarker b = new GMapMarker(getLocation(2));
            GMapMarker c = new GMapMarker(getLocation(3));
            a.Shape = mapMarkerIconA;
            b.Shape = mapMarkerIconB;
            c.Shape = mapMarkerIconC;
            map.Markers.Add(a);
            map.Markers.Add(b);
            map.Markers.Add(c);
        }

        internal class Data
        {
            public double latitude { get; set; }
            public double longitude { get; set; }
        }

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            dt.Stop();
        }
    }
}