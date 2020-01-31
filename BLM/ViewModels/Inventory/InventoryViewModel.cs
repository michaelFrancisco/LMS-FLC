using BLM.Models;
using BLM.ViewModels.Inventory.Forms;
using Caliburn.Micro;
using System;
using System.ComponentModel;
using System.Data;

namespace BLM.ViewModels.Inventory
{
    internal class InventoryViewModel : Conductor<Screen>
    {
        private readonly IWindowManager windowManager = new WindowManager();
        private object _inventoryGridSelectedItem;

        private DataTable _inventoryGridSource;

        private string _selectedCategory;

        private string _txtSearch;

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
            }
            _txtSearch = string.Empty;
            NotifyOfPropertyChange(null);
        }

        public void showItem()
        {
            try
            {
                DataRowView dataRowView = (DataRowView)_inventoryGridSelectedItem;
                windowManager.ShowWindow(new EditItemViewModel(Convert.ToInt32(dataRowView.Row[0])), null, null);
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
    }
}