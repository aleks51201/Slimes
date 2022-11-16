using UnityEngine;
using System;

namespace SlimeEvolutions.InventoryCell
{
    public class CellView : MonoBehaviour
    {
        private Slime slime;
        public Slime Slime
        {
            get { return slime; }
            set
            {
                if (value == null)
                    throw new NullReferenceException($"Slime is null");
                slime = value;
            }
        }

        private void Start()
        {
            new CellLogic(slime.Lvl, slime.IsExplored, this.gameObject);
        }
    }
}
