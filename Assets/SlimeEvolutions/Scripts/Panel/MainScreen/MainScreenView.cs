using SlimeEvolutions.Architecture.Scene;
using UnityEngine;

namespace SlimeEvolutions.Panel
{
    public class MainScreenView : MonoBehaviour
    {
        //[SerializeField] private 
        private IActivatable mainScreenLogic;

        private void Awake()
        {
            Game.Run();
            mainScreenLogic = new MainScreenLogic();
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
