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


        public void OnClick()
        {
            recycleButtonLogic.OnClick();
        }

        private void Awake()
        {
            recycleButtonLogic = new(this);
        }
        private void OnEnable()
        {
            recycleButtonLogic.OnEnable();
        }

        private void OnDisable()
        {
            recycleButtonLogic.OnDisable();
        }
    }
}
