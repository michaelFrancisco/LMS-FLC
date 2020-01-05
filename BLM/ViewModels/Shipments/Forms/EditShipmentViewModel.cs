using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLM.ViewModels.Shipments.Forms
{
    class EditShipmentViewModel : Screen
    {
        private int _selectedShipmentID;

        public EditShipmentViewModel(int selectedShipmentID)
        {
            _selectedShipmentID = selectedShipmentID;
        }
    }
}
