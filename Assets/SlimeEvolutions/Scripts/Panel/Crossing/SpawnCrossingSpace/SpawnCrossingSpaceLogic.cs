using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;

namespace SlimeEvolutions.Panel.Crossing
{
    public class SpawnCrossingSpaceLogic : IActivatable
    {
        private SpawnCrossingSpaceView crossingView;


        public SpawnCrossingSpaceLogic(SpawnCrossingSpaceView crossingView)
        {
            this.crossingView = crossingView;
        }


        private void SetCrossingSpaceInteractorCountSlot()
        {
            var interactor = Game.GetInteractor<CrossingSpaceInteractor>();
            interactor.CountSlots = crossingView.HolderForCrossedPairsSlimes.CrossingPositions.Count;
        }

        private void CreateCrossingSpaceDateList()
        {
            var interactor = Game.GetInteractor<CrossingSpaceInteractor>();
            interactor.CreateSpacesList();
        }

        private void SpawnCrossPlace()
        {
        }

        private void AssignId()
        {
            var crossPosition = crossingView.HolderForCrossedPairsSlimes.CrossingPositions;
            int n = 0;
            foreach (HoldCrossingPlaceView i in crossPosition)
            {
                i.ID = n;
                n++;
            }
        }

        private void OnGameInitialized()
        {
            SetCrossingSpaceInteractorCountSlot();
            CreateCrossingSpaceDateList();
            AssignId();
            Game.OnGameInitializedEvent -= OnGameInitialized;
        }

        public void Awake()
        {
            if (Game.IsGameInitialized)
            {
                OnGameInitialized();
                return;
            }
            Game.OnGameInitializedEvent += OnGameInitialized;
        }

        public void OnEnable()
        {
            SpawnCrossPlace();
        }

        public void OnDisable()
        {
        }
    }
}
