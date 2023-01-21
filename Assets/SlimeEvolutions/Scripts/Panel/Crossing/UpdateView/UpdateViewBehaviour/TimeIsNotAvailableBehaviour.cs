using SlimeEvolutions.Panel.Crossing.TakeButton;

namespace SlimeEvolutions.Panel.Crossing.Update.Behaviours
{
    public class TimeIsNotAvailableBehaviour : IUpdateViewBehaviour
    {
        private UpdateView updateView;
        private bool isSubscribe;

        public void Enter(UpdateView updateView)
        {
            this.updateView = updateView;
            Initialize();
            Subscribe();
        }

        public void Exit()
        {
            Unsubscribe();
        }

        public void OnEnable()
        {
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
            TakeButtonView.ButtonClickedEvent += OnButtonClick;
            isSubscribe = true;
        }

        private void Unsubscribe()
        {
            if (!isSubscribe)
            {
                return;
            }
            TakeButtonView.ButtonClickedEvent -= OnButtonClick;
            isSubscribe = false;
        }

        private void Initialize()
        {
            updateView.ButtonSetActive(true);
            updateView.TimerSetActive(false);
            updateView.SliderSetActive(false);
            updateView.InitializedTimeNotAvailableBehaviourEvent?.Invoke();
        }
        private void OnButtonClick(Slime _)
        {
            ChangeBehaviour();
        }

        private void ChangeBehaviour()
        {
            updateView.UpdateViewBehaviour.SetBehaviourByDefault();
        }
    }
}
