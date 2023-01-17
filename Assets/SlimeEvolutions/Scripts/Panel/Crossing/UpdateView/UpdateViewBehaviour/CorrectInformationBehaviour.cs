using System;

namespace SlimeEvolutions.Panel.Crossing.Update.Behaviours
{
    public class CorrectInformationBehaviour : IUpdateViewBehaviour
    {
        private UpdateView updateView;
        private bool isSubscribe;


        private bool IsTimeAvailable =>
            DateTime.Now < updateView.CrossingSpaceData.EndTimeCrossing;
        private UpdateViewBehaviour UpdateViewBehaviour => updateView.UpdateViewBehaviour;

        
        public void Enter(UpdateView updateView)
        {
            this.updateView = updateView;
            Subscribe();
            Initialize();
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

        private void Initialize()
        {
            updateView.FillingCellData();
            updateView.ActiveLayerSetActive(true);
        }

        private void ChangeBehaviour()
        {
            if (IsTimeAvailable)
            {
                UpdateViewBehaviour.SetTimeAvailableBehaviour();
                return;
            }
            UpdateViewBehaviour.SetTimeIsNotAvailableBehaviour();
        }
    }
}
