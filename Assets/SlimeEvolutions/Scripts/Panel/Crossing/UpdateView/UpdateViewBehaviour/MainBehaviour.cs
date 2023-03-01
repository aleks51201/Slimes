using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Stuff;
using UnityEngine;

namespace SlimeEvolutions.Panel.Crossing.Update.Behaviours
{
    public class MainBehaviour : IUpdateViewBehaviour
    {
        private UpdateView updateView;
        private bool isSubscribe;


        private bool IsDataOk =>
            updateView is not null && !updateView.CrossingSpaceData.HasBeenSlimeTaken;
        private bool IslvlOk => updateView.LvlForOpen <= ProgressionCalculator.CalcTotalLvlForExp(Game.GetInteractor<ExperienceInteractor>().Experience, 50);
        private UpdateViewBehaviour UpdateViewBehaviour => updateView.UpdateViewBehaviour;


        public void Enter(UpdateView updateView)
        {
            this.updateView = updateView;
            CleanCell();
            Subscribe();
            Debug.Log("MainBehaviour enter");
            ChangeBehaviour();
        }

        public void Exit()
        {
            Unsubscribe();
        }

        public void OnEnable()
        {
            CleanCell();
            Subscribe();
            Debug.Log("MainBehaviour enable");
            ChangeBehaviour();
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
            if (IslvlOk)
            {
                UpdateViewBehaviour.SetIncorrectInformationBehaviour();
                return;
            }
            UpdateViewBehaviour.SetInsufficientLevelBehaviour();
        }

        private void CleanCell()
        {
            updateView.CleanCell();
        }
    }
}
