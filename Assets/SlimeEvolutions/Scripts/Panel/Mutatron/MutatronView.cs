using UnityEngine;

namespace SlimeEvolutions.Panel
{
    public class MutatronView : MonoBehaviour
    {
        [SerializeField] private int mutagenMultiplierOnSale;

        private MutatronLogic mutatronLogic;


        public int MutagenMultiplierOnSale => mutagenMultiplierOnSale;


        private void Start()
        {
            mutatronLogic = new(this);
        }
    }
}
