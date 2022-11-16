using UnityEngine;

namespace SlimeEvolutions.Panel.Mutatron
{
    public class RecycleButtonView : MonoBehaviour
    {
        RecycleButtonLogic recycleButtonLogic;

        private void Start()
        {
            recycleButtonLogic = new(this.gameObject);
        }

        public void OnClick()
        {
            recycleButtonLogic.OnClick();
        }
    }
}
