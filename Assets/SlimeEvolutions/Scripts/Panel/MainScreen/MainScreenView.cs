using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Panel.Crossing;
using UnityEngine;

namespace SlimeEvolutions.Panel
{
    public class MainScreenView : MonoBehaviour
    {
        [SerializeField] private HolderForCrossedPairsSlimes holderForCrossedPairsSlimes;

        private MainScreenLogic mainScreenLogic;

        public HolderForCrossedPairsSlimes HolderForCrossedPairsSlimes => holderForCrossedPairsSlimes;


        private void Awake()
        {
            Game.Run();
            mainScreenLogic = new MainScreenLogic(this);
            mainScreenLogic.Awake();
        }

        private void OnEnable()
        {
            mainScreenLogic.OnEnable();
        }

        private void OnDisable()
        {
            mainScreenLogic.OnDisable();
        }
    }
}
