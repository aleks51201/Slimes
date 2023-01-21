using TMPro;
using UnityEngine;

namespace SlimeEvolutions.Panel.Info.Data
{
    public class DataViewUpdater : MonoBehaviour
    {
        private TextMeshProUGUI text;


        public void UpdateView(string text)
        {
            this.text.text = text;
        }

        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
        }
    }
}
