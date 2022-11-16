using UnityEngine;

namespace SlimeEvolutions.Slimes.Gemom
{
    public class EyesView : MonoBehaviour
    {
        private void Start()
        {
            Eyes eyes = new();
            eyes.SetSpite(this.gameObject, eyes.GetSprite(this.gameObject, eyes.GetCellSlimeId(this.gameObject)));
        }
    }
}
