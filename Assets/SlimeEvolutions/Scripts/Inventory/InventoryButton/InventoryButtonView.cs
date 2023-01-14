using UnityEngine;

namespace SlimeEvolutions.Inventory
{
    public class InventoryButtonView : MonoBehaviour
    {
        private InventoryButtonLogic buttonLogic;

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
