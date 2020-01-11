using Caliburn.Micro;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using GMap.NET;
using GMap.NET.MapProviders;
using System;
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
        private PointLatLng _mapPosition;
        private GMapProvider _mapProvider;
        private IFirebaseClient client;

        private IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "0UZRAqH7hUK7nvXBGMzrCvOVUDG1n1hA9zTQqlAq",
            BasePath = "https://blm-transportation-tracker.firebaseio.com/"
        };

        public PointLatLng mapPosition
        {
            get { return getloc(); }
            set { _mapPosition = value; }
        }

        public GMapProvider mapProvider
        {
            get { return GMapProviders.GoogleMap; }
            set { _mapProvider = value; }
        }

        public PointLatLng getloc()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("locations/420");
            Data obj = response.ResultAs<Data>();
            return new PointLatLng(obj.latitude, obj.longitude);
        }

        protected override void OnActivate()
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Tick += new EventHandler(timer_Tick);
            dt.Interval = new TimeSpan(0, 0, 5);
            dt.Start();
            GMapProviders.GoogleMap.ApiKey = @"AIzaSyB8B3hq7jeZtvEPtFdEoZ3Jd5IaZh2Hp3g";
            base.OnActivate();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _mapPosition = getloc();
            NotifyOfPropertyChange(() => mapPosition);
        }
    }
}