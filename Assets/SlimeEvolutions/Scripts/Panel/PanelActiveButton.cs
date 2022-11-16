using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class PanelActiveButton : MonoBehaviour
    {
        [SerializeField] GameObject currentPanel;

        public void ActivationPanel()
        {
            currentPanel.SetActive(true);
        }
    }
}
