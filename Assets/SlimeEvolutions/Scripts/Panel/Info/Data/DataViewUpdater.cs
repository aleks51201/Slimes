using TMPro;
using UnityEngine;

namespace SlimeEvolutions.Panel.Info.Data
{
    public class DataViewUpdater : MonoBehaviour
    {
        [SerializeField] private Genome.Genes gene;

        private TextMeshProUGUI text;
        private Slime slime;


        public void UpdateView(string text)
        {
            this.text.text = text ;
        }

        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
            slime = GetComponentInParent<InfoPanelView>().Slime;
            slime = new();
        }

        private void OnEnable()
        {
            UpdateView(slime.Genome.GetGene<Gene>().GetName(slime.Genome.GetGene<Gene>().Id));
        }

        private void OnDisable()
        {
            
        }
    }
}
