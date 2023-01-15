using SlimeEvolutions.Buttons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeEvolutions.Panel.Crossing
{
    public class HoldCrossingPlaceView : MonoBehaviour
    {
        [SerializeField] private ButtonWithHold leftSlime, rightSlime;
        [SerializeField] private ButtonWithClick acceptButton;
        [SerializeField] private GameObject timer;
        [SerializeField] private GameObject prefab;
        [SerializeField] private int lvlForOpen;
        [SerializeField] private Slider slider;
        [SerializeField] private GameObject actionLayer;


        private HoldCrossingPlaceLogic holdCrossingPlaceLogic;


        public int ID { get; set; }
        public ButtonWithHold LeftSlime => leftSlime;
        public ButtonWithHold RightSlime => rightSlime;
        public ButtonWithClick AcceptButton => acceptButton;
        public GameObject Timer => timer;
        public GameObject Prefab => prefab;
        public Slider Slider => slider;
        public GameObject ActionLayer => actionLayer;


        public GameObject Spawn(GameObject prefab, Vector2 position)
        {
            return Instantiate(prefab, position, Quaternion.identity);
        }

        public GameObject Spawn(GameObject prefab, Transform parentTransform)
        {
            return Instantiate(prefab, parentTransform);
        }
        
        public void Delete(GameObject go)
        {
            Destroy(go);
        }

        private void Awake()
        {
            holdCrossingPlaceLogic = new(this);
        }

        private void OnEnable()
        {
            holdCrossingPlaceLogic.OnEnable();
        }

        private void OnDisable()
        {
            holdCrossingPlaceLogic.OnDisable();
        }
    }
}
