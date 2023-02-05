using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.InventoryCell;
using SlimeEvolutions.Stuff;
using System;
using System.Collections.Generic;
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

    private int randomPart(int[] values, int[] weights)
    {
        int totalWeight = 0;
        foreach (int weight in weights)
        {
            totalWeight += weight;
        }
        var rnd = new System.Random();
        int rndNum = rnd.Next(totalWeight);
        for (int i = 0; i < values.Length; i++)
        {
            if (rndNum < weights[i])
            {
                return values[i];
            }
            rndNum -= weights[i];
        }
        throw new Exception("no num");
    }

    public void RandomGenerate()
    {
        List<int> idCollections = new();
        List<int> weightCollections = new();
        foreach (GenomeSprite genomeSprite in genomResources.GenomeSprites)
        {
            if (genomeSprite.LvlForDrop <= ProgressionCalculator.CalcTotalLvlForExp(Game.GetInteractor<ExperienceInteractor>().Experience, 50))
            {
                idCollections.Add(genomeSprite.Id);
                weightCollections.Add(genomeSprite.Weight);
            }
        }
        id = randomPart(idCollections.ToArray(), weightCollections.ToArray());
        //id = idCollections[RandomNumber(idCollections.Count)];
        IsDominant = RandomNumber(2) == 1;
    }

    private protected int RandomNumber(int num)
    {
        System.Random rnd = new();
        return rnd.Next(num);
    }

    private protected CellView GetCellView(GameObject gameObject)
    {
        return gameObject.GetComponentInParent<CellView>();
    }

    public Sprite GetSprite(GameObject cellGameObject, int id)
    {
        foreach (var i in genomResources.GenomeSprites)
        {
            if (i.Id == id)
            {
                return i.Spr;
            }
        }
        throw new ArgumentOutOfRangeException(" Missing slime's part");
        //return genomResources.GenomeSprites[id].Spr;
    }

    public void SetSprite(GameObject cellGameObject, Sprite sprite)
    {
        cellGameObject.GetComponent<Image>().sprite = sprite;
    }

    public string GetName(int id)
    {
        foreach (var i in genomResources.GenomeSprites)
        {
            if (i.Id == id)
            {
                return i.Name;
            }
        }
        throw new ArgumentOutOfRangeException(" Missing slime's part");
    }
}
