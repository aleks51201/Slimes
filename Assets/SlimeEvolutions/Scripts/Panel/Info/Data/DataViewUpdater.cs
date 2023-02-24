using System;
using System.Collections.Generic;
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
                    UpdateView(slime.Genome.GetGene<Eyes>().GetName(slime.Genome.Eyes.Id));
                    break;
                case Genome.Genes.Mouth:
                    UpdateView(slime.Genome.GetGene<Mouth>().GetName(slime.Genome.Mouth.Id));
                    break;
                case Genome.Genes.SlimeForm:
                    UpdateView(slime.Genome.GetGene<SlimeForm>().GetName(slime.Genome.Form.Id));
                    break;
                case Genome.Genes.Top:
                    UpdateView(slime.Genome.GetGene<Top>().GetName(slime.Genome.Top.Id));
                    break;
                case Genome.Genes.Middle:
                    UpdateView(slime.Genome.GetGene<Middle>().GetName(slime.Genome.Middle.Id));
                    break;
                case Genome.Genes.Bottom:
                    UpdateView(slime.Genome.GetGene<Bottom>().GetName(slime.Genome.Bottom.Id));
                    break;
                case Genome.Genes.Element:
                    UpdateView(slime.Genome.GetGene<Element>().GetName(slime.Genome.Element.Id));
                    break;
                case Genome.Genes.Peculiarity:
                    UpdateView(slime.Genome.GetGene<Peculiarity>().GetName(slime.Genome.Peculiarity.Id));
                    break;
                default:
                    throw new ArgumentOutOfRangeException("this type does not exist");
            }
                
        }

        private void OnDisable()
        {
            
        }
    }
}
