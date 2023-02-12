using SlimeEvolutions.Architecture.CrossData;
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Buttons;
using System;
using UnityEngine;

namespace SlimeEvolutions.Panel.Crossing.TakeButton
{
    public class TakeButtonView : MonoBehaviour
    {
        [SerializeField] private ButtonWithClick buttonWithClick;


        private int Id => GetComponentInParent<HoldCrossingPlaceView>().ID;
        private CrossingSpaceData crossingSpaceData => Game.GetInteractor<CrossingSpaceInteractor>().CrossingSpaces[Id];


        public static Action<Slime> ButtonClickedEvent;


        private void OnClick()
        {
            Slime slime = crossingSpaceData.ResultSlime;
            ButtonClickedEvent?.Invoke(slime);
        }

        private void Awake()
        {
        }

        private void OnEnable()
        {
            buttonWithClick.OnButtonClickEvent += OnClick;
        }

        private void OnDisable()
        {
            buttonWithClick.OnButtonClickEvent -= OnClick;
        }
    }
}
