using System;
using UnityEngine.EventSystems;

namespace SlimeEvolutions.Buttons
{
    public class ButtonWithClick : ButtonMain
    {
        public Action OnButtonClickEvent;


        public void OnClick(PointerEventData eventData)
        {
            if (!IsActive || eventData.button != PointerEventData.InputButton.Left)
            {
                return;
            }
            OnButtonClickEvent?.Invoke();
        }

        private void OnEnable()
        {
            onPointerClickEvent += OnClick;
        }

        private void OnDisable()
        {
            onPointerClickEvent -= OnClick;
        }
    }
}
