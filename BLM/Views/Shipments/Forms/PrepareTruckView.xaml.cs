using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System.Collections.Generic;
using System.Windows;

namespace BLM.Views.Shipments.Forms
{
    /// <summary>
    /// Interaction logic for PrepareTruckView.xaml
    /// </summary>
    public partial class PrepareTruckView : Window
    {
        public static List<PointLatLng> destinations = new List<PointLatLng>();

        public PrepareTruckView()
        {
            InitializeComponent();

            map.MapProvider = GMapProviders.GoogleMap;
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyDtEr1U4olwEqd57ekWkJ0mNSLQHg95SqQ";
            map.MouseWheelZoomType = MouseWheelZoomType.ViewCenter;
            map.DragButton = System.Windows.Input.MouseButton.Left;
            map.ShowCenter = false;
            map.Position = new PointLatLng(14.699749, 121.034064);
            destinations.Add(new PointLatLng(14.699749, 121.034064));
        }

        private void getRoute(object sender, RoutedEventArgs e)
        {
            try
            {
                map.Markers.Clear();
                MapRoute r = GoogleMapProvider.Instance.GetRoute(destinations[0], destinations[1], false, false,14);                
                GMapRoute routes = new GMapRoute(r.Points);
                map.Markers.Add(routes);
            }
            catch
            {
            }
        }
    }
}