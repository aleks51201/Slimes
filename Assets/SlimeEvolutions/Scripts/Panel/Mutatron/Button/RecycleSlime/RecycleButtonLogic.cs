using System;
using UnityEngine;
using TMPro;

namespace SlimeEvolutions.Panel.Mutatron
{
    public class RecycleButtonLogic : IActivatable
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
            if (mutagen == 0)
            {
                StringByDefault();
                return;
            }
            recycleButtonView.GetComponentInChildren<TextMeshProUGUI>().text = $"{recycleButtonView.BeforeRecycle} +{mutagen}";
        }

        private void StringByDefault()
        {
            recycleButtonView.GetComponentInChildren<TextMeshProUGUI>().text = $"{recycleButtonView.AfterRecycle}";
        }

        public void OnEnable()
        {
            StringByDefault();
        }

        public void OnDisable()
        {
        }
    }
}
