using UnityEngine;

namespace SlimeEvolutions.Panel
{
    public class MutatronView : MonoBehaviour
    {
        [SerializeField] private int mutagenMultiplierOnSale;

        private MutatronLogic mutatronLogic;


        private void Start()
        {
            mutatronLogic = new(this);
        }
    }
}
