using SlimeEvolutions.Panel.Statistics.Experience;
using UnityEngine;


namespace SlimeEvolutions.Panel.Mutatron
{
    public class RandomSlimeButtonView : MonoBehaviour
    {
        [SerializeField] private int mutagenMultiplierWhenBuying;
        [SerializeField] private ExperienceView experienceView;
        [SerializeField] private string text;

        private RandomSlimeButtonLogic randomSlimeButtonLogic;


        public int MutagenMultiplier => mutagenMultiplierWhenBuying;
        public int Lvl => experienceView.Lvl;
        public string Text => text;


        private void Start()
        {
            randomSlimeButtonLogic = new(this);
        }

        public void OnClick()
        {
            randomSlimeButtonLogic.OnClick();
        }
    }
}
