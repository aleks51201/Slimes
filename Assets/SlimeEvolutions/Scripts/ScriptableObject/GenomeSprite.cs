using UnityEngine;

[CreateAssetMenu(fileName = "GenomeSprite", menuName = "Slime/Genome/Sprite")]
public class GenomeSprite : ScriptableObject
{
    public int id;
    public Genome.Genes genes;
    public Sprite spr;
    public string name;

    public int Id => id;
    public Genome.Genes Genes => genes;
    public Sprite Spr => spr;
    public string Name => name;
}

