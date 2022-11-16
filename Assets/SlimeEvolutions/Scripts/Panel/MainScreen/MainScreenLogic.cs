using SlimeEvolutions.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeEvolutions.Panel
{
    public class MainScreenLogic : IActivatable
    {
        private void Action(Slime slime)
        {

        }

        public void OnEnable()
        {
            InventoryButtonLogic.OnInventoryButtonClickEvent +=Action;
        }

        public void OnDisable()
        {
            InventoryButtonLogic.OnInventoryButtonClickEvent -=Action;
        }
    }
}
