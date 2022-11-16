using SlimeEvolutions.Architecture.Interactors.Instances;

namespace SlimeEvolutions.Inventory.Behaviour
{
    public class LaboratoryBehaviour : IInventoryBehaviour
    {
        InventoryLogic inventoryLogic;

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
            inventoryLogic.ViewUpdate();
        }

        public void OnDisable()
        {
        }

        private void Subscribe()
        {
            SlimeInteractor.OnDataChangedEvent += inventoryLogic.ViewUpdate;
        }

        private void Unsubscribe()
        {
            SlimeInteractor.OnDataChangedEvent -= inventoryLogic.ViewUpdate;
        }
    }
}
