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
                go = go.GetComponentInChildren<CellView>().gameObject;
                Spawner.Instance.DestroyObject(go);
            }
            catch
            {

            }
        }
    }
}
