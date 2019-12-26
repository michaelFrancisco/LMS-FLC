using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLM.ViewModels.Logging
{
    class DepartureViewModel : Screen
    {
        public void SaveButton()
        {
        }

        private string _ProductID;

        public string ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }

        private DataTable _LoggingGridItemSource;

        public DataTable LoggingGridItemSource
        {
            get { return _LoggingGridItemSource; }
            set { _LoggingGridItemSource = value; }
        }

    }
}
