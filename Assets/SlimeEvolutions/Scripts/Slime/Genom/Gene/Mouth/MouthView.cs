using UnityEngine;

namespace SlimeEvolutions.Slimes.Gemom
{
    public class MouthView : MonoBehaviour
    {
        private void Start()
        {
            Mouth mouth = new();
            mouth.SetSpite(this.gameObject, mouth.GetSprite(this.gameObject, mouth.GetCellSlimeId(this.gameObject)));
        }
    }
}
