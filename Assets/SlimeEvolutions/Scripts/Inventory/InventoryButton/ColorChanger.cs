using SlimeEvolutions.Buttons;
using SlimeEvolutions.Inventory.Behaviour;
using SlimeEvolutions.Panel.Crossing;
using SlimeEvolutions.Panel.Laboratory;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeEvolutions.Inventory.InventoryButton
{
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField] private ButtonWithClickAndHold button;
        [SerializeField] private Color color;

        private PanelTypeIsActive panelIaActive;
        private bool isMarked;
        private Image img;
        private Slime slime;
        private Dictionary<Type, PanelTypeIsActive> keyValuePairs = new Dictionary<Type, PanelTypeIsActive>()
        {
            [typeof(MainBehaviour)] = PanelTypeIsActive.Main,
            [typeof(MutatronBehaviour)] = PanelTypeIsActive.Mutatron,
            [typeof(LaboratoryBehaviour)] = PanelTypeIsActive.Laboratory
        };


        public Type CurrentBehaviour { get; set; }
        public ResearchPlaceView LeftObjectOnMainCross { get; set; }
        public ResearchPlaceView RightObjectOnMainCross { get; set; }

        private Slime LeftSlimesOnMainCross => LeftObjectOnMainCross.Slime;
        private Slime RightSlimesOnMainCross => RightObjectOnMainCross.Slime;


        private Image Img
        {
            get
            {
                if (img is null)
                {
                    img = GetComponent<Image>();
                }
                return img;
            }
        }
        private Slime Slime
        {
            get
            {
                if (slime is null)
                {
                    slime = GetComponent<SlimeGetter>().GetSlime();
                }
                return slime;
            }
        }


        private enum PanelTypeIsActive
        {
            Mutatron,
            Main,
            Laboratory
        }


        private void OnMutatronEntered()
        {
            panelIaActive = PanelTypeIsActive.Mutatron;
            ClearColour();
        }

        private void OnMainEntered()
        {
            panelIaActive = PanelTypeIsActive.Main;
            ClearColour();
        }

        private void OnLaboratoryEntered()
        {
            panelIaActive = PanelTypeIsActive.Laboratory;
            ClearColour();
        }

        private void OnInventoryButtonClicked(Slime slime)
        {
            if (panelIaActive == PanelTypeIsActive.Laboratory)
            {
                if (isMarked && slime.Id != Slime.Id && !slime.IsExplored)
                {
                    ClearColour();
                }
            }
        }

        private void OnSlotsUpdated()
        {
            if (panelIaActive == PanelTypeIsActive.Main)
            {
                if (isMarked)
                {
                    if (LeftSlimesOnMainCross is null || RightSlimesOnMainCross is null)
                    {
                        return;
                    }
                    if (Slime.Id != LeftSlimesOnMainCross.Id && Slime.Id != RightSlimesOnMainCross.Id)
                    {
                        ClearColour();
                        return;
                    }
                    return;
                }
            }
        }

        private void OnButonClicked()
        {
            if (panelIaActive == PanelTypeIsActive.Mutatron)
            {
                if (isMarked)
                {
                    ClearColour();
                    return;
                }
                ApplyColour();
            }
            else if (panelIaActive == PanelTypeIsActive.Main)
            {
                if (isMarked)
                {
                    return;
                }
                ApplyColour();
            }
            else if (panelIaActive == PanelTypeIsActive.Laboratory)
            {
                if (isMarked || Slime.IsExplored)
                {
                    return;
                }
                ApplyColour();
            }
        }

        private void ApplyColour()
        {
            Img.color = color;
            isMarked = true;
        }

        private void OnResearchBtnClicked(Slime slime)
        {
            if (slime.Id == Slime.Id)
            {
                ClearColour();
            }
        }

        private void ClearColour()
        {
            Img.color = Color.white;
            isMarked = false;
        }

        private void Start()
        {
            panelIaActive = keyValuePairs[CurrentBehaviour];
        }

        private void OnEnable()
        {
            button.OnButtonClickEvent += OnButonClicked;
            SlimeGetter.ButtonClickedStaticEvent += OnInventoryButtonClicked;
            CrossPlaceLogic.SlotsUpdatedStaticEvent += OnSlotsUpdated;
            ResearchPlaceButtonView.OnButtonWithSlimeClickEvent += OnResearchBtnClicked;
            MutatronBehaviour.MutatronBehaviourEnteredEvent += OnMutatronEntered;
            MainBehaviour.MainBehaviourEnteredEvent += OnMainEntered;
            LaboratoryBehaviour.LaboratoryBehaviourEnteredEvent += OnLaboratoryEntered;
        }

        private void OnDisable()
        {
            button.OnButtonClickEvent -= OnButonClicked;
            SlimeGetter.ButtonClickedStaticEvent -= OnInventoryButtonClicked;
            CrossPlaceLogic.SlotsUpdatedStaticEvent -= OnSlotsUpdated;
            ResearchPlaceButtonView.OnButtonWithSlimeClickEvent -= OnResearchBtnClicked;
            MutatronBehaviour.MutatronBehaviourEnteredEvent -= OnMutatronEntered;
            MainBehaviour.MainBehaviourEnteredEvent -= OnMainEntered;
            LaboratoryBehaviour.LaboratoryBehaviourEnteredEvent -= OnLaboratoryEntered;
        }
    }
}
