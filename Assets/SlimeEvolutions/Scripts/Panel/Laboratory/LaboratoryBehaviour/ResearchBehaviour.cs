using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;

namespace SlimeEvolutions.Panel.Laboratory.Behaviours
{
    public class ResearchBehaviour : ILaboratoryBehaviour
    {
        private LaboratoryLogic labLogic;
        private bool isSubscribe;

        public void Enter(LaboratoryLogic laboratoryLogic)
        {
            labLogic = laboratoryLogic;
            Subscribe();
            ResearchSpaceUpdate();
            TimerStart();
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

        private void TimerStart()
        {
            labLogic.StartTimer(ChangeBehaviour);
        }

        public void ChangeBehaviour()
        {
            labLogic.LaboratoryBehaviour.SetAfterResearchBehaviour();
        }
        
        private void ResearchSpaceUpdate()
        {
            Slime researchingSlime = Game.GetInteractor<LaboratoryDataInteractor>().ResearchableSlime;
            labLogic.ResearchPlaceView.ResearchSpaceUpdate(this, researchingSlime);
        }

    }
}
