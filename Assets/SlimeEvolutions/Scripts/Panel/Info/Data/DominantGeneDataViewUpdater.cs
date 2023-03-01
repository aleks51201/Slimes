using System;
using TMPro;
using UnityEngine;

namespace SlimeEvolutions.Panel.Info.Data
{
    public class DominantGeneDataViewUpdater : MonoBehaviour
    {
        [SerializeField] private Genome.Genes gene;
        [SerializeField] private string stringIfDoninant;
        [SerializeField] private string stringIfNotDoninant;

        private TextMeshProUGUI text;
        private Slime slime;


        public void UpdateView(string text)
        {
            this.text.text = text;
        }

        private void UpdateInfo()
        {
            slime = GetComponentInParent<InfoPanelView>().Slime;
        }

        private void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            UpdateInfo();
            if (!slime.IsExplored)
            {
                UpdateView("?");
                return;
            }
            switch (gene)
            {
                case Genome.Genes.Eyes:
                    UpdateView(slime.Genome.GetGene<Eyes>().IsDominant ? stringIfDoninant : stringIfNotDoninant);
                    break;
                case Genome.Genes.Mouth:
                    UpdateView(slime.Genome.GetGene<Mouth>().IsDominant ? stringIfDoninant : stringIfNotDoninant);
                    break;
                case Genome.Genes.SlimeForm:
                    UpdateView(slime.Genome.GetGene<SlimeForm>().IsDominant ? stringIfDoninant : stringIfNotDoninant);
                    break;
                case Genome.Genes.Top:
                    UpdateView(slime.Genome.GetGene<Top>().IsDominant ? stringIfDoninant : stringIfNotDoninant);
                    break;
                case Genome.Genes.Middle:
                    UpdateView(slime.Genome.GetGene<Middle>().IsDominant ? stringIfDoninant : stringIfNotDoninant);
                    break;
                case Genome.Genes.Bottom:
                    UpdateView(slime.Genome.GetGene<Bottom>().IsDominant ? stringIfDoninant : stringIfNotDoninant);
                    break;
                case Genome.Genes.Element:
                    UpdateView(slime.Genome.GetGene<Element>().IsDominant ? stringIfDoninant : stringIfNotDoninant);
                    break;
                case Genome.Genes.Peculiarity:
                    UpdateView(slime.Genome.GetGene<Peculiarity>().IsDominant ? stringIfDoninant : stringIfNotDoninant);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("this type does not exist");
            }
        }
    }
}
