using SlimeEvolutions.Architecture.CrossData;
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Buttons;
using SlimeEvolutions.Panel.Crossing.Update.Behaviours;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeEvolutions.Panel.Crossing.Update
{
    public class UpdateView : IActivatable
    {
        private UpdateViewBehaviour updateViewBehaviour;
        private CrossingSpaceData crossingSpaceData;
        private ButtonWithClick takeButton;
        private ButtonMain lButton, rButton;
        private Slider slider;
        private GameObject timer, activeLayer, prefab;


        public CrossingSpaceData CrossingSpaceData => crossingSpaceData;
        public UpdateViewBehaviour UpdateViewBehaviour => updateViewBehaviour;


        public Action InitializedCorrectInformationBehaviourEvent;
        public Action InitializedIncorrectInformationBehaviourEvent;
        public Action InitializedTimeAvailableBehaviourEvent;
        public Action InitializedTimeNotAvailableBehaviourEvent;


        public UpdateView(GameObject cellPrefab, ButtonWithClick takeButton, ButtonMain lButton, ButtonMain rButton, Slider slider, GameObject timer, GameObject activeLayer)
        {
            this.takeButton = takeButton;
            this.slider = slider;
            this.timer = timer;
            this.activeLayer = activeLayer;
            this.lButton = lButton;
            this.rButton = rButton;
        }


        public void Initialize(int id)
        {
            crossingSpaceData = Game.GetInteractor<CrossingSpaceInteractor>().CrossingSpaces[id];
            updateViewBehaviour.SetBehaviourByDefault();
        }

        private void Upadate()
        {

        }

        public void TimerSetActive(bool isActive)
        {
            timer.SetActive(isActive);
        }

        public void SliderSetActive(bool isActive)
        {
            slider.gameObject.SetActive(isActive);
        }

        public void ButtonSetActive(bool isActive)
        {
            takeButton.gameObject.SetActive(isActive);
        }

        public void ActiveLayerSetActive(bool isActive)
        {
            activeLayer.SetActive(isActive);
        }

        public void FillingCellData()
        {
            var fillCell = new FillingCell(prefab);
            fillCell.AddCell(lButton, crossingSpaceData.LSlime);
            fillCell.AddCell(rButton, crossingSpaceData.RSlime);
        }

        public void OnEnable()
        {
            updateViewBehaviour.OnEnable();
        }

        public void OnDisable()
        {
            updateViewBehaviour.OnDisable();
        }
    }
}
