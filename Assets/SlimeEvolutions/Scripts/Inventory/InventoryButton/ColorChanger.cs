using SlimeEvolutions.Buttons;
using SlimeEvolutions.Inventory.Behaviour;
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
        }

        private void ChangeBGColour()
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
        }

        private void ClearColour()
        {
            Img.color = Color.white;
            isMarked = false;
        }

        private void OnEnable()
        {
            button.OnButtonClickEvent += ChangeBGColour;
            MutatronBehaviour.MutatronBehaviourEnteredEvent += OnMutatronEntered;
        }

        private void OnDisable()
        {
            button.OnButtonClickEvent -= ChangeBGColour;
            MutatronBehaviour.MutatronBehaviourEnteredEvent -= OnMutatronEntered;

        }
    }
}
