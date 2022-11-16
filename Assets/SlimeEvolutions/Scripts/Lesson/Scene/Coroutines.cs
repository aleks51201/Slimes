using System.Collections;
using UnityEngine;


namespace SlimeEvolutions.Lesson.Scene
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
            return instance.StartCoroutine(enumerator);
        }

        public static void StopRoutine(Coroutine routine)
        {
            if (routine != null)
                instance.StopCoroutine(routine);
        }
    }
}