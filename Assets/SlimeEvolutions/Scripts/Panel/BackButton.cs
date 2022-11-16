using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Button))]
    public class BackButton : MonoBehaviour
    {
        [SerializeField] GameObject currentPanel;

        public static Action OnButtonClickEvent;

        public void OnClick()
        {
            CloseCurrentPanel();
            OnButtonClickEvent?.Invoke();
        }

        private void CloseCurrentPanel()
        {
            currentPanel.SetActive(false);
        }

    }
}
