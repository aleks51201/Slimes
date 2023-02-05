using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;

namespace SlimeEvolutions.Panel.Laboratory.Behaviours
{
    public class AfterResearchBehaviour : ILaboratoryBehaviour
    {
        private LaboratoryLogic labLogic;
        private bool isSubscribe;

        public void Enter(LaboratoryLogic laboratoryLogic)
        {
            labLogic = laboratoryLogic;
            ResearchSpaceUpdate();
            UpdateTextOnButton();
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
            ResearchPlaceButtonView.OnButtonClickEvent += OnClick;
        }

        private void Unsubscribe()
        {
            if (!isSubscribe)
            {
                return;
            }
            isSubscribe = false;
            ResearchPlaceButtonView.OnButtonClickEvent -= OnClick;
        }

        private void OnClick()
        {
            LaboratoryDataInteractor labInteract = Game.GetInteractor<LaboratoryDataInteractor>();
            SlimesInventory.AddSlime(this, labInteract.ResearchableSlime);
            labLogic.SaveExpAfterResearch();
            labInteract.SetStatusTake(true);
            ClearResearchSpace();
            SetMainBehaviour();
        }

        private void SetMainBehaviour()
        {
            labLogic.LaboratoryBehaviour.SetMainBehaviour();
        }

        private void ClearResearchSpace()
        {
            labLogic.ResearchPlaceView.ClearSpace();
        }
        private void ResearchSpaceUpdate()
        {
            Slime researchingSlime = Game.GetInteractor<LaboratoryDataInteractor>().ResearchableSlime;
            labLogic.ResearchPlaceView.ResearchSpaceUpdate(this, researchingSlime);
        }

        private void UpdateTextOnButton()
        {
            labLogic.UpdateTextOnButton(labLogic.LaboratoryView.AfterResearch);
        }
    }
}
