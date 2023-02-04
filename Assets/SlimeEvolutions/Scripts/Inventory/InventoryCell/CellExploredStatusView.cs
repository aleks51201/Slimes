using UnityEngine;
using UnityEngine.UI;

namespace SlimeEvolutions.InventoryCell
{
    public class CellExploredStatusView : MonoBehaviour
    {
        [SerializeField] private CellView cellView;

        private bool IsExplored
        {
            get
            {
                return cellView.Slime.IsExplored;
            }
        }


        private void Start()
        {
            if (IsExplored)
            {
                GetComponent<Image>().enabled = true;
            }
            else
            {
                GetComponent<Image>().enabled = false;
            }
        }
    }
}
