using UnityEngine;

namespace SlimeEvolutions.Panel.Info
{
    public class InfoPanelManger : MonoBehaviour
    {
        private InfoPanelView infoPanel;




        private void SetActiveInfoPanel(Slime slime)
        {
            infoPanel.Slime = slime;
            infoPanel.gameObject.SetActive(true);
        }

        private void Awake()
        {
            infoPanel = GetComponentInChildren<InfoPanelView>();
        }

        private void OnEnable()
        {

        }

        private void OnDisable()
        {

        }
    }
}
