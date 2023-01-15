using SlimeEvolutions.Architecture.CrossData;
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Buttons;
using SlimeEvolutions.InventoryCell;
using SlimeEvolutions.Timers;
using System;
using TMPro;
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
                if(DateTime.Now> crossingSpace.EndTimeCrossing)
                {
                    EnableButton();
                    DisableSliderView();
                    DisableTimerView();
                }
                return;
            }
            holdCrossingPlaceView.LeftSlime.IsActive = false;
            holdCrossingPlaceView.RightSlime.IsActive = false;
            holdCrossingPlaceView.AcceptButton.IsActive = false;
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
            if (crossingSpace.EndTimeCrossing < DateTime.Now)
            {
                holdCrossingPlaceView.AcceptButton.gameObject.SetActive(true);
                holdCrossingPlaceView.AcceptButton.IsActive = true;
            }
        }

        private void StartTimer()
        {
            float seconds = (float)(crossingSpace.EndTimeCrossing - DateTime.Now).TotalSeconds;
            timer = new(TimerTypes.OneSecTickUnscaled, seconds);
            timer.Start();
            TimerSubscribe();
        }

        private void UpdateTimerView(float seconds)
        {
            holdCrossingPlaceView.Timer.GetComponentInChildren<TextMeshProUGUI>().text = $"{(int)seconds}";
        }

        private void DisableTimerView()
        {
            holdCrossingPlaceView.Timer.SetActive(false);
        }

        private void SliderUpdate(float seconds)
        {
            float totalSeconds = (float)(crossingSpace.EndTimeCrossing - crossingSpace.StartTimeCrossing).TotalSeconds;
            holdCrossingPlaceView.Slider.value = 1 - (seconds / totalSeconds);
        }

        private void DisableSliderView()
        {
            holdCrossingPlaceView.Slider.gameObject.SetActive(false);
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
            UpdateView();
            TimerSubscribe();
            holdCrossingPlaceView.AcceptButton.OnButtonClickEvent += AcceptNewSlime;
        }

        public void OnDisable()
        {
            TimerUnsubscribe();
            holdCrossingPlaceView.AcceptButton.OnButtonClickEvent -= AcceptNewSlime;
            Clean();
        }
    }
}
