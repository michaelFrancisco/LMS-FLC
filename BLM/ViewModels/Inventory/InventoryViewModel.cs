using BLM.Models;
using BLM.ViewModels.Inventory.Forms;
using Caliburn.Micro;
using Stimulsoft.Report;
using System;
using System.Data;
using System.Windows;

namespace BLM.ViewModels.Inventory
{
    internal class InventoryViewModel : Conductor<Screen>
    {
        private readonly IWindowManager windowManager = new WindowManager();
        private object _inventoryGridSelectedItem;

        private DataTable _inventoryGridSource;

        private string _selectedCategory;

        private string _txtSearch;

        public object inventoryGridSelectedItem
        {
            get { return _inventoryGridSelectedItem; }
            set { _inventoryGridSelectedItem = value; }
        }

        public DataTable inventoryGridSource
        {
            get { return _inventoryGridSource; }
            set { _inventoryGridSource = value; }
        }

        public string txtSearch
        {
            get { return _txtSearch; }
            set
            {
                _txtSearch = value;
                DataView dv = new DataView(_inventoryGridSource);
                dv.RowFilter = "Name LIKE '%" + _txtSearch + "%'";
                _inventoryGridSource = dv.ToTable();
                NotifyOfPropertyChange(null);
            }
        }

        public void btnAll()
        {
            _inventoryGridSource = Connection.dbTable("SELECT * from inventory");
            NotifyOfPropertyChange(null);
            _selectedCategory = "All Products";
        }

        public void btnCreate()
        {
            windowManager.ShowWindow(new NewItemViewModel(), null, null);
        }

        public void btnExport()
        {
        }

        public void btnFinished()
        {
            _inventoryGridSource = Connection.dbTable("SELECT * from inventory where Category = 'Finished Product'");
            NotifyOfPropertyChange(null);
            _selectedCategory = "Finished Products";
        }

        public void btnPackaging()
        {
            _inventoryGridSource = Connection.dbTable("SELECT * from inventory where Category = 'Packaging'");
            NotifyOfPropertyChange(null);
            _selectedCategory = "Packaging";
        }

        public void btnRawMaterials()
        {
            _inventoryGridSource = Connection.dbTable("SELECT * from inventory where Category = 'Raw Material'");
            NotifyOfPropertyChange(null);
            _selectedCategory = "Raw Materials";
        }

        public void btnRefresh()
        {
            switch (_selectedCategory)
            {
                case "Raw Materials":
                    _inventoryGridSource = Connection.dbTable("SELECT * from inventory where Category = 'Raw Material'");
                    NotifyOfPropertyChange(null);
                    break;

                case "Packaging":
                    _inventoryGridSource = Connection.dbTable("SELECT * from inventory where Category = 'Packaging'");
                    NotifyOfPropertyChange(null);
                    break;

                case "Finished Products":
                    _inventoryGridSource = Connection.dbTable("SELECT * from inventory where Category = 'Finished Product'");
                    NotifyOfPropertyChange(null);
                    break;

                case "All Products":
                    _inventoryGridSource = Connection.dbTable("SELECT * from inventory");
                    NotifyOfPropertyChange(null);
                    break;

                case "Requests":
                    _inventoryGridSource = Connection.dbTable("SELECT `production_requests`.`ID`, `inventory`.`Name`, `production_requests`.`Theoretical_Yield`, `production_requests`.`Status`, `production_requests`.`Due_Date`,`inventory`.`ID` FROM `flc`.`production_requests` INNER JOIN `flc`.`inventory` ON `production_requests`.`Recipe_ID` = `inventory`.`ID` WHERE Status = 'Waiting for Raw Materials' or Status = 'Finished by the Production Team. Waiting for Dispensing officer to transfer to inventory.'");
                    NotifyOfPropertyChange(null);
                    break;
            }
            _txtSearch = string.Empty;
            NotifyOfPropertyChange(null);
        }

        public void btnRequests()
        {
            _inventoryGridSource = Connection.dbTable("SELECT `production_requests`.`ID`, `inventory`.`Name`, `production_requests`.`Theoretical_Yield`, `production_requests`.`Status`, `production_requests`.`Due_Date`,`inventory`.`ID` FROM `flc`.`production_requests` INNER JOIN `flc`.`inventory` ON `production_requests`.`Recipe_ID` = `inventory`.`ID` WHERE Status = 'Waiting for Raw Materials' or Status = 'Finished by the Production Team. Waiting for Dispensing officer to transfer to inventory.'");
            NotifyOfPropertyChange(null);
            _selectedCategory = "Requests";
        }

        public void showItem()
        {
            try
            {
                DataRowView dataRowView = (DataRowView)_inventoryGridSelectedItem;
                switch (_selectedCategory)
                {
                    case "Requests":
                        if (dataRowView.Row[3].ToString() == "Finished by the Production Team. Waiting for Dispensing officer to transfer to inventory.")
                        {
                            MessageBoxResult dialogResult = MessageBox.Show("Move finished products to inventory?", "!", MessageBoxButton.YesNo);
                            if (dialogResult == MessageBoxResult.Yes)
                            {
                                Connection.dbCommand("UPDATE `flc`.`production_requests` SET `Status` = 'Finished' WHERE (`ID` = '" + dataRowView.Row[0].ToString() + "');");
                                DataTable currentQuantity = Connection.dbTable("SELECT Quantity FROM flc.inventory where ID = " + dataRowView.Row[5].ToString() + ";");
                                Connection.dbCommand("UPDATE `flc`.`inventory` SET `Quantity` = '" + (((int)currentQuantity.Rows[0][0]) + (int)dataRowView.Row[2]).ToString() + "' WHERE (`ID` = '" + dataRowView.Row[5].ToString() + "');");
                                Connection.dbCommand("INSERT INTO `flc`.`system_log` (`Subject`, `Category`, `User_ID`, `Body`) VALUES ('" + dataRowView.Row[1].ToString() + "(x" + dataRowView.Row[2].ToString() + ") was added to inventory', 'Inventory Update', '" + CurrentUser.User_ID.ToString() + "', '" + dataRowView.Row[1].ToString() + "(x" + dataRowView.Row[2].ToString() + ") was added to inventory from Request no." + dataRowView.Row[0].ToString() + " and approved by " + CurrentUser.name + " on " + System.DateTime.Now.ToString() + "');");
                            }
                        }
                        else
                        {
                            windowManager.ShowWindow(new RequestViewModel(Int32.Parse(dataRowView.Row[0].ToString())), null, null);
                        }
                        break;

                    default:
                        windowManager.ShowWindow(new EditItemViewModel(Convert.ToInt32(dataRowView.Row[0])), null, null);
                        break;
                }
                NotifyOfPropertyChange(null);
            }
            catch (Exception)
            {
            }
        }

        protected override void OnActivate()
        {
            _inventoryGridSource = Connection.dbTable("SELECT * from inventory");
            _selectedCategory = "All Products";
            NotifyOfPropertyChange(null);
            base.OnActivate();
        }

        public void btnPrint()
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + @"\Reporting\InventoryReport.mrt";

            StiReport report = new StiReport();
            // report.Load(@"\BLM\Reports\InventoryReport.mrt");
            //report.Load(@"C:\Users\TOYBITS\source\repos\michaelFrancisco\BLM\BLM\Reports\InventoryReport.mrt");
            report.Load(path);
            report.Show();
        }
    }
}