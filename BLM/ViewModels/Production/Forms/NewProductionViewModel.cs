using BLM.Models;
using Caliburn.Micro;
using System;
using System.Data;
using System.Windows;

namespace BLM.ViewModels.Production.Forms
{
    internal class NewProductionViewModel : Screen
    {
        private int _selectedRequestID;
        public NewProductionViewModel(int selectedRequestID)
        {
            _selectedRequestID = selectedRequestID;
        }
    }
}