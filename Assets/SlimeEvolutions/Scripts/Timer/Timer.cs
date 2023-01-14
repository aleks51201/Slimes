using System;
using UnityEngine;

namespace SlimeEvolutions.Timers
{
    public class Timer
    {
        public TimerTypes Type { get; }
        public float RemainingSecond { get; private set; }
        public bool isPaused { get; private set; }


        public event Action<float> OnTimerValueChangedEvent;
        public event Action OnTimerFinishedEvent;


        public Timer(TimerTypes timerTypes)
        {
            Type = timerTypes;
        }

        public Timer(TimerTypes timerTypes, float seconds)
        {
            Type = timerTypes;
            SetTime(seconds);
        }


        public void SetTime(float seconds)
        {
            RemainingSecond = seconds;
            OnTimerValueChangedEvent?.Invoke(RemainingSecond);
        }

        public void Start()
        {
            InvokeStopTimerEventIfRemainingSecondsIsZero();
            isPaused = false;
            Subscribe();
            OnTimerValueChangedEvent?.Invoke(RemainingSecond);
        }

        public void Start(float seconds)
        {
            SetTime(seconds);
            Start();
        }

        public void Pause()
        {
            isPaused = true;
            Unsubscribe();
            OnTimerValueChangedEvent?.Invoke(RemainingSecond);
        }

        public void Unpause()
        {
            isPaused = false;
            Subscribe();
            OnTimerValueChangedEvent?.Invoke(RemainingSecond);
        }

        public void Stop()
        {
            Unsubscribe();
            RemainingSecond = 0;
            OnTimerValueChangedEvent?.Invoke(RemainingSecond);
            OnTimerFinishedEvent?.Invoke();
        }

        private void InvokeStopTimerEventIfRemainingSecondsIsZero()
        {
            if (RemainingSecond == 0)
            {
                Debug.LogError("TIMER: You are trying start timer with remaining seconds equal 0");
                OnTimerFinishedEvent?.Invoke();
            }
        }

        private void Subscribe()
        {
            switch (Type)
            {
                case TimerTypes.UpdateTick:
                    TimeInvoker.Instance.OnUpdateTimeTickedEvent += OnUpdateTick;
                    break;
                case TimerTypes.UpdateTickUnscaled:
                    TimeInvoker.Instance.OnUpdateTimeUnscaledTickedEvent += OnUpdateTick;
                    break;
                case TimerTypes.OneSecTick:
                    TimeInvoker.Instance.OnOneSecondTickedEvent += OnOneSecondTick;
                    break;
                case TimerTypes.OneSecTickUnscaled:
                    TimeInvoker.Instance.OnONeSecondUnscaledTickedEvent += OnOneSecondTick;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("this type does not exist");
            }
        }

        private void Unsubscribe()
        {
            switch (Type)
            {
                case TimerTypes.UpdateTick:
                    TimeInvoker.Instance.OnUpdateTimeTickedEvent -= OnUpdateTick;
                    break;
                case TimerTypes.UpdateTickUnscaled:
                    TimeInvoker.Instance.OnUpdateTimeUnscaledTickedEvent -= OnUpdateTick;
                    break;
                case TimerTypes.OneSecTick:
                    TimeInvoker.Instance.OnOneSecondTickedEvent -= OnOneSecondTick;
                    break;
                case TimerTypes.OneSecTickUnscaled:
                    TimeInvoker.Instance.OnONeSecondUnscaledTickedEvent -= OnOneSecondTick;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("this type does not exist");
            }

        }

        private void OnUpdateTick(float deltaTime)
        {
            if (isPaused)
            {
                return;
            }
            RemainingSecond -= deltaTime;
            CheckFinish();
        }

        private void OnOneSecondTick()
        {
            if (isPaused)
            {
                return;
            }
            RemainingSecond -= 1f;
            CheckFinish();
        }

        private void CheckFinish()
        {
            if (RemainingSecond <= 0)
            {
                Stop();
                return;
            }
            OnTimerValueChangedEvent?.Invoke(RemainingSecond);
        }
    }
}
