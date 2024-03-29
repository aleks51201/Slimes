﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SlimeEvolutions.Buttons
{
    public class ButtonWithClickAndHold : ButtonMain
    {
        private Coroutine currentRoutine;
        private bool isHeld;


        public static Action OnButtonClickStaticEvent;
        public static Action OnButtonHoldStaticEvent;

        public Action OnButtonClickEvent;
        public Action OnButtonHoldEvent;


        private IEnumerator Hold()
        {
            int n = 0;
            while (n < 2)
            {
                yield return new WaitForSeconds(0.1f);
                n++;
            }
            OnButtonHoldEvent?.Invoke();
            OnButtonHoldStaticEvent?.Invoke();
            isHeld = true;
        }

        public void OnClick()
        {
            OnButtonClickEvent?.Invoke();
            OnButtonClickStaticEvent?.Invoke();
        }

        private void OnMouseDown(PointerEventData eventData )
        {
            if (!IsActive || eventData.button != PointerEventData.InputButton.Left )
            {
                return;
            }
            currentRoutine = StartCoroutine(Hold());
            isHeld = false;
        }

        private void OnMouseUp(PointerEventData eventData)
        {
            if (!IsActive || eventData.button != PointerEventData.InputButton.Left || isHeld )
            {
                return;
            }
            StopCoroutine(currentRoutine);
            OnClick();
        }

        private void OnEnable()
        {
            onPointerDownEvent += OnMouseDown;
            onPointerUpEvent += OnMouseUp;
        }

        private void OnDisable()
        {
            onPointerDownEvent -= OnMouseDown;
            onPointerUpEvent -= OnMouseUp;
        }
    }
}
