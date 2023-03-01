
using System;
using System.Collections.Generic;

public class Genome
{
    //public SlimeForm form;
    //public Colour colour;
    //public Mouth mouth;
    //public Eyes eyes;
    //public Element element;
    //public Peculiarity peculiarity;
    //public Top top;
    //public Middle middle;
    //public Bottom bottom;

    public SlimeForm Form
    {
        get
        {
            return GetGene<SlimeForm>();
        }
        set { }
    }
    public Mouth Mouth
    {
        get
        {
            return GetGene<Mouth>();
        }
        set { }
    }
    public Eyes Eyes
    {
        get
        {
            return GetGene<Eyes>();
        }
        set { }
    }
    public Bottom Bottom 
    {
        get
        {
            return GetGene<Bottom>();
        }
        set { }
    }
    public Element Element  
    {
        get
        {
            return GetGene<Element>();
        }
        set { }
    }
    public Middle Middle 
    {
        get
        {
            return GetGene<Middle>();
        }
        set { }
    }
    public Peculiarity Peculiarity
    {
        get
        {
            return GetGene<Peculiarity>();
        }
        set { }
    }
    public Top Top 
    {
        get
        {
            return GetGene<Top>();
        }
        set { }
    }


    private Dictionary<Type, Gene> genesMap;
    private int[] genesId;


    public Genome()
    {
        Initialize();
    }

    public Genome(int[] genesId)
    {
        Initialize();
        this.genesId = genesId;
        SetGenesId();
    }

    public enum Genes
    {
        SlimeForm = 1,
        Colour = 2,
        Mouth = 3,
        Eyes = 4,
        Element = 5,
        Peculiarity = 6,
        Top = 7,
        Middle = 8,
        Bottom = 9
    }

    private void Initialize()
    {
        genesMap = new();
        CreateNewGene<SlimeForm>(genesMap);
        CreateNewGene<Eyes>(genesMap);
        CreateNewGene<Mouth>(genesMap);
        CreateNewGene<Bottom>(genesMap);
        CreateNewGene<Element>(genesMap);
        CreateNewGene<Middle>(genesMap);
        CreateNewGene<Peculiarity>(genesMap);
        CreateNewGene<Top>(genesMap);
    }

    private void CreateNewGene<T>(Dictionary<Type, Gene> genesMap) where T : Gene, new()
    {
        genesMap[typeof(T)] = new T();
    }

    public T GetGene<T>() where T : Gene
    {
        return (T)genesMap[typeof(T)];
    }

    public void RandomGenome()
    {
        foreach (Gene gene in genesMap.Values)
        {
            gene.RandomGenerate();
        }
    }

    public bool[] GetArrayIsDominantGene()
    {
        var result = new bool[genesMap.Count];
        int i = 0;
        foreach (Gene gene in genesMap.Values)
        {
            result[i] = gene.IsDominant;
            i++;
        }
        return result;
    }

    private void SetGenesId()
    {
        System.Random rnd = new();
        int i = 0;
        foreach (Gene gene in genesMap.Values)
        {
            gene.Id = genesId[i];
            i++;
            gene.IsDominant = rnd.Next(2) == 1;
        }
    }

    public int[] GetGenesId()
    {
        var genesId = new int[genesMap.Count];
        int i = 0;
        foreach (Gene gene in genesMap.Values)
        {
            genesId[i] = gene.Id;
            i++;
        }
        return genesId;
    }
}
