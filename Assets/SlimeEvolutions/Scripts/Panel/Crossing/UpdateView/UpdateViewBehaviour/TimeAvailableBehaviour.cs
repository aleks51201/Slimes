using SlimeEvolutions.Panel.Crossing.CrossTimer;
using UnityEngine;

namespace SlimeEvolutions.Panel.Crossing.Update.Behaviours
{
    public class TimeAvailableBehaviour : IUpdateViewBehaviour
    {
        private UpdateView updateView;
        private bool isSubscribe;

        private UpdateViewBehaviour UpdateViewBehaviour => updateView.UpdateViewBehaviour;


        public void Enter(UpdateView updateView)
        {
            this.updateView = updateView;
            Initialize();
            Subscribe();
            Debug.Log("TimeAvailableBehaviour enter");
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
            TimerLogic.FinishedTimerEvent += ChangeBehaviour;
            Debug.Log("subscribe");
            isSubscribe = true;
        }

        private void Unsubscribe()
        {
            if (!isSubscribe)
            {
                return;
            }
            TimerLogic.FinishedTimerEvent -= ChangeBehaviour;
            isSubscribe = false;
        }

        private void Initialize()
        {
            updateView.ButtonSetActive(false);
            updateView.TimerSetActive(true);
            updateView.SliderSetActive(true);
            updateView.InitializedTimeAvailableBehaviourEvent?.Invoke();
        }

        private void ChangeBehaviour()
        {
            UpdateViewBehaviour.SetBehaviourByDefault();
        }
    }
}
