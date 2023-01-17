using SlimeEvolutions.Buttons;
using SlimeEvolutions.InventoryCell;
using SlimeEvolutions.Spawn;
using UnityEngine;

namespace SlimeEvolutions.Panel.Crossing.UpdateView
{
    public class FillingCell
    {
        private GameObject prefab;


        public FillingCell(GameObject cellPrefab)
        {
            this.prefab = cellPrefab;
        }


        public void AddCell(Transform parentTransform, Slime slime)
        {
            GameObject go = Spawner.Instance.SpawnObject(prefab, parentTransform);
            AddSlimeToCell(go, slime);
        }

        public void AddCell(ButtonMain parentButton, Slime slime)
        {
            AddCell(parentButton.transform, slime);
            SetButtonClickable(parentButton, true);
        }

        private void SetButtonClickable(ButtonMain button, bool isClickable)
        {
            button.IsActive = isClickable;
        }

        private void AddSlimeToCell(GameObject cell, Slime slime)
        {
            cell.GetComponent<CellView>().Slime = slime;
        }
    }
}
