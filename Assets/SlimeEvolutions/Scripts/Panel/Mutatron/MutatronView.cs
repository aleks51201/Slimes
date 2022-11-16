using UnityEngine;

namespace SlimeEvolutions.Panel
{
    public class MutatronView : MonoBehaviour
    {
        MutatronLogic mutatronLogic;

        private void Start()
        {
            mutatronLogic = new(this.gameObject);
        }
    }
}
