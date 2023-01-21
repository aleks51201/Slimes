﻿using System;

namespace SlimeEvolutions.Panel.Crossing.Update.Behaviours
{
    public class MainBehaviour : IUpdateViewBehaviour
    {
        private UpdateView updateView;
        private bool isSubscribe;


        private bool IsDataOk =>
            updateView is not null && !updateView.CrossingSpaceData.HasBeenSlimeTaken;
        private UpdateViewBehaviour UpdateViewBehaviour => updateView.UpdateViewBehaviour;


        public void Enter(UpdateView updateView)
        {
            this.updateView = updateView;
            CleanCell();
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
                UpdateViewBehaviour.SetCorrectInformationBehaviour();
                return;
            }
            UpdateViewBehaviour.SetIncorrectInformationBehaviour();
        }

        private void CleanCell()
        {
            updateView.CleanCell();
        }
    }
}
