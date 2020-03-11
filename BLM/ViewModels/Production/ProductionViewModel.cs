using BLM.Models;
using BLM.ViewModels.Production.Forms;
using Caliburn.Micro;
using System;
using System.Data;
using System.Windows;

//using System.Drawing;

namespace BLM.ViewModels.Production
{
    internal class ProductionViewModel : Screen
    {
        private readonly IWindowManager windowManager = new WindowManager();
        private Visibility _btnAcceptRawMaterialsVisibility;
        private Visibility _btnProceedVisibility;
        private object _productionGridSelectedItem;
        private DataTable _productionGridSource;
        private int _txtActualYield;
        private string selectedCategory;

        public Visibility btnAcceptRawMaterialsVisibility
        {
            get { return _btnAcceptRawMaterialsVisibility; }
            set { _btnAcceptRawMaterialsVisibility = value; }
        }

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

        public int txtActualYield
        {
            get { return _txtActualYield; }
            set { _txtActualYield = value; }
        }

        public static void DialogHost_OnDialogClosing(int ActualYield, object productionGridSelectedItem)
        {
            DataRowView dataRowView = (DataRowView)productionGridSelectedItem;
            double percentYield = (ActualYield / double.Parse(dataRowView.Row["Requested Amount"].ToString())) * 100;
            Connection.dbCommand("UPDATE `flc`.`production_requests` SET `Status` = 'Finished by the Production Team. Waiting for Dispensing officer to transfer to inventory', `Actual_Yield` = '" + ActualYield.ToString() + "', `Percent_Yield` = '" + Math.Round(percentYield, 2) + "', `Date_Accomplished` = '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE(`ID` = '" + dataRowView.Row[0].ToString() + "');");
            Connection.dbCommand("INSERT INTO `flc`.`system_log` (`Subject`, `Category`, `User_ID`, `Body`) VALUES ('Production of " + dataRowView.Row["Name"].ToString() + " has finished', 'Inventory', '" + CurrentUser.User_ID + "', 'Production of " + dataRowView.Row["Name"].ToString() + " has finished on " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ", please pick up and inspect the finished product as soon as possible');");
            MessageBox.Show("Dispensing Officer has been notified, please prepare items for physical inspection");
        }

        public void btnAcceptRawMaterials()
        {
            DataRowView dataRowView = (DataRowView)_productionGridSelectedItem;
            windowManager.ShowWindow(new NewProductionViewModel(Int32.Parse(dataRowView.Row[0].ToString())), null, null);
        }

        public void btnFinished()
        {
            _btnProceedVisibility = Visibility.Collapsed;
            _btnAcceptRawMaterialsVisibility = Visibility.Collapsed;
            _productionGridSource = Connection.dbTable("SELECT `production_requests`.`ID`, `inventory`.`Name`, `production_requests`.`Theoretical_Yield` AS 'Requested Amount', `production_requests`.`Due_Date` FROM `flc`.`production_requests` INNER JOIN `flc`.`inventory` ON `inventory`.`ID` = `production_requests`.`Recipe_ID` where `production_requests`.`Status` = 'Finished'; ");
            NotifyOfPropertyChange(null);
            selectedCategory = "Finished";
        }

        public void btnPending()
        {
            _btnProceedVisibility = Visibility.Collapsed;
            _btnAcceptRawMaterialsVisibility = Visibility.Visible;
            _productionGridSource = Connection.dbTable("SELECT `production_requests`.`ID`, `inventory`.`Name`, `production_requests`.`Theoretical_Yield` AS 'Requested Amount', `production_requests`.`Due_Date` FROM `flc`.`production_requests` INNER JOIN `flc`.`inventory` ON `inventory`.`ID` = `production_requests`.`Recipe_ID`where `production_requests`.`Status` = 'Raw Materials delivered to Production team. Awaiting confirmation'; ");
            NotifyOfPropertyChange(null);
            selectedCategory = "Pending";
        }

        public void btnProceed()
        {
            //MessageBoxResult dialogResult = MessageBox.Show("Mark this request as finished?", "!", MessageBoxButton.YesNo);
            //if (dialogResult == MessageBoxResult.Yes)
            //{
            //    Connection.dbCommand("UPDATE `flc`.`production_requests` SET `Status` = 'Finished by the Production Team. Waiting for Dispensing officer to transfer to inventory.' WHERE (`ID` = '" + dataRowView.Row[0].ToString() + "');");
            //    MessageBox.Show("Dispensing Officer has been notified, please prepare items for physical inspection");
            //}
        }

        public void btnProcessing()
        {
            _btnProceedVisibility = Visibility.Visible;
            _btnAcceptRawMaterialsVisibility = Visibility.Collapsed;
            _productionGridSource = Connection.dbTable("SELECT `production_requests`.`ID`, `inventory`.`Name`, `production_requests`.`Theoretical_Yield` AS 'Requested Amount', `production_requests`.`Due_Date` FROM `flc`.`production_requests` INNER JOIN `flc`.`inventory` ON `inventory`.`ID` = `production_requests`.`Recipe_ID` where `production_requests`.`Status` = 'Currently being processed by the Production Team'; ");
            NotifyOfPropertyChange(null);
            selectedCategory = "Processing";
        }

        public void btnRefresh()
        {
            switch (selectedCategory)
            {
                case "Pending":
                    _productionGridSource = Connection.dbTable("SELECT `production_requests`.`ID`, `inventory`.`Name`, `production_requests`.`Theoretical_Yield` AS 'Requested Amount', `production_requests`.`Due_Date` FROM `flc`.`production_requests` INNER JOIN `flc`.`inventory` ON `inventory`.`ID` = `production_requests`.`Recipe_ID`where `production_requests`.`Status` = 'Raw Materials delivered to Production team. Awaiting confirmation'; ");
                    NotifyOfPropertyChange(null);
                    break;

                case "Processing":
                    _productionGridSource = Connection.dbTable("SELECT `production_requests`.`ID`, `inventory`.`Name`, `production_requests`.`Theoretical_Yield` AS 'Requested Amount', `production_requests`.`Due_Date` FROM `flc`.`production_requests` INNER JOIN `flc`.`inventory` ON `inventory`.`ID` = `production_requests`.`Recipe_ID` where `production_requests`.`Status` = 'Currently being processed by the Production Team'; ");
                    NotifyOfPropertyChange(null);
                    break;

                case "Finished":
                    _productionGridSource = Connection.dbTable("SELECT `production_requests`.`ID`, `inventory`.`Name`, `production_requests`.`Theoretical_Yield` AS 'Requested Amount', `production_requests`.`Due_Date` FROM `flc`.`production_requests` INNER JOIN `flc`.`inventory` ON `inventory`.`ID` = `production_requests`.`Recipe_ID` where `production_requests`.`Status` = 'Finished'; ");
                    NotifyOfPropertyChange(null);
                    break;
            }
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            _btnProceedVisibility = Visibility.Collapsed;
            _btnAcceptRawMaterialsVisibility = Visibility.Visible;
            _productionGridSource = Connection.dbTable("SELECT `production_requests`.`ID`, `inventory`.`Name`, `production_requests`.`Theoretical_Yield` AS 'Requested Amount', `production_requests`.`Due_Date` FROM `flc`.`production_requests` INNER JOIN `flc`.`inventory` ON `inventory`.`ID` = `production_requests`.`Recipe_ID`where `production_requests`.`Status` = 'Raw Materials delivered to Production team. Awaiting confirmation'; ");
            selectedCategory = "Pending";
            NotifyOfPropertyChange(null);
        }
    }
}