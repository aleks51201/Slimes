
using System;
using UnityEngine;
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
            onPointerDownEvent += OnClick;
        }

        private void OnDisable()
        {
            onPointerDownEvent -= OnClick;
        }
    }
}
