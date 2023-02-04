using TMPro;
using UnityEngine;

namespace SlimeEvolutions.InventoryCell
{
    public class CellLogic
    {
        private int lvl;
        private bool isExplored;
        private GameObject gameObject;

        public CellLogic(int lvl, bool isExplored, GameObject gameObject)
        {
            this.lvl = lvl;
            this.isExplored = isExplored;
            this.gameObject = gameObject;
            Init();
        }

        private void Init()
        {
            SetLvlCell();
            //SetExploreCellStatus();
        }

        private void SetLvlCell()
        {
            gameObject.GetComponentInChildren<CellLvlView>().GetComponent<TextMeshProUGUI>().text = $"{lvl}";
            gameObject.GetComponentInChildren<CellLvlView>().lvl = lvl;
        }

        /*        private void SetExploreCellStatus()
                {
                    gameObject.GetComponentInChildren<CellExploredStatusView>().isExplored = isExplored;
                }
        */
    }
}
