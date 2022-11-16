using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GenResHolder", menuName = "Slime/Genome/ResHolder")]
public class GenomeResourcesHolder : ScriptableObject
{
    [SerializeField] private GenomeResources[] genomResources;

    public GenomeResources[] GenomResources => genomResources;

    private void Awake()
    {
        List<Genome.Genes> typeGenes = new();
        foreach (GenomeResources gr in genomResources)
        {
            if (typeGenes.Contains(gr.TypeArray))
                throw new Exception("Type is double");
            typeGenes.Add(gr.TypeArray);
            Debug.Log("asdf");
        }
    }
}
