namespace SlimeEvolutions.Inventory.Behaviour
{
    public interface IInventoryBehaviour
    {
        public void Enter(InventoryLogic inventoryLogic);
        public void Exit();
        public void OnEnable();
        public void OnDisable();
    }
}
