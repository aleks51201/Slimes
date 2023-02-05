using System;
using UnityEngine;
using TMPro;

namespace SlimeEvolutions.Panel.Mutatron
{
    public class RecycleButtonLogic
    {
        private RecycleButtonView recycleButtonView;

        public static Action OnRecycleButtonClickEvent;

        public RecycleButtonLogic(RecycleButtonView gameObject)
        {
            this.recycleButtonView = gameObject;
            MutatronLogic.OnAddSlimeToArrayEvent += OnAddSlimeToArray;
        }

        public void OnClick()
        {
            StringByDefault();
            OnRecycleButtonClickEvent?.Invoke();
        }

        private void OnAddSlimeToArray(int mutagen)
        {
            recycleButtonView.GetComponentInChildren<TextMeshProUGUI>().text = $"Переработать выбранные +{mutagen}";
        }

        private void StringByDefault()
        {
            recycleButtonView.GetComponentInChildren<TextMeshProUGUI>().text = "Переработать выбранные";
        }
    }
}
