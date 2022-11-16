using SlimeEvolutions.Inventory;
using System;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private int inventorySize;
    [SerializeField] private GameObject buttonPrefab;//???

    private InventoryLogic inventoryLogic;

    public int InventorySize => inventorySize;
    public Transform Inventory => this.transform;

    private void LoadInventory(InventoryLogic inventoryLogic)
    {
        Slime[] slimes = inventoryLogic.LoadSavedInventory();
        CleanInventory();
        if (slimes == null)
        {
            throw new NullReferenceException("Slimes list is null");
        }
        foreach (Slime slime in slimes)
        {
            inventoryLogic.CreateCell(Instantiate(buttonPrefab, this.transform), slime);
        }
    }

    private void CleanInventory()
    {
        var i = gameObject.GetComponentsInChildren<InventoryButtonView>();
        if (i != null)
        {
            foreach (var j in i)
                Destroy(j.gameObject);
        }
    }

    private void Init()
    {
        LoadInventory(inventoryLogic);
    }

    private void Awake()
    {
        inventoryLogic = new();
        inventoryLogic.Awake();
    }

    private void Start()
    {
        inventoryLogic.Start();
    }

    private void OnEnable()
    {
        inventoryLogic.ViewUpdateEvent += Init;
        inventoryLogic.OnEnable();
    }

    private void OnDisable()
    {
        inventoryLogic.ViewUpdateEvent -= Init;
        inventoryLogic.OnDisable();
    }
}
