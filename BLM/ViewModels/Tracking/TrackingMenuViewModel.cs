using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLM.ViewModels.Tracking
{
    class TrackingMenuViewModel : Conductor<Screen>
    {
        public void btnLiveMap()
        {
            ActivateItem(new TrackingViewModel());

        }
        public void btnScheduling()
        {
            ActivateItem(new SchedulingViewModel());
        }
        public void btnTruckInfo()
        {
            ActivateItem(new TruckInfoViewModel());
        }
    }
}
