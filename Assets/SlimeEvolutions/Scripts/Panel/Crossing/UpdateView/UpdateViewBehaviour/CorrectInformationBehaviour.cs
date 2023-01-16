namespace SlimeEvolutions.Panel.Crossing.Update.Behaviours
{
    public class CorrectInformationBehaviour : IUpdateViewBehaviour
    {
        private UpdateView updateView;
        private bool isSubscribe;

        public void Enter(UpdateView updateView)
        {
            this.updateView = updateView;
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

    }
}
