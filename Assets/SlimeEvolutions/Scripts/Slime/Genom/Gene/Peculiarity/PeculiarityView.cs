using UnityEngine;

namespace SlimeEvolutions.Slimes.Gemom
{
    public class PeculiarityView:MonoBehaviour
    {
        private void Start()
        {
            Peculiarity peculiarity = new();
            peculiarity.SetSprite(this.gameObject, peculiarity.GetSprite(this.gameObject, peculiarity.GetCellSlimeId(this.gameObject)));
        }
    }
}
