using System;
using UnityEngine;

namespace SlimeEvolutions.Panel.Crossing.Update.Behaviours
{
    public class IncorrectInformationBehaviour : IUpdateViewBehaviour
    {
        private UpdateView updateView;
        private bool isSubscribe;

        public void Enter(UpdateView updateView)
        {
            this.updateView = updateView;
            Initialize();
            Subscribe();
            Debug.Log("IncorrectInformationBehaviour enter");
        }

        public void Exit()
        {
            Unsubscribe();
        }

        public void OnEnable()
        {
            ChangeBehaviour();
            Subscribe();
        }


        public void OnDisable()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            if (isSubscribe)
            {
                return;
            }
            isSubscribe = true;
        }

        private void Unsubscribe()
        {
            if (!isSubscribe)
            {
                return;
            }
            isSubscribe = false;
        }

        private void Initialize()
        {
            updateView.ButtonSetActive(false);
            updateView.TimerSetActive(false);
            updateView.SliderSetActive(false);
            updateView.ActiveLayerSetActive(false);
            updateView.InitializedIncorrectInformationBehaviourEvent?.Invoke();
        }

        private void ChangeBehaviour()
        {
            updateView.UpdateViewBehaviour.SetBehaviourByDefault();
        }
    }
}
