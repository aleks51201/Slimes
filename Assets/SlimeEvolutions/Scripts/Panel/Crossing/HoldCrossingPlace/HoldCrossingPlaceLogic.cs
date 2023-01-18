using SlimeEvolutions.Architecture.CrossData;
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Buttons;
using SlimeEvolutions.InventoryCell;
using SlimeEvolutions.Panel.Crossing.Update;
using SlimeEvolutions.Timers;
using System;
using TMPro;

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
        }

        private void StopTimer()
        {
            if (timer is null)
            {
                return;
            }
            timer.Stop();
        }

        private void UpdateTimerView(float seconds)
        {
            var time = TimeSpan.FromSeconds(seconds);
            holdCrossingPlaceView.Timer.GetComponentInChildren<TextMeshProUGUI>().text = $"{time:mm}:{time:ss}";
        }

        private void SliderUpdate(float seconds)
        {
            float totalSeconds = (float)(crossingSpace.EndTimeCrossing - crossingSpace.StartTimeCrossing).TotalSeconds;
            holdCrossingPlaceView.Slider.value = 1 - (seconds / totalSeconds);
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

        private void Subscribe()
        {
            updateView.InitializedTimeAvailableBehaviourEvent += StartTimer;
            TimerSubscribe();
        }

        private void Unsubscribe()
        {
            updateView.InitializedTimeAvailableBehaviourEvent -= StartTimer;
            TimerUnsubscribe();
        }

        private void TimerSubscribe()
        {
            if (timer is null)
            {
                return;
            }
            timer.OnTimerValueChangedEvent += UpdateTimerView;
            timer.OnTimerValueChangedEvent += SliderUpdate;
            timer.OnTimerFinishedEvent += TimerUnsubscribe;
        }

        private void TimerUnsubscribe()
        {
            if (timer is null)
            {
                return;
            }
            timer.OnTimerValueChangedEvent -= UpdateTimerView;
            timer.OnTimerValueChangedEvent -= SliderUpdate;
            timer.OnTimerFinishedEvent -= TimerUnsubscribe;
        }

        public void Awake()
        {
            UpdateInitialize();
        }

        public void OnEnable()
        {
            updateView.OnEnable();
            Subscribe();
            holdCrossingPlaceView.AcceptButton.OnButtonClickEvent += AcceptNewSlime;
        }

        public void OnDisable()
        {
            updateView.OnDisable();
            Unsubscribe();
            StopTimer();
            holdCrossingPlaceView.AcceptButton.OnButtonClickEvent -= AcceptNewSlime;
            //Clean();
        }
    }
}
