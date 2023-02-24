using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class PanelActiveButton : MonoBehaviour
    {
        [SerializeField] GameObject[] activPanel;
        [SerializeField] GameObject[] deactivPanel;


        public static Action ButtonClickedStaticEvent;

        public Action ButtonClickedEvent;


        public void ActivationPanel()
        {
            foreach (var i in activPanel)
            {
                i.SetActive(true);
            }
            ButtonClickedStaticEvent?.Invoke();
            ButtonClickedEvent?.Invoke();
        }

        public void Deactivate()
        {
            foreach (var i in deactivPanel)
            {
                i.SetActive(false);
            }
            ButtonClickedStaticEvent?.Invoke();
            ButtonClickedEvent?.Invoke();
        }
    }
}
