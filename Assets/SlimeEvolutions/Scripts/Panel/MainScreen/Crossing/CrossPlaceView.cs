﻿using SlimeEvolutions.Panel.Laboratory;
using UnityEngine;

namespace SlimeEvolutions.Panel.Crossing
{
    public class CrossPlaceView : MonoBehaviour
    {
        [SerializeField] private ResearchButtonView researchButtonView;
        [SerializeField] private ResearchPlaceView leftCrossSlimePositionView;
        [SerializeField] private ResearchPlaceView rightCrossSlimePositionView;

        public ResearchPlaceView LeftCrossSlimePositionView => leftCrossSlimePositionView;
        public ResearchPlaceView RightCrossSlimePositionView => rightCrossSlimePositionView;


        private CrossPlaceLogic crossPlaceLogic;


        private void Awake()
        {
            crossPlaceLogic = new(this);
        }

        private void OnEnable()
        {
            crossPlaceLogic.OnEnable();
        }

        private void OnDisable()
        {
            crossPlaceLogic.OnDisable();
        }
    }
}
