using UnityEngine;

namespace SlimeEvolutions.Slimes.Gemom
{
    public class SlimeFormView : MonoBehaviour
    {
        private void Start()
        {
            SlimeForm slimeForm = new();
            slimeForm.SetSprite(this.gameObject, slimeForm.GetSprite(this.gameObject, slimeForm.GetCellSlimeId(this.gameObject)));
        }
    }
}
