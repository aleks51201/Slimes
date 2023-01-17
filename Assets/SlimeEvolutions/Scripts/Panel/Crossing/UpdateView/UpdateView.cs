using SlimeEvolutions.Architecture.CrossData;
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Buttons;
using SlimeEvolutions.Panel.Crossing.Update.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeEvolutions.Panel.Crossing.Update
{
    public class UpdateView: IActivatable
    {
        private UpdateViewBehaviour updateViewBehaviour;
        private CrossingSpaceData crossingSpaceData;
        private ButtonWithClick button;
        private Slider slider;
        private GameObject timer, activeLayer;


        public CrossingSpaceData CrossingSpaceData => crossingSpaceData;
        public UpdateViewBehaviour UpdateViewBehaviour => updateViewBehaviour;


        public UpdateView(ButtonWithClick button, Slider slider, GameObject timer, GameObject activeLayer)
        {
            this.button = button;
            this.slider = slider;
            this.timer = timer;
            this.activeLayer = activeLayer;
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
            button.gameObject.SetActive(isActive);
        }

        public void ActiveLayerSetActive(bool isActive)
        {
            activeLayer.SetActive(isActive);
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
