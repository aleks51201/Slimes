using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Stuff;
using System;
using TMPro;

namespace SlimeEvolutions.Panel.Mutatron
{
    public class RandomSlimeButtonLogic:IActivatable
    {
        private RandomSlimeButtonView randomSlimeButtonView;


        public static Action OnRandomSlimeButtonClickEvent;


        public RandomSlimeButtonLogic(RandomSlimeButtonView randomSlimeButtonView)
        {
            this.randomSlimeButtonView = randomSlimeButtonView;
        }

        
        private Slime GenerateRandomSlime()
        {
            Slime slime = new();
            slime.RandomSlime();
            return slime;
        }

        private void SaveRandomSlime()
        {
            SaveSlimeData(GenerateRandomSlime());
            OnRandomSlimeButtonClickEvent?.Invoke();
        }

        private void SaveSlimeData(Slime slime)
        {
            SlimesInventory.AddSlime(this, slime);
            Game.GetInteractor<DailyTimeInteractor>().SetTime(DateTime.Now);
            Game.GetInteractor<MutagenInteractor>().SpendMutagen(CalcSlimeCost());
        }

        private bool CheckMutagenAmount(int mut)
        {
            return Game.GetInteractor<MutagenInteractor>().EnoughMutagen(mut);
        }

        private int CalcSlimeCost()
        {
            return (randomSlimeButtonView.Lvl + 1) * randomSlimeButtonView.MutagenMultiplier;
        }

        public void OnClick()
        {
            if (CheckMutagenAmount(CalcSlimeCost()))// сделать проверку на наличие бесплатной крутки или на достаточно ли монет для крутки
            {
                SaveRandomSlime();
            }
        }

        private void UpdateText()
        {
            randomSlimeButtonView.GetComponentInChildren<TextMeshProUGUI>().text = randomSlimeButtonView.Text + $"{CalcSlimeCost()}";
        }
        
        public void OnEnable()
        {
            UpdateText();
        }

        public void OnDisable()
        {
        }
    }
}
