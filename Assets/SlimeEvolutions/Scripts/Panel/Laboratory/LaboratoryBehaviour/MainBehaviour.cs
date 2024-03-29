﻿
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Inventory.InventoryButton;

namespace SlimeEvolutions.Panel.Laboratory.Behaviours
{
    public class MainBehaviour : ILaboratoryBehaviour
    {
        private LaboratoryLogic labLogic;
        private bool isSubscribe;

        private bool IsResearchState =>
            !Game.GetInteractor<LaboratoryDataInteractor>().IsResearchEnd;
        private bool IsAfterResearchState =>
            !Game.GetInteractor<LaboratoryDataInteractor>().HasBeenSlimeTaken;

        public void Enter(LaboratoryLogic laboratoryLogic)
        {
            labLogic = laboratoryLogic;
            Subscribe();
            ResearchSpaceClear();
            UpdateTextOnButton();
            ChangeBehaviour();
        }

        public void Exit()
        {
            Unsubscribe();
        }

        public void OnEnable()
        {
            Subscribe();
            ResearchSpaceClear();
            UpdateTextOnButton();
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
            ResearchButtonView.OnButtonClickEvent += StartResearch;
            SlimeGetter.ButtonClickedStaticEvent += OnButtonClicked;
            ResearchPlaceButtonView.OnButtonClickEvent +=ResearchSpaceClear;
            //InventoryButtonLogic.OnInventoryButtonClickEvent += ResearchSpaceUpdate;
            isSubscribe = true;
        }

        private void Unsubscribe()
        {
            if (!isSubscribe)
            {
                return;
            }
            ResearchButtonView.OnButtonClickEvent -= StartResearch;
            SlimeGetter.ButtonClickedStaticEvent -= OnButtonClicked;
            ResearchPlaceButtonView.OnButtonClickEvent -=ResearchSpaceClear;
            //InventoryButtonLogic.OnInventoryButtonClickEvent -= ResearchSpaceUpdate;
            isSubscribe = false;
        }

        private void OnButtonClicked(Slime slime)
        {
            if (slime.IsExplored)
            {
                return;
            }
            ResearchSpaceUpdate(slime);
            TextUpdate();
        }

        private void ResearchSpaceUpdate(Slime slime)
        {
            if (!slime.IsExplored)
                labLogic.ResearchPlaceView.ResearchSpaceUpdate(this, slime);
        }

        private void TextUpdate()
        {
            labLogic.UpdateTextOnButton($"{labLogic.CalcMutagenCost()}");
        }

        private void ChangeBehaviour()
        {
            if (IsResearchState)
            {
                SetResearchBehaviour();
            }
            if (!IsResearchState && IsAfterResearchState)
            {
                SetAfterResearchBehaviour();
            }
        }

        private void SetResearchBehaviour()
        {
            labLogic.LaboratoryBehaviour.SetResearchBehaviour();
        }

        private void SetAfterResearchBehaviour()
        {
            labLogic.LaboratoryBehaviour.SetAfterResearchBehaviour();
        }

        private void StartResearch()
        {
            labLogic.StartResearch();
            SetResearchBehaviour();
        }

        private void ResearchSpaceClear()
        {
            Slime researchingSlime = Game.GetInteractor<LaboratoryDataInteractor>().ResearchableSlime;
            //labLogic.ResearchPlaceView.ResearchSpaceUpdate(researchingSlime);
            labLogic.ResearchPlaceView.ClearSpace();
        }

        private void UpdateTextOnButton()
        {
            labLogic.UpdateTextOnButton(labLogic.LaboratoryView.BeforeResearch);
        }
    }
}
