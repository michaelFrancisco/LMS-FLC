using BLM.Models;
using BLM.ViewModels.Production.Forms;
using Caliburn.Micro;
using System.Data;
using System.Windows;

//using System.Drawing;

namespace BLM.ViewModels.Production
{
    internal class ProductionViewModel : Screen
    {
        private readonly IWindowManager windowManager = new WindowManager();
        private string _lblButton;
        private object _productionGridSelectedItem;
        private DataTable _productionGridSource;

        public string lblButton
        {
            get { return _lblButton; }
            set { _lblButton = value; }
        }

        private Visibility _btnProceedVisibility;

        public Visibility btnProceedVisibility
        {
            get { return _btnProceedVisibility; }
            set { _btnProceedVisibility = value; }
        }

        public object productionGridSelectedItem
        {
            get { return _productionGridSelectedItem; }
            set { _productionGridSelectedItem = value; }
        }

        public DataTable productionGridSource
        {
            get { return _productionGridSource; }
            set { _productionGridSource = value; }
        }

        public void btnFinished()
        {
            _btnProceedVisibility = Visibility.Hidden;
            _productionGridSource = Connection.dbTable("SELECT `production_requests`.`ID`, `inventory`.`Name`, `production_requests`.`Theoretical_Yield` AS 'Requested Amount', `production_requests`.`Due_Date` FROM `flc`.`production_requests` INNER JOIN `flc`.`inventory` ON `inventory`.`ID` = `production_requests`.`Recipe_ID` where `production_requests`.`Status` = 'Finished'; ");
            NotifyOfPropertyChange(null);
        }

        public void btnPending()
        {
            _btnProceedVisibility = Visibility.Visible;
            _lblButton = "Accept Raw Materials From Inventory";
            _productionGridSource = Connection.dbTable("SELECT `production_requests`.`ID`, `inventory`.`Name`, `production_requests`.`Theoretical_Yield` AS 'Requested Amount', `production_requests`.`Due_Date` FROM `flc`.`production_requests` INNER JOIN `flc`.`inventory` ON `inventory`.`ID` = `production_requests`.`Recipe_ID`where `production_requests`.`Status` = 'Pending'; ");
            NotifyOfPropertyChange(null);
        }

        public void btnProceed()
        {
            try
            {
                DataRowView dataRowView = (DataRowView)_productionGridSelectedItem;
                switch (_lblButton)
                {
                    case "Accept Raw Materials From Inventory":
                        windowManager.ShowWindow(new NewProductionViewModel((int)dataRowView.Row[0]), null, null);
                        break;

                    case "Mark Request as Finished":
                        MessageBoxResult dialogResult = MessageBox.Show("Mark this request as finished?", "!", MessageBoxButton.YesNo);
                        if (dialogResult == MessageBoxResult.Yes)
                        {
                            Connection.dbCommand("UPDATE `flc`.`production_requests` SET `Status` = 'Finished' WHERE (`ID` = '" + dataRowView.Row[0].ToString() + "');");
                            MessageBox.Show("Dispensing Officer has been notified, please prepare items for physical inspection");
                        }
                        break;
                }
            }
            catch
            {
            }
        }

        public void btnProcessing()
        {
            _btnProceedVisibility = Visibility.Visible;
            _lblButton = "Mark Request as Finished";
            _productionGridSource = Connection.dbTable("SELECT `production_requests`.`ID`, `inventory`.`Name`, `production_requests`.`Theoretical_Yield` AS 'Requested Amount', `production_requests`.`Due_Date` FROM `flc`.`production_requests` INNER JOIN `flc`.`inventory` ON `inventory`.`ID` = `production_requests`.`Recipe_ID` where `production_requests`.`Status` = 'Processing'; ");
            NotifyOfPropertyChange(null);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            _lblButton = "Accept Raw Materials From Inventory";
            _btnProceedVisibility = Visibility.Visible;
            _productionGridSource = Connection.dbTable("SELECT `production_requests`.`ID`, `inventory`.`Name`, `production_requests`.`Theoretical_Yield` AS 'Requested Amount', `production_requests`.`Due_Date` FROM `flc`.`production_requests` INNER JOIN `flc`.`inventory` ON `inventory`.`ID` = `production_requests`.`Recipe_ID`where `production_requests`.`Status` = 'Pending'; ");
            NotifyOfPropertyChange(null);
        }
    }
}