using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace BLM.Views.Shipments.Forms
{
    /// <summary>
    /// Interaction logic for LocationSelectorView.xaml
    /// </summary>
    public partial class LocationSelectorView : Window
    {
        public LocationSelectorView()
        {
            InitializeComponent();
            map.MapProvider = GMapProviders.GoogleMap;
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyBZPVDnNwV-u7jRFFUJb83p31k3Pjx8hBM";
            map.MouseWheelZoomType = MouseWheelZoomType.ViewCenter;
            map.ShowCenter = false;
            map.MinZoom = 10;
            map.MaxZoom = 18;
        }

        private void txtSearch_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Enter)
            {
                map.GetPositionByKeywords(txtSearch.Text);
            }
        }
    }
}