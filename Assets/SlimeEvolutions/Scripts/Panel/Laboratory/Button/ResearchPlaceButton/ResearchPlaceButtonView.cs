using SlimeEvolutions.InventoryCell;
using System;
using UnityEngine;

namespace SlimeEvolutions.Panel.Laboratory
{
    public class ResearchPlaceButtonView : MonoBehaviour
    {
        public static Action OnButtonClickEvent;
        public static Action<Slime> OnButtonWithSlimeClickEvent;

        public void OnClick()
        {
            OnButtonClickEvent?.Invoke();
            OnButtonWithSlimeClickEvent?.Invoke(GetSlime());
        }

        private Slime GetSlime()
        {
            return this.gameObject.GetComponentInChildren<CellView>().Slime;
        }
    }
}
