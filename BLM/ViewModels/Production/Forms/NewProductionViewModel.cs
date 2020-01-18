using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLM.ViewModels.Production.Forms
{
    class NewProductionViewModel
    {
		private bool _btnOkIsClicked;

		public bool btnOkIsClicked
		{
			get { return _btnOkIsClicked; }
			set { _btnOkIsClicked = value; }
		}
		private void myVar;

		public void MyProperty
		{
			get { return myVar; }
			set { myVar = value; }
		}

	}
}
