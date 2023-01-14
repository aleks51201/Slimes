using System;
using System.Collections;
using UnityEngine;

namespace SlimeEvolutions.Buttons
{
    public class ButtonWithHold : ButtonMain
    {
        private Coroutine currentRoutine;


        public Action OnButtonHoldEvent;


        private IEnumerator Timer()
        {
            int n = 0;
            while (n < 2)
            {
                yield return new WaitForSeconds(0.1f);
                n++;
            }
            OnButtonHoldEvent?.Invoke();
        }

        private void OnMouseDown()
        {
            if (!IsActive)
            {
                return;
            }
            currentRoutine = StartCoroutine(Timer());
        }

        private void OnMouseUp()
        {
            if (!IsActive)
            {
                return;
            }
            StopCoroutine(currentRoutine);
        }
    }
}
