﻿using System;

namespace SlimeEvolutions.Panel.Crossing.Update.Behaviours
{
    public class MainBehaviour : IUpdateViewBehaviour
    {
        private UpdateView updateView;
        private bool isSubscribe;


        private bool IsDataOk =>
            updateView is not null || updateView.CrossingSpaceData.HasBeenSlimeTaken;
        private bool IsTimeAvailable =>
            DateTime.Now < updateView.CrossingSpaceData.EndTimeCrossing;
        private UpdateViewBehaviour UpdateViewBehaviour => updateView.UpdateViewBehaviour;


        public void Enter(UpdateView updateView)
        {
            this.updateView = updateView;
            Subscribe();
            ChangeBehaviour();
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

        private void ChangeBehaviour()
        {
            if (IsDataOk)
            {
                updateView.UpdateViewBehaviour.SetCorrectInformationBehaviour();
                return;
            }
            updateView.UpdateViewBehaviour.SetIncorrectInformationBehaviour();
        }
    }
}
