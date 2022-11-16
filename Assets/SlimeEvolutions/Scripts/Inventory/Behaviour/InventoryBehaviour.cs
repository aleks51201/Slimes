using System;
using System.Collections.Generic;

namespace SlimeEvolutions.Inventory.Behaviour
{
    public class InventoryBehaviour
    {

        private Dictionary<Type, IInventoryBehaviour> behavioursMap;
        private IInventoryBehaviour currentBehaviour;
        private InventoryLogic inventoryLogic;

        public IInventoryBehaviour CurrentBehaviour => currentBehaviour;

        public InventoryBehaviour(InventoryLogic inventory)
        {
            inventoryLogic = inventory;
        }

        public void InitializeBehaviour()
        {
            behavioursMap = new();
            behavioursMap[typeof(MainBehaviour)] = new MainBehaviour();
            behavioursMap[typeof(MutatronBehaviour)] = new MutatronBehaviour();
            behavioursMap[typeof(LaboratoryBehaviour)] = new LaboratoryBehaviour();
        }

        private void SetBehaviour(IInventoryBehaviour newBehavior)
        {
            if (currentBehaviour != null)
            {
                currentBehaviour.Exit();
            }
            currentBehaviour = newBehavior;
            currentBehaviour.Enter(inventoryLogic);
        }

        public void SetBehaviourByDefault()
        {
            SetBehaviourMain();
        }

        private IInventoryBehaviour GetBehaviour<T>() where T : IInventoryBehaviour
        {
            return behavioursMap[typeof(T)];
        }

        public void SetBehaviourMain()
        {
            SetBehaviour(GetBehaviour<MainBehaviour>());
        }

        public void SetBehaviourMutatron()
        {
            SetBehaviour(GetBehaviour<MutatronBehaviour>());
        }

        public void SetBehaviourLaboratory()
        {
            SetBehaviour(GetBehaviour<LaboratoryBehaviour>());
        }
    }
}
