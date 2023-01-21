using UnityEngine;

namespace SlimeEvolutions.Panel.Info
{
    public class InfoPanelManger : MonoBehaviour
    {
        private InfoPanelView infoPanel;





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
