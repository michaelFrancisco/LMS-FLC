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
        private int _actualYield;
        private int _inputtextbox;
        private int _percentageYield;
        private int _secondtextbox;
        private string _selecteditem;
        private string _selectedmeasure;
        private int _theoreticalYield;
        private int _totaltextbox;
        private List<string> _type;
        private List<string> _unitofmeasurement;


        public int actualYield
        {
            get { return _actualYield; }
            set
            {
                _actualYield = value;

                try
                {
                    if (_theoreticalYield > -1)
                    {
                        _percentageYield = 100 * (_actualYield / _theoreticalYield);
                        NotifyOfPropertyChange(() => percentageYield);
                    }
                }
                catch
                {

                }
            }
        }

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
        public List<string> measurement
        {
            get { return new List<string> { "grams", "litters", "kilograms" }; }
            set
            {
                _unitofmeasurement = value;
            }
        }

        public int percentageYield
        {
            get { return _percentageYield; }
            set
            {
                _percentageYield = value;
                
            }
        }

        public int secondTextbox
        {
            get { return _secondtextbox; }
            set { _secondtextbox = value; }
        }

        public string selecteditem
        {
            get { return _selecteditem; }
            set 
            {
                _selecteditem = value;
                if (_selecteditem == "bottles")
                {
                    _secondtextbox = 2;
                    NotifyOfPropertyChange(() => secondTextbox);
                    _selectedmeasure = "kilograms";
                    NotifyOfPropertyChange(() => selectedmeasure);
                    _theoreticalYield = 25;
                    NotifyOfPropertyChange(() => theoreticalYield);
                    
                }
                else if (_selecteditem == "cans")
                {
                    _secondtextbox = 3;
                    NotifyOfPropertyChange(() => secondTextbox);
                    _selectedmeasure = "grams";
                    NotifyOfPropertyChange(() => selectedmeasure);
                    _theoreticalYield = 30;
                    NotifyOfPropertyChange(() => theoreticalYield);
                }
            }
        }
        public string selectedmeasure
        {
            get { return _selectedmeasure; }
            set { _selectedmeasure = value; }
        }
        public int theoreticalYield
        {
            get { return _theoreticalYield; }
            set
            {
                _theoreticalYield = value;

                try
                {
                    if (_actualYield > -1)
                    {
                        _percentageYield = 100 * (_actualYield / _theoreticalYield);
                        NotifyOfPropertyChange(() => percentageYield);
                    }
                }
                catch
                {

                }
            }
        }

        public int totalTextbox
        {
            get { return _totaltextbox; }
            set { _totaltextbox = value; }
        }
        
        public List<string> type
        {
            get 
            {
                return new List<string> { "bottles", "cans" };
            }
            set 
            {
                _type = value;
            }
        }
    }
}
