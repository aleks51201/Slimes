using UnityEngine;

namespace SlimeEvolutions.Inventory
{
    public class InventoryButtonView : MonoBehaviour
    {
        InventoryButtonLogic buttonLogic;

        private void Start()
        {
            buttonLogic = new(this.gameObject);
        }

        public void OnClick()
        {
            buttonLogic.OnClick();
        }
    }
}
