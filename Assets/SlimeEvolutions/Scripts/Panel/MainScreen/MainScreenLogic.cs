using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeEvolutions.Panel
{
    public class MainScreenLogic : IActivatable
    {
        private MainScreenView mainScreenView;


        public MainScreenLogic(MainScreenView mainScreenView)
        {
            this.mainScreenView = mainScreenView;
        }

        
        private void Action(Slime slime)
        {
        }

        private void SetCountCrossingSlots()
        {
            Game.GetInteractor<CrossingSpaceInteractor>().CountSlots = mainScreenView.HolderForCrossedPairsSlimes.CrossingPositions.Count;
            Game.OnGameInitializedEvent -= SetCountCrossingSlots;
        }

        public void Awake()
        {
            Game.OnGameInitializedEvent += SetCountCrossingSlots;
            SetCountCrossingSlots();
        }

        public void OnEnable()
        {
            InventoryButtonLogic.OnInventoryButtonClickEvent +=Action;
        }

        public void OnDisable()
        {
            InventoryButtonLogic.OnInventoryButtonClickEvent -=Action;
        }
    }
}
