using System;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GenomeResources", menuName = "Slime/Genome/Resources")]
public class GenomeResources : ScriptableObject
{
    [SerializeField] private Genome.Genes typeArray;
    [SerializeField] private GenomeSprite[] genomeSprites;

    public GenomeSprite[] GenomeSprites => genomeSprites;
    public Genome.Genes TypeArray => typeArray;

    
    private void AttrubuteTypeCheck()
    {
        foreach(GenomeSprite genomeSprite in genomeSprites)
        {
            if (typeArray != genomeSprite.Genes)
                throw new Exception("Data types do not match");
        }
    }

    private void AttributeIDCheck()
    {
        List<int> ids = new();
        foreach (GenomeSprite genomeSprite in genomeSprites)
        {
            if (ids.Contains(genomeSprite.Id))
                throw new Exception("Attribute id matches");
            ids.Add(genomeSprite.Id);
        }
    }
    
    private void Awake()
    {
        Debug.Log($"awake {typeArray}");
        AttrubuteTypeCheck();
        AttributeIDCheck();
    }
}
