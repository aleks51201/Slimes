using SlimeEvolutions.Architecture.CrossData;
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Buttons;
using SlimeEvolutions.InventoryCell;
using SlimeEvolutions.Timers;
using System;
using TMPro;
using UnityEngine;
using SlimeEvolutions.Panel.Crossing.Update;

namespace SlimeEvolutions.Panel.Crossing
{
    public class HoldCrossingPlaceLogic : IActivatable
    {
        private HoldCrossingPlaceView holdCrossingPlaceView;
        private Timer timer;
        private CrossingSpaceData crossingSpace;
        private UpdateView updateView;


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


        private void StartTimer()
        {
            if (timer is not null)
            {
                if (timer.isActive)
                {
                    return;
                }
            }
            float seconds = (float)(crossingSpace.EndTimeCrossing - DateTime.Now).TotalSeconds;
            timer = new(TimerTypes.OneSecTickUnscaled, seconds);
            timer.Start();
            TimerSubscribe();
        }

        private void StopTimer()
        {
            if (timer is null)
            {
                return;
            }
            timer.Stop();
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
            var btns = new ButtonMain[] { holdCrossingPlaceView.LeftSlime, holdCrossingPlaceView.RightSlime, holdCrossingPlaceView.AcceptButton };
            foreach (ButtonMain btn in btns)
            {
                DeleteCellFromButton(btn);
                //SetButtonStatus(btn, false);
            }
            holdCrossingPlaceView.Timer.GetComponentInChildren<TextMeshProUGUI>().text = "";
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
                crossingSpace.LSlime,
                crossingSpace.RSlime,
                crossingSpace.ResultSlime
            };
            SaveSlime(slimes);
            Game.GetInteractor<CrossingSpaceInteractor>().SetStatusTaken(holdCrossingPlaceView.ID);
            Clean();
            UpdateInitialize();
        }

        private void TimerSubscribe()
        {
            if (timer is null)
            {
                return;
            }
            timer.OnTimerFinishedEvent += TimerUnsubscribe;
        }

        private void TimerUnsubscribe()
        {
            if (timer is null)
            {
                return;
            }
            timer.OnTimerFinishedEvent -= TimerUnsubscribe;
        }

        public void OnEnable()
        {
            updateView.OnEnable();
            TimerSubscribe();
            holdCrossingPlaceView.AcceptButton.OnButtonClickEvent += AcceptNewSlime;
        }

        public void OnDisable()
        {
            updateView.OnDisable();
            TimerUnsubscribe();
            StopTimer();
            holdCrossingPlaceView.AcceptButton.OnButtonClickEvent -= AcceptNewSlime;
            Clean();
        }
    }
}
