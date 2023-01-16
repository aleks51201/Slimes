namespace SlimeEvolutions.Panel.Crossing.Update.Behaviours
{
    public class ThirdBehaviour : IUpdateViewBehaviour
    {
        private LaboratoryLogic labLogic;
        private bool isSubscribe;

        public void Enter(LaboratoryLogic laboratoryLogic)
        {
            labLogic = laboratoryLogic;
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
