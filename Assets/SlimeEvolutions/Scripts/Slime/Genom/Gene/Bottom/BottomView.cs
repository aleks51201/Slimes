using UnityEngine;

namespace SlimeEvolutions.Slimes.Gemom
{
    public class BottomView : MonoBehaviour
    {
        private void Start()
        {
            Bottom bottom = new();
            bottom.SetSprite(this.gameObject, bottom.GetSprite(this.gameObject, bottom.GetCellSlimeId(this.gameObject)));
        }
    }
}

