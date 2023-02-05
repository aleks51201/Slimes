using SlimeEvolutions.Buttons;
using SlimeEvolutions.InventoryCell;
using System;
using UnityEngine;

namespace SlimeEvolutions.Inventory.InventoryButton
{
    public class SlimeGetter : MonoBehaviour
    {
        [SerializeField] private ButtonWithClickAndHold button;


        public static Action<Slime> ButtonClickedEvent;


        public Slime GetSlime()
        {
            return GetComponentInChildren<CellView>().Slime;
        }

        private void OnHold()
        {
            ButtonClickedEvent?.Invoke(GetSlime());
        }

        private void OnEnable()
        {
            button.OnButtonClickEvent += OnHold;
        }

        private void OnDisable()
        {
            button.OnButtonClickEvent -= OnHold;
        }
    }
}
