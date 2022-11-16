using System;
using UnityEngine;
using TMPro;

namespace SlimeEvolutions.Panel.Mutatron
{
    public class RecycleButtonLogic
    {
        private GameObject gameObject;

        public static Action OnRecycleButtonClickEvent;

        public RecycleButtonLogic(GameObject gameObject)
        {
            this.gameObject = gameObject;
            MutatronLogic.OnAddSlimeToArrayEvent += OnAddSlimeToArray;
        }

        public void OnClick()
        {
            StringByDefault();
            OnRecycleButtonClickEvent?.Invoke();
        }

        private void OnAddSlimeToArray(int mutagen)
        {
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = $"Переработать выбранные +{mutagen}";
        }

        private void StringByDefault()
        {
            gameObject.GetComponentInChildren<TextMeshProUGUI>().text = "Переработать выбранные";
        }
    }
}
