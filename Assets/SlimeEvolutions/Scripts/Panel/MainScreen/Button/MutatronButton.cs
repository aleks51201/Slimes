using System;
using UnityEngine;

namespace SlimeEvolutions.Panel.MainScreen
{
    public class MutatronButton : MonoBehaviour
    {
        public static Action OnButtonClickEvent;

        public void OnClick()
        {
            OnButtonClickEvent?.Invoke();
        }
    }
}
