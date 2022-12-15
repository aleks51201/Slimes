using SlimeEvolutions.Architecture;
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Panel.Crossing.Behaviour;
using SlimeEvolutions.Panel.MainScreen.Stuff;
using System;
using System.Collections;
using static SlimeEvolutions.Panel.LaboratoryLogic;

namespace SlimeEvolutions.Panel.Crossing
{
    public class CrossPlaceLogic : IActivatable
    {

        private CrossPlaceView crossPlaceView;
        private CrossingBehaviour crossingBehaviour;
        private bool isLeft = true;

        private Slime LSlime => crossPlaceView.LeftCrossSlimePositionView.Slime;
        private Slime RSlime => crossPlaceView.RightCrossSlimePositionView.Slime;


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
        }

        private void LeftSpaceUpdate(Slime slime)
        {
            crossPlaceView.LeftCrossSlimePositionView.ResearchSpaceUpdate(this, slime);
        }

        private void RightSpaceUpdate(Slime slime)
        {
            crossPlaceView.RightCrossSlimePositionView.ResearchSpaceUpdate(this, slime);
        }

        private bool IsSlimesAreEqual(Slime slime1, Slime slime2 = null)
        {
            if (slime2 is null)
            {
                return false;
            }
            return slime1.Id == slime2.Id;
        }

        public void Crossing()
        {
            if (LSlime is null || RSlime is null)
            {
                return;
            }
            Cross cross = new(LSlime, RSlime);
            Slime newSlime = cross.Crossing();
            SlimesInventory.AddSlime(this, newSlime);
        }

        public void StartCrossing()
        {
        }

        private void StartTimerAsync(AnyActionDelegate anyAction)
        {
            Coroutines.StartRoutine(TimerRoutine(anyAction));
        }

        private IEnumerator TimerRoutine(AnyActionDelegate anyAction)
        {
            DateTime dateTime = DateTime.Now.AddMinutes(0.5);
            while (DateTime.Now < dateTime)
            {
                yield return null;
            }
            anyAction();
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