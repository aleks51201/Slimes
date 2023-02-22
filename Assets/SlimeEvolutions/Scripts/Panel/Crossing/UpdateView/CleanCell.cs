using SlimeEvolutions.InventoryCell;
using SlimeEvolutions.Spawn;
using UnityEngine;

namespace SlimeEvolutions.Panel.Crossing.Update
{
    public class CleanCell
    {
        public CleanCell()
        {
        }

        public void Clean(GameObject go)
        {
            try
            {
                GameObject goCell = go.GetComponentInChildren<CellView>().gameObject;
                Spawner.Instance.DestroyObject(goCell);
            }
            catch
            {

            }
        }
    }
}
