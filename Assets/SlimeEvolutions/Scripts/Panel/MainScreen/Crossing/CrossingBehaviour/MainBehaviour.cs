using SlimeEvolutions.Inventory.InventoryButton;
using SlimeEvolutions.Panel.Laboratory;
using System;

namespace SlimeEvolutions.Panel.Crossing.Behaviour
{
    public class MainBehaviour : ICrossingBehaviour, IActivatable
    {
        private CrossPlaceLogic crossLogic;
        private bool isSubscribe;

        public static Action<Slime, Slime> OnCrossingButtonClickEvent;

        public void Enter(CrossPlaceLogic CrossLogic)
        {
            this.crossLogic = CrossLogic;
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
            ClearSpace();
        }

        private void Subscribe()
        {
            if (isSubscribe)
            {
                return;
            }
            SlimeGetter.ButtonClickedStaticEvent += CrossingSpaceUpdate;
            ResearchButtonView.OnButtonClickEvent += crossLogic.SaveData;
            ResearchPlaceButtonView.OnButtonWithSlimeClickEvent += crossLogic.ClearSpace;
            isSubscribe = true;
        }

        private void Unsubscribe()
        {
            if (!isSubscribe)
            {
                return;
            }
            SlimeGetter.ButtonClickedStaticEvent -= CrossingSpaceUpdate;
            ResearchButtonView.OnButtonClickEvent -= crossLogic.SaveData;
            ResearchPlaceButtonView.OnButtonWithSlimeClickEvent -= crossLogic.ClearSpace;
            isSubscribe = false;
        }

        private void CrossingSpaceUpdate(Slime slime)
        {
            crossLogic.UpdateSlots(slime);
        }

        private void ClearSpace()
        {
            crossLogic.ClearSpace();
        }

    }
}
