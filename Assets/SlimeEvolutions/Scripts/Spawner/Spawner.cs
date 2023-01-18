using UnityEngine;

namespace SlimeEvolutions.Spawn
{
    public class Spawner : MonoBehaviour
    {
        private static Spawner s_instance;


        public static Spawner Instance
        {
            get
            {
                if (s_instance is null)
                {
                    var go = new GameObject("[SPAWNER]");
                    s_instance = go.AddComponent<Spawner>();
                    DontDestroyOnLoad(go);
                }
                return s_instance;
            }
        }


        public GameObject SpawnObject(GameObject prefab, Transform parentTransform)
        {
            return Instantiate(prefab, parentTransform);
        }
    }
}
