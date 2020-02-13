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
        private IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "0UZRAqH7hUK7nvXBGMzrCvOVUDG1n1hA9zTQqlAq",
            BasePath = "https://blm-transportation-tracker.firebaseio.com/"
        };

        private DispatcherTimer dt = new DispatcherTimer();
        private Ellipse mapMarkerIconA = new Ellipse
        {
            Width = 12,
            Height = 12,
            Fill = Brushes.Red,
        };

        private Ellipse mapMarkerIconB = new Ellipse
        {
            Width = 12,
            Height = 12,
            Fill = Brushes.Green,
        };

        private Ellipse mapMarkerIconC = new Ellipse
        {
            Width = 12,
            Height = 12,
            Fill = Brushes.Blue,
        };

        public TrackingView()
        {
            InitializeComponent();

            _currentTruck = 1;

            dt.Tick += new EventHandler(timer_Tick);
            dt.Interval = new TimeSpan(0, 0, 10);
            dt.Start();

            map.MapProvider = GMapProviders.GoogleMap;
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyClpd29eOFZU_cb0joEX0yji2Ei9OzUq7o";
            map.MouseWheelZoomType = MouseWheelZoomType.ViewCenter;
            map.DragButton = System.Windows.Input.MouseButton.Left;
            map.ShowCenter = false;
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

        private void btnTruck1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _currentTruck = 1;
        }

        private void btnTruck2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _currentTruck = 2;
        }

        private void btnTruck3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _currentTruck = 3;
        }

        private void changeLocationText()
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
                    else
                    {
                        txtLocation2.Text = "Location: Unknown";
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
                    else
                    {
                        txtLocation2.Text = "Location: Unknown";
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
                    else
                    {
                        txtLocation2.Text = "Location: Unknown";
                    }
                }
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            map.Position = getLocation(_currentTruck);
            updateMarkers();
            //changeLocationText();
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

        private void UserControl_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            dt.Stop();
        }

        internal class Data
        {
            public double latitude { get; set; }
            public double longitude { get; set; }
        }
    }
}