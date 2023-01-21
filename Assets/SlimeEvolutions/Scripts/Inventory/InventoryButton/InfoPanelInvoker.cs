using SlimeEvolutions.Buttons;
using SlimeEvolutions.InventoryCell;
using System;
using UnityEngine;

namespace SlimeEvolutions.Inventory.InventoryButton
{
    public class InfoPanelInvoker:MonoBehaviour
    {
        [SerializeField] private ButtonWithClickAndHold button;


        public static Action<Slime> ButtonHeldEvent;


        private Slime GetSlime()
        {
            return GetComponent<CellView>().Slime;
        }

        private void OnHold()
        {
            ButtonHeldEvent?.Invoke(GetSlime());
        }

        private void OnEnable()
        {
            button.OnButtonHoldEvent += OnHold;
        }

        private void OnDisable()
        {
            button.OnButtonHoldEvent -= OnHold;
        }
    }
}
