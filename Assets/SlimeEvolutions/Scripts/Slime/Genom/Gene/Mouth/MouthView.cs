using UnityEngine;

namespace SlimeEvolutions.Slimes.Gemom
{
    public class MouthView : MonoBehaviour
    {
        private void Start()
        {
            Mouth mouth = new();
            mouth.SetSprite(this.gameObject, mouth.GetSprite(this.gameObject, mouth.GetCellSlimeId(this.gameObject)));
        }
    }
}
