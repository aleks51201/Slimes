using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SlimeEvolutions.Panel.Crossing.Update.Behaviours
{
    class InsufficientLevelBehaviour: IUpdateViewBehaviour
    {
        private UpdateView updateView;
        private bool isSubscribe;

        public void Enter(UpdateView updateView)
        {
            this.updateView = updateView;
            CleanCell();
            Initialize();
            Subscribe();
            Debug.Log("InsufficientLevelBehaviour enter");
        }

        public void Exit()
        {
            Unsubscribe();
        }

        public void OnEnable()
        {
            ChangeBehaviour();
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
            updateView.ButtonSetActive(false);
            updateView.TimerSetActive(false);
            updateView.SliderSetActive(false);
            updateView.ActiveLayerSetActive(false);
            updateView.BlockLayerSetActive(true);
        }

        private void ChangeBehaviour()
        {
            updateView.UpdateViewBehaviour.SetBehaviourByDefault();
        }

        private void CleanCell()
        {
            updateView.CleanCell();
        }
    }
}
