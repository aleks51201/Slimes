using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Inventory.Behaviour;
using SlimeEvolutions.Inventory.InventoryButton;
using SlimeEvolutions.InventoryCell;
using SlimeEvolutions.Panel.MainScreen;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryLogic
{
    private InventoryBehaviour inventoryBehaviour;
    private GenomeResources[] genomResources;

    public InventoryBehaviour InventoryBehaviour => inventoryBehaviour;

    public Action ViewUpdateEvent;

    public void CreateCell(GameObject newCell, Slime slime)
    {
        newCell.GetComponentInChildren<CellView>().Slime = slime;
        newCell.GetComponent<ColorChanger>().CurrentBehaviour = InventoryBehaviour.InventoryBehaviourType;
    }

    public Slime[] LoadSavedInventory()
    {
        return SlimesInventory.Slimes;
    }

    public void ViewUpdate()
    {
        ViewUpdateEvent?.Invoke();
    }

    public void Awake()
    {
        inventoryBehaviour = new(this);
        inventoryBehaviour.InitializeBehaviour();
        inventoryBehaviour.SetBehaviourByDefault();
    }

    public void Start()
    {

    }

    public void OnEnable()
    {
        inventoryBehaviour.CurrentBehaviour.OnEnable();
    }

    public void OnDisable()
    {
        inventoryBehaviour.CurrentBehaviour.OnDisable();
    }

    private void MatchTypeResorcesArrays()
    {
        List<Genome.Genes> genes = new();
        foreach (GenomeResources genomResource in genomResources)
        {
            if (genes.Contains(genomResource.TypeArray))
                throw new Exception("Math one ore more types in GenomeResources[] ");
            genes.Add(genomResource.TypeArray);
        }
    }
}
