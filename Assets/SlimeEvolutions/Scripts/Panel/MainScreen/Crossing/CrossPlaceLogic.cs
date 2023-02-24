using SlimeEvolutions.Architecture.CrossData;
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Panel.Crossing.Behaviour;
using SlimeEvolutions.Panel.MainScreen.Stuff;
using System;

namespace SlimeEvolutions.Panel.Crossing
{
    public class CrossPlaceLogic : IActivatable
    {

        private CrossPlaceView crossPlaceView;
        private CrossingBehaviour crossingBehaviour;
        private bool isLeft = true;

        public Slime LSlime => crossPlaceView.LeftCrossSlimePositionView.Slime;
        public Slime RSlime => crossPlaceView.RightCrossSlimePositionView.Slime;


        public static Action SlotsUpdatedStaticEvent;


        public CrossPlaceLogic(CrossPlaceView crossPlaceView)
        {
            this.crossPlaceView = crossPlaceView;
            crossingBehaviour = new(this);
        }


        public void UpdateSlots(Slime slime)
        {
            if (isLeft && !IsSlimesAreEqual(slime, LSlime) && !IsSlimesAreEqual(slime, RSlime))
            {
                LeftSpaceUpdate(slime);
                isLeft = false;
            }
            else if (!isLeft && !IsSlimesAreEqual(slime, LSlime) && !IsSlimesAreEqual(slime, RSlime))
            {
                RightSpaceUpdate(slime);
                isLeft = true;
            }
            SlotsUpdatedStaticEvent?.Invoke();
        }

        private void LeftSpaceUpdate(Slime slime)
        {
            crossPlaceView.LeftCrossSlimePositionView.ResearchSpaceUpdate(this, slime);
        }

        private void RightSpaceUpdate(Slime slime)
        {
            crossPlaceView.RightCrossSlimePositionView.ResearchSpaceUpdate(this, slime);
        }

        public void ClearSpace(Slime slime)
        {
            if (IsSlimesAreEqual(slime, LSlime))
            {
                LeftSpaceClear();
                isLeft = true;
            }
            else if (IsSlimesAreEqual(slime, RSlime))
            {
                RightSpaceClear();
                isLeft = false;
            }
        }

        public void ClearSpace()
        {
            crossPlaceView.LeftCrossSlimePositionView.ClearSpace();
            crossPlaceView.RightCrossSlimePositionView.ClearSpace();
        }

        private void LeftSpaceClear()
        {
            crossPlaceView.LeftCrossSlimePositionView.ClearSpace();
        }

        private void RightSpaceClear()
        {
            crossPlaceView.RightCrossSlimePositionView.ClearSpace();
        }

        private bool IsSlimesAreEqual(Slime slime1, Slime slime2 = null)
        {
            if (slime2 is null)
            {
                return false;
            }
            return slime1.Id == slime2.Id;
        }

        public void SaveData()
        {
            if (LSlime is null || RSlime is null)
            {
                return;
            }
            Cross cross = new(LSlime, RSlime);
            Slime newSlime = cross.Crossing();
            var interact = Game.GetInteractor<CrossingSpaceInteractor>();
            if (interact.AreThereAnySlotsAvailable())
            {
                int sec = ((LSlime.Lvl * RSlime.Lvl) / 2) * 10;
                var i = new CrossingSpaceData(LSlime, RSlime, newSlime, DateTime.Now, DateTime.Now.AddSeconds(sec));
                DeleteSlimeFromInventory(LSlime);
                DeleteSlimeFromInventory(RSlime);
                interact.SetCrossingSpaceData(interact.GetEmptySlotId(), i);
            }
        }

        private void DeleteSlimeFromInventory(Slime slime)
        {
            SlimesInventory.RemoveSlime(this, slime);
            ClearSpace(slime);
        }

        public void OnEnable()
        {
            crossingBehaviour.OnEnable();
        }

        public void OnDisable()
        {
            crossingBehaviour.OnDisable();
        }
    }
}