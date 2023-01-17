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


        public HoldCrossingPlaceLogic(HoldCrossingPlaceView holdCrossingPlaceView)
        {
            this.holdCrossingPlaceView = holdCrossingPlaceView;
        }


        private void UpdateV()
        {
            var updateView = new UpdateView
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

        private void IfTimeHasNotExpired()
        {
            if (DateTime.Now < crossingSpace.EndTimeCrossing)
            {
                StartTimer();
                EnableTimerView();
                EnableSliderView();
            }
        }

        private void WasNotPickedUp()
        {
            if (DateTime.Now > crossingSpace.EndTimeCrossing)
            {
                EnableButton();
                DisableSliderView();
                DisableTimerView();
            }
        }

        private void IfThereIsCorrectInformation()
        {
            if (IsDataOk(crossingSpace))
            {
                FillingCellData(crossingSpace);
                EnableActiveLayer();
                WasNotPickedUp();
                IfTimeHasNotExpired();
                return;
            }
        }

        private void IfThereIsNotCorrectInformation()
        {
            if (!IsDataOk(crossingSpace))
            {
                DisableSliderView();
                DisableTimerView();
                DisableActiveLayer();
                DisableButton();
                holdCrossingPlaceView.LeftSlime.IsActive = false;
                holdCrossingPlaceView.RightSlime.IsActive = false;
            }
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
        }

        private void EnableButton()
        {
            holdCrossingPlaceView.AcceptButton.gameObject.SetActive(true);
            holdCrossingPlaceView.AcceptButton.IsActive = true;
        }

        private void DisableButton()
        {
            holdCrossingPlaceView.AcceptButton.gameObject.SetActive(false);
            holdCrossingPlaceView.AcceptButton.IsActive = false;
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

        private void UpdateTimerView(float seconds)
        {
            var time = TimeSpan.FromSeconds(seconds);
            holdCrossingPlaceView.Timer.GetComponentInChildren<TextMeshProUGUI>().text = $"{time:mm}:{time:ss}";
        }

        private void EnableTimerView()
        {
            holdCrossingPlaceView.Timer.SetActive(true);
        }

        private void DisableTimerView()
        {
            holdCrossingPlaceView.Timer.SetActive(false);
        }

        private void TimerViewIsActive(bool isActive)
        {
            if (isActive)
            {
                EnableTimerView();
                return;
            }
            DisableTimerView();
        }

        private void SliderUpdate(float seconds)
        {
            float totalSeconds = (float)(crossingSpace.EndTimeCrossing - crossingSpace.StartTimeCrossing).TotalSeconds;
            holdCrossingPlaceView.Slider.value = 1 - (seconds / totalSeconds);
        }

        private void EnableSliderView()
        {
            holdCrossingPlaceView.Slider.gameObject.SetActive(true);
        }

        private void DisableSliderView()
        {
            holdCrossingPlaceView.Slider.gameObject.SetActive(false);
        }

        private void SliderViewIsActive(bool isActive)
        {
            if (isActive)
            {
                EnableSliderView();
                return;
            }
            DisableSliderView();
        }

        private void EnableActiveLayer()
        {
            holdCrossingPlaceView.ActionLayer.SetActive(true);
        }

        private void DisableActiveLayer()
        {
            holdCrossingPlaceView.ActionLayer.SetActive(false);
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
            var btns = new ButtonMain[] { holdCrossingPlaceView.LeftSlime, holdCrossingPlaceView.RightSlime, holdCrossingPlaceView.AcceptButton };
            foreach (ButtonMain btn in btns)
            {
                DeleteCellFromButton(btn);
                SetButtonStatus(btn, false);
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
            UpdateV();
        }

        private void TimerSubscribe()
        {
            if (timer is null)
            {
                return;
            }
            timer.OnTimerValueChangedEvent += UpdateTimerView;
            timer.OnTimerValueChangedEvent += SliderUpdate;
            timer.OnTimerFinishedEvent += EnableButton;
            timer.OnTimerFinishedEvent += DisableTimerView;
            timer.OnTimerFinishedEvent += DisableSliderView;
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
            timer.OnTimerFinishedEvent -= EnableButton;
            timer.OnTimerFinishedEvent -= DisableTimerView;
            timer.OnTimerFinishedEvent -= DisableSliderView;
            timer.OnTimerFinishedEvent -= TimerUnsubscribe;
        }

        public void OnEnable()
        {
            UpdateV();
            TimerSubscribe();
            holdCrossingPlaceView.AcceptButton.OnButtonClickEvent += AcceptNewSlime;
        }

        public void OnDisable()
        {
            TimerUnsubscribe();
            StopTimer();
            holdCrossingPlaceView.AcceptButton.OnButtonClickEvent -= AcceptNewSlime;
            Clean();
        }
    }
}
