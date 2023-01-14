using SlimeEvolutions.Architecture.CrossData;
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Buttons;
using SlimeEvolutions.InventoryCell;
using SlimeEvolutions.Timers;
using System;
using UnityEngine;

namespace SlimeEvolutions.Panel.Crossing
{
    public class HoldCrossingPlaceLogic : IActivatable
    {
        private HoldCrossingPlaceView holdCrossingPlaceView;
        private Timer timer;
        private CrossingSpaceData crossingSpace;


        public HoldCrossingPlaceLogic(HoldCrossingPlaceView holdCrossingPlaceView)
        {
            this.holdCrossingPlaceView = holdCrossingPlaceView;
        }


        private void UpdateView()
        {
            var interactor = Game.GetInteractor<CrossingSpaceInteractor>();
            crossingSpace = interactor.CrossingSpaces[holdCrossingPlaceView.ID];
            if (IsDataOk(crossingSpace))
            {
                FillingCellData(crossingSpace);
                if (DateTime.Now < crossingSpace.EndTimeCrossing)
                {
                    StartTimer();
                }
                return;
            }
            holdCrossingPlaceView.LeftSlime.IsActive = false;
            holdCrossingPlaceView.RightSlime.IsActive = false;
            holdCrossingPlaceView.CentralSlime.IsActive = false;
        }

        private bool IsDataOk(CrossingSpaceData crossingSpaceData)
        {
            if (crossingSpaceData is null || crossingSpaceData.HasBeenSlimeTaken)
            {
                return false;
            }
            return true;
        }

        private void AddCell(GameObject go, Slime slime)
        {
            GameObject newGo = holdCrossingPlaceView.Spawn(holdCrossingPlaceView.Prefab, go.transform);
            newGo.GetComponent<CellView>().Slime = slime;
        }

        private void FillingCellData(CrossingSpaceData crossingSpace)
        {
            ButtonWithHold lSlime = holdCrossingPlaceView.LeftSlime;
            ButtonWithHold rSlime = holdCrossingPlaceView.RightSlime;
            AddCell(lSlime.gameObject, crossingSpace.LSlime);
            SetButtonStatus(lSlime, true);
            AddCell(rSlime.gameObject, crossingSpace.RSlime);
            SetButtonStatus(rSlime, true);
            FillingCellResultSlimeData();
        }

        private void FillingCellResultSlimeData()
        {
            ButtonWithClickAndHold cSlime = holdCrossingPlaceView.CentralSlime;
            if (crossingSpace.EndTimeCrossing < DateTime.Now)
            {
                AddCell(cSlime.gameObject, crossingSpace.ResultSlime);
                SetButtonStatus(cSlime, true);
            holdCrossingPlaceView.Timer.text = "";
            }
        }

        private void StartTimer()
        {
            float seconds = (float)(crossingSpace.EndTimeCrossing - DateTime.Now).TotalSeconds;
            timer = new(TimerTypes.OneSecTickUnscaled, seconds);
            timer.Start();
            timer.OnTimerValueChangedEvent += TimerUpdate;
            timer.OnTimerFinishedEvent += FillingCellResultSlimeData;
        }

        private void TimerUpdate(float seconds)
        {
            holdCrossingPlaceView.Timer.text = $"{(int)seconds}";
        }

        private void SetButtonStatus(ButtonMain btn, bool status)
        {
            btn.IsActive = status;
        }

        private void DeleteCellFromButton(ButtonMain btn)
        {
            try
            {
                holdCrossingPlaceView.Delete(btn.GetComponentInChildren<CellView>().gameObject);
            }
            catch
            {
                return;
            }
        }

        private void Clean()
        {
            var btns = new ButtonMain[] { holdCrossingPlaceView.LeftSlime, holdCrossingPlaceView.RightSlime, holdCrossingPlaceView.CentralSlime };
            foreach (ButtonMain btn in btns)
            {
                DeleteCellFromButton(btn);
                SetButtonStatus(btn, false);
            }
            holdCrossingPlaceView.Timer.text = "";
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
                holdCrossingPlaceView.LeftSlime.GetComponentInChildren<CellView>().Slime,
                holdCrossingPlaceView.RightSlime.GetComponentInChildren<CellView>().Slime,
                holdCrossingPlaceView.CentralSlime.GetComponentInChildren<CellView>().Slime
            };
            SaveSlime(slimes);
            Game.GetInteractor<CrossingSpaceInteractor>().SetStatusTaken(holdCrossingPlaceView.ID);
            Clean();
        }

        public void OnEnable()
        {
            UpdateView();
            if (timer is not null)
            {
                timer.OnTimerValueChangedEvent += TimerUpdate;
                timer.OnTimerFinishedEvent += FillingCellResultSlimeData;
            }
            holdCrossingPlaceView.CentralSlime.OnButtonClickEvent += AcceptNewSlime;
        }

        public void OnDisable()
        {
            if (timer is not null)
            {
                timer.OnTimerValueChangedEvent -= TimerUpdate;
                timer.OnTimerFinishedEvent -= FillingCellResultSlimeData;
            }
            holdCrossingPlaceView.CentralSlime.OnButtonClickEvent -= AcceptNewSlime;
            Clean();
        }
    }
}
