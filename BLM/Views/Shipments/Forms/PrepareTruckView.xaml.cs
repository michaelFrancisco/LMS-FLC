using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using GoogleApi;
using GoogleApi.Entities.Maps.Directions.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace BLM.Views.Shipments.Forms
{
    /// <summary>
    /// Interaction logic for PrepareTruckView.xaml
    /// </summary>
    public partial class PrepareTruckView : Window
    {
        public static List<PointLatLng> destinations = new List<PointLatLng>();
        private PointLatLng homeLocation = new PointLatLng(14.699749, 121.034064);

        public PrepareTruckView()
        {
            InitializeComponent();

            map.MapProvider = GMapProviders.GoogleMap;
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyDtEr1U4olwEqd57ekWkJ0mNSLQHg95SqQ";
            map.MouseWheelZoomType = MouseWheelZoomType.ViewCenter;
            map.DragButton = System.Windows.Input.MouseButton.Left;
            map.ShowCenter = false;
            map.Position = homeLocation;
        }

        private GoogleApi.Entities.Common.Location[] getDestinations(List<PointLatLng> pointLatLngs)
        {
            int x = 0;
            GoogleApi.Entities.Common.Location[] locations = new GoogleApi.Entities.Common.Location[pointLatLngs.Count];
            foreach (PointLatLng p in pointLatLngs)
            {
                locations[x] = (new GoogleApi.Entities.Common.Location(p.Lat, p.Lng));
                x++;
            }
            return locations;
        }

        private void getRoute(object sender, RoutedEventArgs e)
        {
            try
            {
                map.Markers.Clear();
                GMapProviders.GoogleMap.GetDirections(out GDirections direction, homeLocation, destinations, homeLocation, false, false, false, false, true);
                var request = new DirectionsRequest
                {
                    Key = Properties.Resources.GoogleApiKey,
                    Origin = new GoogleApi.Entities.Common.Location(14.699749, 121.034064),
                    Destination = new GoogleApi.Entities.Common.Location(14.699749, 121.034064),
                    Waypoints = getDestinations(destinations),
                    OptimizeWaypoints = true,
                };
                var result = GoogleMaps.Directions.Query(request);
                var legs = result.Routes.First().Legs.AsEnumerable();
                double time = 0;
                decimal distance = 0;
                foreach (GoogleApi.Entities.Maps.Directions.Response.Leg leg in legs)
                {
                    time += leg.Duration.Value;
                    distance += leg.Distance.Value;
                }
                TimeSpan timeSpan = TimeSpan.FromSeconds(time);
                txtEstimatedTime.Content = timeSpan.Hours + "h" + timeSpan.Minutes + "m";
                txtDistance.Content = decimal.Round((distance / 1000), 2, MidpointRounding.AwayFromZero) + "km";
                GMapRoute gMapRoute = new GMapRoute(direction.Route);
                map.Markers.Add(gMapRoute);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}