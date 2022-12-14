using SlimeEvolutions.InventoryCell;
using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Gene
{
    private protected int id;
    private protected GenomeResources genomResources;

    public int Id
    {
        get => id;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Value can't be less than zero");
            }
            id = value;
        }
    }
    public bool IsDominant { get; set; }
    
    public void RandomGenerate()
    {
        id = RandomNumber(genomResources.GenomeSprites.Length);
        IsDominant = GetDominantProperty();
    }

    private protected int RandomNumber(int num)
    {
        System.Random rnd = new();
        return rnd.Next(num);
    }
    private protected bool GetDominantProperty()
    {
        return genomResources.GenomeSprites[id].IsDominant;
    }

    private protected CellView GetCellView(GameObject gameObject)
    {
        return gameObject.GetComponentInParent<CellView>();
    }

    public Sprite GetSprite(GameObject cellGameObject, int id)
    {
        return genomResources.GenomeSprites[id].Spr;
    }

    public void SetSpite(GameObject cellGameObject, Sprite sprite)
    {
        cellGameObject.GetComponent<Image>().sprite = sprite;
    }
}
