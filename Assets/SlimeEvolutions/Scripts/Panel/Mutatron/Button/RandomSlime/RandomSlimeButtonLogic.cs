using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using System;


namespace SlimeEvolutions.Panel.Mutatron
{
    public class RandomSlimeButtonLogic
    {

        public static Action OnRandomSlimeButtonClickEvent;

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
        }

        private bool CheckMutagenAmount(int mut)
        {
            return Game.GetInteractor<MutagenInteractor>().EnoughMutagen(mut);
        }

        public void OnClick()
        {
            if (true)// сделать проверку на наличие бесплатной крутки или на достаточно ли монет для крутки
            {
                SaveRandomSlime();
            }
        }
    }
}
