using UnityEngine;

namespace SlimeEvolutions.Slimes.Gemom
{
    public class MiddleView:MonoBehaviour
    {
        private void Start()
        {
            Middle middle = new();
            middle.SetSprite(this.gameObject, middle.GetSprite(this.gameObject, middle.GetCellSlimeId(this.gameObject)));
        }
    }
}
