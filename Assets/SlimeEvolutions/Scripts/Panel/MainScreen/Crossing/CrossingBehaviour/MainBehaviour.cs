﻿using SlimeEvolutions.Inventory;
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
        }

        private void Subscribe()
        {
            if (isSubscribe)
            {
                return;
            }
            InventoryButtonLogic.OnInventoryButtonClickEvent += CrossingSpaceUpdate;
            ResearchButtonView.OnButtonClickEvent += crossLogic.SaveData;
            ResearchButtonView.OnButtonClickEvent += AddCrossoverToList;
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
            ResearchButtonView.OnButtonClickEvent -= crossLogic.SaveData;
            ResearchButtonView.OnButtonClickEvent -= AddCrossoverToList;
            ResearchPlaceButtonView.OnButtonWithSlimeClickEvent -= crossLogic.ClearSpace;
            isSubscribe = false;
        }

        private void CrossingSpaceUpdate(Slime slime)
        {
            //if (slime.IsExplored)
            crossLogic.UpdateSlots(slime);
        }

        private void AddCrossoverToList()
        {
            /*            var crossInt = Game.GetInteractor<CrossingSpaceInteractor>();
                        Slime lSlime = crossLogic.LSlime;
                        Slime rSlime = crossLogic.RSlime;
                        var crossingSpaceData = new CrossingSpaceData(lSlime, rSlime, DateTime.Now, DateTime.Now.AddMinutes(1));
                        if (crossInt.AreThereAnySlotsAvailable())
                        {
                            int id = crossInt.GetEmptySlotId();
                            crossInt.SetCrossingSpaceData(id,crossingSpaceData);
                        }
            */
        }
    }
}