using System;
using UnityEngine;

namespace Assets.SlimeEvolutions.Prefab.Slimes.Gemom.Scripts
{
    public class GeneView : MonoBehaviour
    {
        [SerializeField] private Genome.Genes geneType;
        [SerializeField] private GenomeResources imageData;

        private int id;

        private void Start()
        {
            if (imageData.TypeArray != geneType)
            {
                throw new Exception($"{imageData.TypeArray} type does not match type {geneType}");
            }
            id = gameObject.GetComponentInParent<Slime>().Id;
        }
    }
}
