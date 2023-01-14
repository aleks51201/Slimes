using SlimeEvolutions.InventoryCell;
using System;
using UnityEngine;


namespace SlimeEvolutions.Inventory
{
    public class InventoryButtonLogic
    {
        private GameObject gameObject;

        
        public static Action<Slime> OnInventoryButtonClickEvent;


        public InventoryButtonLogic(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public void OnClick()
        {
            ChangeBackGround();
            OnInventoryButtonClickEvent?.Invoke(GetSlime());
        }

        private void ChangeBackGround()
        {
        }

        private Slime GetSlime()
        {
            return gameObject.GetComponentInChildren<CellView>().Slime;
        }
    }
}
