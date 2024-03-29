﻿using SlimeEvolutions;
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Stuff;
using System;

public class Slime
{
    private int id;
    private int lvl;
    private Genome genome;


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
    public int Lvl
    {
        get => lvl;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException("Value can't be less than one");
            }
            lvl = value;
        }
    }
    public bool IsExplored { get; set; }
    public Genome Genome { get => genome; set => genome = value; }

    public Slime()
    {
        Init();
    }

    private void Init()
    {
        genome = new();
    }

    public void RandomSlime()
    {
        id = new SlimeID().GetUniqueId();
        lvl = ProgressionCalculator.CalcTotalLvlForExp(Game.GetInteractor<ExperienceInteractor>().Experience, 50);
        IsExplored = false;
        genome.RandomGenome();
    }

    public void RandomSlimeWithoutGenome()
    {
        id = new SlimeID().GetUniqueId();
        lvl = RandomNumber(1, 100);
        IsExplored = false;
    }
    public void RandomSlimeWithoutGenome(int lvlFirstParent, int lvlSecondParent)
    {
        id = new SlimeID().GetUniqueId();
        int minlvl = Math.Min(lvlFirstParent, lvlSecondParent);
        int maxlvl = minlvl + 5;
        if(maxlvl > ProgressionCalculator.CalcTotalLvlForExp(Game.GetInteractor<ExperienceInteractor>().Experience, 50))
        {
            maxlvl = ProgressionCalculator.CalcTotalLvlForExp(Game.GetInteractor<ExperienceInteractor>().Experience, 50);
        }
        lvl = RandomNumber(minlvl, maxlvl + 1);
        IsExplored = false;
    }

    private int RandomNumber(int min, int max)
    {
        System.Random rnd = new();
        return rnd.Next(min, max);
    }
}