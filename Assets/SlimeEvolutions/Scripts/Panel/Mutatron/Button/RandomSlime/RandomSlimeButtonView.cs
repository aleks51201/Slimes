using UnityEngine;


namespace SlimeEvolutions.Panel.Mutatron
{
    public class RandomSlimeButtonView : MonoBehaviour
    {
        RandomSlimeButtonLogic randomSlimeButtonLogic;

        private void Start()
        {
            randomSlimeButtonLogic = new();
        }

        public void OnClick()
        {
            randomSlimeButtonLogic.OnClick();
        }
    }
}
