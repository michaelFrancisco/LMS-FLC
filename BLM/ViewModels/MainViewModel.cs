using BLM.ViewModels.CreateOrder;
using BLM.ViewModels.Inventory;
using BLM.ViewModels.Logging;
using BLM.ViewModels.Production;
using Caliburn.Micro;

namespace BLM.ViewModels
{
    internal class MainViewModel : Conductor<Screen>
    {
        private readonly IWindowManager windowManager = new WindowManager();

        public void CreateDepartingOrderButton()
        {
            ActivateItem(new CreateDepartingOrderViewModel());
        }

        public void CreateReceivingOrderButton()
        {
            ActivateItem(new CreateReceivingOrderViewModel());
        }

        public void DepartureButton()
        {
            ActivateItem(new SelectDepartingOrderViewModel());
        }

        public void FinishProductButton()
        {
            ActivateItem(new FinishproductViewModel());
        }

        public void HistoryButton()
        {
            ActivateItem(new HistoryViewModel());
        }

        public void InventoryButton()
        {
            ActivateItem(new InventoryViewModel());
        }

        public void LogoutButton()
        {
            windowManager.ShowWindow(new LoginViewModel(), null, null);
            TryClose();
        }

        public void RawMatButton()
        {
            ActivateItem(new RawmaterialsViewModel());
        }

        public void ReceivingButton()
        {
            ActivateItem(new SelectReceivingOrderViewModel());
        }
    }
}