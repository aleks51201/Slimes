using UnityEngine;

namespace SlimeEvolutions.Slimes.Gemom
{
    public class SlimeFormView : MonoBehaviour
    {
        private void Start()
        {
            SlimeForm slimeForm = new();
            slimeForm.SetSpite(this.gameObject, slimeForm.GetSprite(this.gameObject, slimeForm.GetCellSlimeId(this.gameObject)));
        }
    }
}
