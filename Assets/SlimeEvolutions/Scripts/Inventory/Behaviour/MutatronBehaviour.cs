using Assets.Scripts;
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Panel;
using SlimeEvolutions.Panel.Mutatron;
using System;

namespace SlimeEvolutions.Inventory.Behaviour
{
    public class MutatronBehaviour : IInventoryBehaviour
    {
        private InventoryLogic inventoryLogic;


        public static Action MutatronBehaviourEnteredEvent;


        public void Enter(InventoryLogic inventory)
        {
            inventoryLogic = inventory;
            Subscribe();
            MutatronBehaviourEnteredEvent?.Invoke();
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
            BackButton.OnButtonClickEvent += inventoryLogic.InventoryBehaviour.SetBehaviourByDefault;
        }

        private void Unsubscribe()
        {
            SlimeInteractor.OnDataChangedEvent -= inventoryLogic.ViewUpdate;
            BackButton.OnButtonClickEvent -= inventoryLogic.InventoryBehaviour.SetBehaviourByDefault;
        }
    }
}
