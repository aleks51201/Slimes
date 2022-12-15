using SlimeEvolutions.Inventory;
using SlimeEvolutions.Panel.Laboratory;

namespace SlimeEvolutions.Panel.Crossing.Behaviour
{
    public class MainBehaviour : ICrossingBehaviour, IActivatable
    {
        private CrossPlaceLogic crossLogic;
        private bool isSubscribe;

        private bool IsResearchState { get; set; }
        private bool IsAfterResearchState { get; set; }

        public void Enter(CrossPlaceLogic CrossLogic)
        {
            this.crossLogic = CrossLogic;
            Subscribe();
            //ResearchSpaceClear();
            //ChangeBehaviour();
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
            InventoryButtonLogic.OnInventoryButtonClickEvent += CrossingSpaceUpdate;
            ResearchButtonView.OnButtonClickEvent += crossLogic.Crossing;
            ResearchPlaceButtonView.OnButtonWithSlimeClickEvent += crossLogic.ClearSpace;
            isSubscribe = true;
        }

        private void Unsubscribe()
        {
            if (!isSubscribe)
            {
                return;
            }
            InventoryButtonLogic.OnInventoryButtonClickEvent -= CrossingSpaceUpdate;
            ResearchButtonView.OnButtonClickEvent -= crossLogic.Crossing;
            ResearchPlaceButtonView.OnButtonWithSlimeClickEvent -= crossLogic.ClearSpace;
            isSubscribe = false;
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

        private void CrossingSpaceUpdate(Slime slime)
        {
            if (slime.IsExplored)
                crossLogic.UpdateSlots(slime);
        }

        private void ResearchSpaceUpdate(Slime slime)
        {
            /*            if(!slime.IsExplored)
                            crossLogic.ResearchPlaceView.ResearchSpaceUpdate(this, slime);
            */
        }


        private void SetAfterResearchBehaviour()
        {
            /*            crossLogic.LaboratoryBehaviour.SetAfterResearchBehaviour();
            */
        }

        private void StartResearch()
        {
            /*            crossLogic.StartResearch();
                        SetResearchBehaviour();
            */
        }

        private void SetResearchBehaviour()
        {
            /*            crossLogic.LaboratoryBehaviour.SetResearchBehaviour();
            */
        }

        private void ResearchSpaceClear()
        {
            /*            Slime researchingSlime = Game.GetInteractor<LaboratoryDataInteractor>().ResearchableSlime;
                        //labLogic.ResearchPlaceView.ResearchSpaceUpdate(researchingSlime);
                        crossLogic.ResearchPlaceView.ClearSpace();
            */
        }

    }
}
