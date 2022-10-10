using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private int inventorySize;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform parentObject;

    public int InventorySize => inventorySize;

    private void Start()
    {
        for (int i = 0; i < InventorySize; i++)
        {
            Instantiate(buttonPrefab, parentObject);
        }
    }

}
