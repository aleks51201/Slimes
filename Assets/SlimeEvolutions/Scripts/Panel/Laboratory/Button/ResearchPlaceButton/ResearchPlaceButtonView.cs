using SlimeEvolutions.InventoryCell;
using System;
using UnityEngine;

namespace SlimeEvolutions.Panel.Laboratory
{
    public class ResearchPlaceButtonView : MonoBehaviour
    {
        public static Action OnButtonClickEvent;

        public void OnClick()
        {
            OnButtonClickEvent?.Invoke();
        }

        private Slime GetSlime()
        {
            return this.gameObject.GetComponentInChildren<CellView>().Slime;
        }
    }
}
