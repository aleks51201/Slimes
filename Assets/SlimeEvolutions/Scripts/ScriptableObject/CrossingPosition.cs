using UnityEngine;


namespace SlimeEvolutions.SO
{
    [CreateAssetMenu(fileName = "CrossingPosition", menuName = "Crossing/Position")]
    public class CrossingPosition : ScriptableObject
    {
        [SerializeField] private Vector2 position;
        [SerializeField] private int levelUse;


        public Vector2 Position => position;
        public int LevelUse => levelUse;
    }
}
