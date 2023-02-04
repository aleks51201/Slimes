using UnityEngine;

namespace SlimeEvolutions.Slimes.Gemom
{
    public class ElementView:MonoBehaviour
    {
        private void Start()
        {
            Element element = new();
            element.SetSprite(this.gameObject, element.GetSprite(this.gameObject, element.GetCellSlimeId(this.gameObject)));
            
        }
    }
}
