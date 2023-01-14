using UnityEngine;

namespace SlimeEvolutions.Panel.Crossing
{
    public class SpawnCrossingSpaceView : MonoBehaviour, IActivatable
    {
        [SerializeField] private HolderForCrossedPairsSlimes holderForCrossedPairsSlimes;


        private SpawnCrossingSpaceLogic crossingLogic;


        public HolderForCrossedPairsSlimes HolderForCrossedPairsSlimes => holderForCrossedPairsSlimes;


        public void SpawnCrossPlace(GameObject prefab, Vector2 position)
        {
            Instantiate(prefab, position, Quaternion.identity);
        }

        private void Awake()
        {
            crossingLogic = new(this);
            crossingLogic.Awake();
        }

        public void OnEnable()
        {
            crossingLogic.OnEnable();
        }

        public void OnDisable()
        {
            crossingLogic.OnDisable();
        }
    }
}
