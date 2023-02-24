using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Inventory.Behaviour;
using SlimeEvolutions.Inventory.InventoryButton;
using SlimeEvolutions.InventoryCell;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryLogic
{
    private InventoryBehaviour inventoryBehaviour;
    private GenomeResources[] genomResources;
    private InventoryView inventoryView;


    public InventoryBehaviour InventoryBehaviour => inventoryBehaviour;


    public Action ViewUpdateEvent;


    public InventoryLogic(InventoryView inventoryView)
    {
        this.inventoryView = inventoryView;
    }


    public void CreateCell(GameObject newCell, Slime slime)
    {
        newCell.GetComponentInChildren<CellView>().Slime = slime;
        newCell.GetComponent<ColorChanger>().CurrentBehaviour = InventoryBehaviour.InventoryBehaviourType;
        newCell.GetComponent<ColorChanger>().LeftObjectOnMainCross = inventoryView.CrossPlaceView.LeftCrossSlimePositionView;
        newCell.GetComponent<ColorChanger>().RightObjectOnMainCross = inventoryView.CrossPlaceView.RightCrossSlimePositionView;
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
