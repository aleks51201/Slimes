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
            if(labLogic.Timer is not null)
            {
                labLogic.Timer.OnTimerFinishedEvent -= ChangeBehaviour; 
                labLogic.Timer.OnTimerFinishedEvent -= labLogic.EndResearch;
                labLogic.Timer.OnTimerValueChangedEvent -= labLogic.UpdateTimerText;
            }
            isSubscribe = false;
        }

        private void TimerStart()
        {
            labLogic.StartTimer((float)labLogic.Seconds);
            labLogic.Timer.OnTimerFinishedEvent += ChangeBehaviour;
            labLogic.Timer.OnTimerFinishedEvent += labLogic.EndResearch;
            labLogic.Timer.OnTimerValueChangedEvent += labLogic.UpdateTimerText;
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
