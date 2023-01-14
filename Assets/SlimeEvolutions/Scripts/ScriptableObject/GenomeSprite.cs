using UnityEngine;

[CreateAssetMenu(fileName = "GenomeSprite", menuName = "Slime/Genome/Sprite")]
public class GenomeSprite : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private Genome.Genes genes;
    [SerializeField] private Sprite spr;

    public int Id => id;
    public Genome.Genes Genes => genes;
    public Sprite Spr => spr;
}

