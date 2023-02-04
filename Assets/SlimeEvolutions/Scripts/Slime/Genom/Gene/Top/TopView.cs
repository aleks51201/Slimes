using UnityEngine;

namespace SlimeEvolutions.Slimes.Gemom
{
    public class TopView:MonoBehaviour
    {
        private void Start()
        {
            Top top = new();
            top.SetSprite(this.gameObject, top.GetSprite(this.gameObject, top.GetCellSlimeId(this.gameObject)));
        }
    }
}
