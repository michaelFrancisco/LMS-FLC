using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using BLM.Models;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows;




namespace BLM.ViewModels.Production.Forms
{
    internal class NewProductionViewModel : Screen
    {
		private bool _btnOkIsClicked;

		public bool btnOkIsClicked
		{
			get { return _btnOkIsClicked; }
			set { _btnOkIsClicked = value; }
		}
		public void btnOK()
		{
			_itemGridSource = Connection.dbTable("Select * from flc.inventory_production where rfid='"+_txtRFID+"'");
			
			NotifyOfPropertyChange(() => itemGridSource);
			NotifyOfPropertyChange(() => txtRFID);
			_QuantityBoxVisibility = System.Windows.Visibility.Collapsed;
			NotifyOfPropertyChange(() => QuantityBoxVisibility);
		}

		private Visibility _QuantityBoxVisibility;

		public Visibility QuantityBoxVisibility
		{
			get { return _QuantityBoxVisibility; }
			set { _QuantityBoxVisibility = value; }
		}


		private DataTable _itemGridSource;

		public DataTable itemGridSource
		{
			get { return _itemGridSource; }
			set { _itemGridSource = value; }
		}

		private int _txtRFID;

		public int txtRFID
		{
			get { return _txtRFID; }
			set { _txtRFID = value; }
		}

	}
}
