using System.Collections;
using UnityEngine;


namespace SlimeEvolutions.Architecture
{
    public sealed class Coroutines : MonoBehaviour
    {
        private static Coroutines instance;

        private static Coroutines Instance
        {
            get
            {
                if (instance == null)
                {
                    GameObject gameObject = new(name: "[COROUTINE_MANAGER]");
                    instance = gameObject.AddComponent<Coroutines>();
                    DontDestroyOnLoad(gameObject);
                }
                return instance;
            }
        }

        public static Coroutine StartRoutine(IEnumerator enumerator)
        {
            return Instance.StartCoroutine(enumerator);
        }

        public static void StopRoutine(Coroutine routine)
        {
            if (routine != null)
                Instance.StopCoroutine(routine);
        }
    }
}