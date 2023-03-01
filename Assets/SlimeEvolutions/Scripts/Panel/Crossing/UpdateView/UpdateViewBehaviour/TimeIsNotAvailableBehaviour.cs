using SlimeEvolutions.Panel.Crossing.TakeButton;
using System;
using UnityEngine;

namespace SlimeEvolutions.Panel.Crossing.Update.Behaviours
{
    public class TimeIsNotAvailableBehaviour : IUpdateViewBehaviour
    {
        private UpdateView updateView;
        private bool isSubscribe;


        public static Action ChangeBehaviourEvent;


        public void Enter(UpdateView updateView)
        {
            this.updateView = updateView;
            Initialize();
            Subscribe();
            Debug.Log("TimeIsNotAvailableBehaviour enter");
        }

        public void Exit()
        {
            Unsubscribe();
        }

        public void OnEnable()
        {
            SetBehaviourByDefault();
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
            updateView.TakeButton.OnButtonClickEvent += OnButtonClick;
            //TakeButtonView.ButtonClickedEvent += OnButtonClick;
            isSubscribe = true;
        }

        private void Unsubscribe()
        {
            if (!isSubscribe)
            {
                return;
            }
            updateView.TakeButton.OnButtonClickEvent -= OnButtonClick;
            //TakeButtonView.ButtonClickedEvent -= OnButtonClick;
            isSubscribe = false;
        }

        private void Initialize()
        {
            updateView.ButtonSetActive(true);
            updateView.TimerSetActive(false);
            updateView.SliderSetActive(false);
            updateView.InitializedTimeNotAvailableBehaviourEvent?.Invoke();
        }

        private void OnButtonClick()
        {
            ChangeBehaviour();
        }

        private void ChangeBehaviour()
        {
            //ChangeBehaviourEvent?.Invoke();
            updateView.UpdateViewBehaviour.SetIncorrectInformationBehaviour();
        }

        private void SetBehaviourByDefault()
        {
            updateView.UpdateViewBehaviour.SetBehaviourByDefault();
        }
    }
}
