using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SlimeEvolutions.Buttons
{
    public abstract class ButtonMain : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        public bool IsActive = true;


        private protected Action<PointerEventData> onPointerClickEvent;
        private protected Action<PointerEventData> onPointerDownEvent;
        private protected Action<PointerEventData> onPointerUpEvent;


        public void OnPointerClick(PointerEventData eventData)
        {
            onPointerClickEvent?.Invoke(eventData);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            onPointerDownEvent?.Invoke(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            onPointerUpEvent?.Invoke(eventData);
        }
    }
}
