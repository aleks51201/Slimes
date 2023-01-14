using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Panel.MainScreen;

namespace SlimeEvolutions.Inventory.Behaviour
{
    public class MainBehaviour : IInventoryBehaviour
    {
        private InventoryLogic inventoryLogic;
        private bool isInitialized;

        public void Enter(InventoryLogic inventory)
        {
            inventoryLogic = inventory;
            Subscribe();
        }

        public void Exit()
        {
            Unsubscribe();
        }

        public void OnEnable()
        {
            Subscribe();
            if (isInitialized)
            {
                inventoryLogic.ViewUpdate();
                return;
            }
            OneTimeSubscribe();
        }

        public void OnDisable()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            MutatronButton.OnButtonClickEvent += inventoryLogic.InventoryBehaviour.SetBehaviourMutatron;
            LaboratoryButton.OnButtonClickEvent += inventoryLogic.InventoryBehaviour.SetBehaviourLaboratory;
            SlimeInteractor.OnDataChangedEvent += inventoryLogic.ViewUpdate;
        }

        private void Unsubscribe()
        {
            MutatronButton.OnButtonClickEvent -= inventoryLogic.InventoryBehaviour.SetBehaviourMutatron;
            LaboratoryButton.OnButtonClickEvent -= inventoryLogic.InventoryBehaviour.SetBehaviourLaboratory;
            SlimeInteractor.OnDataChangedEvent -= inventoryLogic.ViewUpdate;
        }
        private void OneTimeSubscribe()
        {
            SlimesInventory.OnSlimeInteractorFacadeInitializedEvent += inventoryLogic.ViewUpdate;
            SlimesInventory.OnSlimeInteractorFacadeInitializedEvent += LocalUp;
            isInitialized = false;
        }

        private void LocalUp()
        {
            SlimesInventory.OnSlimeInteractorFacadeInitializedEvent -= inventoryLogic.ViewUpdate;
            SlimesInventory.OnSlimeInteractorFacadeInitializedEvent -= LocalUp;
            isInitialized = true;
        }

    }
}
