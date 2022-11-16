using System;
using UnityEngine;

namespace SlimeEvolutions.Panel.Laboratory
{
    public class ResearchButtonView: MonoBehaviour
    {
        public static Action OnButtonClickEvent;

        public void OnClick()
        {
            OnButtonClickEvent?.Invoke();
        }
    }
}
