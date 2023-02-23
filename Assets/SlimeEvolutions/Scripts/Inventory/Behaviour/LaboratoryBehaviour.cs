using SlimeEvolutions.Architecture.Interactors.Instances;
using System;

namespace SlimeEvolutions.Inventory.Behaviour
{
    public class LaboratoryBehaviour : IInventoryBehaviour
    {
        private InventoryLogic inventoryLogic;


        public static Action LaboratoryBehaviourEnteredEvent;


        public void Enter(InventoryLogic inventory)
        {
            inventoryLogic = inventory;
            Subscribe();
            LaboratoryBehaviourEnteredEvent?.Invoke();
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
