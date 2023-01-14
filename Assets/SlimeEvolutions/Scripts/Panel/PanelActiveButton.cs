using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class PanelActiveButton : MonoBehaviour
    {
        [SerializeField] GameObject[] activPanel;
        [SerializeField] GameObject[] deactivPanel;

        public void ActivationPanel()
        {
            foreach (var i in activPanel)
            {
                i.SetActive(true);
            }
        }

        public void Deactivate()
        {
            foreach (var i in deactivPanel)
            {
                i.SetActive(false);
            }
        }
    }
}
