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
                default:
                    throw new ArgumentOutOfRangeException("this type does not exist");
            }
                
        }

        private void OnDisable()
        {
            
        }
    }
}
