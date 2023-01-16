
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;

namespace SlimeEvolutions.Panel.Crossing.Update.Behaviours
{
    public class MainBehaviour : IUpdateViewBehaviour
    {
        private LaboratoryLogic labLogic;
        private bool isSubscribe;

        private bool IsResearchState =>
            !Game.GetInteractor<LaboratoryDataInteractor>().IsResearchEnd;
        private bool IsAfterResearchState =>
            !Game.GetInteractor<LaboratoryDataInteractor>().HasBeenSlimeTaken;

        public void Enter(LaboratoryLogic laboratoryLogic)
        {
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

        private void ResearchSpaceUpdate(Slime slime)
        {
            if (!slime.IsExplored)
                labLogic.ResearchPlaceView.ResearchSpaceUpdate(this, slime);
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

        private void ChangeBehaviour()
        {
        }
    }
}
