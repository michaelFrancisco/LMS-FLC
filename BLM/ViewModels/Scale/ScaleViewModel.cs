using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BLM.ViewModels.Scale
{
    class ScaleViewModel : Screen
    {
        private int _inputtextbox;
        private int _secondtextbox;
        private int _totaltextbox;
        private List<string> _unitofmeasurement;

        public int inputTextbox
        {
            get { return _inputtextbox; }
            set 
            {
                _inputtextbox = value;
                try
                {
                    if (_secondtextbox > -1)
                    {
                        _totaltextbox = _inputtextbox / _secondtextbox;
                        NotifyOfPropertyChange(() => totalTextbox);
                    }
                }
                catch
                {
                }
            }
        }

        public int secondTextbox
        {
            get { return _secondtextbox; }
            set { _secondtextbox = value; }
        }

        public int totalTextbox
        {
            get { return _totaltextbox; }
            set { _totaltextbox = value; }
        }

        public List<string> type
        {
            get { return new List<string> { "grams","litters","kilograms" }; }
            set
            {
                _unitofmeasurement = value;
                

                NotifyOfPropertyChange(() => secondTextbox);
                //_type = value;
                //DataView dv = new DataView(_baseVehicleGridItemSource);
                //dv.RowFilter = query();
                //_vehicleGridSource = dv.ToTable();
                //NotifyOfPropertyChange(() => vehicleGridSource);
            }
        }
    }
}
