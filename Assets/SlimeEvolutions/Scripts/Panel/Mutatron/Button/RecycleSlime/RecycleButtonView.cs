using UnityEngine;

namespace SlimeEvolutions.Panel.Mutatron
{
    public class RecycleButtonView : MonoBehaviour
    {
        [SerializeField] private string beforeRecycle;
        [SerializeField] private string afterRecycle;

        private RecycleButtonLogic recycleButtonLogic;


        private void Start()
        {
            recycleButtonLogic = new(this);
        }

        public void OnClick()
        {
            recycleButtonLogic.OnClick();
        }
    }
}
