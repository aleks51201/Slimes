using SlimeEvolutions.Buttons;
using SlimeEvolutions.Inventory.Behaviour;
using SlimeEvolutions.Panel.Laboratory;
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


        private enum PanelTypeIsActive
        {
            Mutatron,
            Main
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

        private void OnButonClicked()
        {
            if (panelIaActive == PanelTypeIsActive.Mutatron)
            {
                if (isMarked)
                {
                    ClearColour();
                    return;
                }
                Img.color = color;
                isMarked = true;
            }
            else
            {
                if (isMarked)
                {
                    return;
                }
                Img.color = color;
                isMarked = true;
            }
        }

        private void OnResearchBtnClicked()
        {
            if(panelIaActive == PanelTypeIsActive.Main)
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
            panelIaActive = PanelTypeIsActive.Main;
        }

        private void OnEnable()
        {
            button.OnButtonClickEvent += OnButonClicked;
            ResearchPlaceButtonView.OnButtonClickEvent += OnResearchBtnClicked;
            MutatronBehaviour.MutatronBehaviourEnteredEvent += OnMutatronEntered;
            MainBehaviour.MainBehaviourEnteredEvent += OnMainEntered;
        }

        private void OnDisable()
        {
            button.OnButtonClickEvent -= OnButonClicked;
            ResearchPlaceButtonView.OnButtonClickEvent -= OnResearchBtnClicked;
            MutatronBehaviour.MutatronBehaviourEnteredEvent -= OnMutatronEntered;
            MainBehaviour.MainBehaviourEnteredEvent -= OnMainEntered;
        }
    }
}
