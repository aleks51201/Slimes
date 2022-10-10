using UnityEngine;

[CreateAssetMenu(fileName = "GenomeSprite", menuName = "Slime/Genome/Sprite")]
public class GenomeSprite : ScriptableObject
{
    [SerializeField] private Sprite[] sprites;

    public Sprite[] GenomeSprites => sprites;
}
