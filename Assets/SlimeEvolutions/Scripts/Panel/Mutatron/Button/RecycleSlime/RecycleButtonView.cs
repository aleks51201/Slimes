using UnityEngine;

namespace SlimeEvolutions.Panel.Mutatron
{
    public class RecycleButtonView : MonoBehaviour
    {
        [SerializeField] private string beforeRecycle;
        [SerializeField] private string afterRecycle;

        private RecycleButtonLogic recycleButtonLogic;


        public string BeforeRecycle => beforeRecycle;
        public string AfterRecycle => afterRecycle;


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
