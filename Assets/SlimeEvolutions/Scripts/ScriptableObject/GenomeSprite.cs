using UnityEngine;

[CreateAssetMenu(fileName = "GenomeSprite", menuName = "Slime/Genome/Sprite")]
public class GenomeSprite : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private Genome.Genes genes;
    [SerializeField] private Sprite spr;
    [SerializeField] private string name;

    public int Id => id;
    public Genome.Genes Genes => genes;
    public Sprite Spr => spr;
    public string Name => name;
}

