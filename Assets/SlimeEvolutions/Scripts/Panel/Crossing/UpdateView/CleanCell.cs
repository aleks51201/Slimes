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
            var spw = new Spawner();
            spw.DestroyObject(go.GetComponentInChildren<CellView>().gameObject);
        }
    }
}
