using System;
using UnityEngine;

namespace SlimeEvolutions.Timers
{
    public class TimeInvoker : MonoBehaviour
    {
        private static TimeInvoker s_instance;

        private float oneSecTimer;
        private float oneSecUnscaledTimer;


        public static TimeInvoker Instance
        {
            get
            {
                if (s_instance is null)
                {
                    var go = new GameObject("[TIME INVOKER]");
                    s_instance = go.AddComponent<TimeInvoker>();
                    DontDestroyOnLoad(go);
                }
                return s_instance;
            }
        }


        public event Action<float> OnUpdateTimeTickedEvent;
        public event Action<float> OnUpdateTimeUnscaledTickedEvent;
        public event Action OnOneSecondTickedEvent;
        public event Action OnONeSecondUnscaledTickedEvent;


        private void Update()
        {
            float deltaTime = Time.deltaTime;
            OnUpdateTimeTickedEvent?.Invoke(deltaTime);

            oneSecTimer += deltaTime;
            if (oneSecTimer >= 1)
            {
                oneSecTimer -= 1;
                OnOneSecondTickedEvent?.Invoke();
            }

            float unscaledDeltaTime = Time.unscaledDeltaTime;
            OnUpdateTimeUnscaledTickedEvent?.Invoke(unscaledDeltaTime);

            oneSecUnscaledTimer += unscaledDeltaTime;
            if (oneSecUnscaledTimer >= 1)
            {
                oneSecUnscaledTimer -= 1;
                OnONeSecondUnscaledTickedEvent?.Invoke();
            }
        }


    }
}