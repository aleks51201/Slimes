using SlimeEvolutions.Architecture.CrossData;
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Panel.Crossing.Update;

namespace SlimeEvolutions.Panel.Crossing
{
    public class HoldCrossingPlaceLogic : IActivatable
    {
        private HoldCrossingPlaceView holdCrossingPlaceView;
        private CrossingSpaceData crossingSpace;
        private UpdateView updateView;


        private CrossingSpaceData CrossingSpace => Game.GetInteractor<CrossingSpaceInteractor>().CrossingSpaces[holdCrossingPlaceView.ID];


        public HoldCrossingPlaceLogic(HoldCrossingPlaceView holdCrossingPlaceView)
        {
            this.holdCrossingPlaceView = holdCrossingPlaceView;
        }


        private void UpdateInitialize()
        {
            updateView = new UpdateView
                (
                holdCrossingPlaceView.Prefab,
                holdCrossingPlaceView.AcceptButton,
                holdCrossingPlaceView.LeftSlime,
                holdCrossingPlaceView.RightSlime,
                holdCrossingPlaceView.Slider,
                holdCrossingPlaceView.Timer,
                holdCrossingPlaceView.ActionLayer
                );
            updateView.Initialize(holdCrossingPlaceView.ID);
        }

        private void SaveSlime(Slime[] slimes)
        {
            foreach (Slime slime in slimes)
            {
                SlimesInventory.AddSlime(this, slime);
            }
        }

        private void AcceptNewSlime()
        {
            var slimes = new Slime[]
            {
                CrossingSpace.LSlime,
                CrossingSpace.RSlime,
                CrossingSpace.ResultSlime
            };
            SaveSlime(slimes);
            Game.GetInteractor<CrossingSpaceInteractor>().SetStatusTaken(holdCrossingPlaceView.ID);
            UpdateInitialize();
        }

        private void Subscribe()
        {
            holdCrossingPlaceView.AcceptButton.OnButtonClickEvent += AcceptNewSlime;
        }

        private void Unsubscribe()
        {
            holdCrossingPlaceView.AcceptButton.OnButtonClickEvent -= AcceptNewSlime;
        }

        public void Awake()
        {
            UpdateInitialize();
        }

        public void OnEnable()
        {
            updateView.OnEnable();
            Subscribe();
        }

        public void OnDisable()
        {
            updateView.OnDisable();
            Unsubscribe();
        }
    }
}
