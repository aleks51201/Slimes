using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;

namespace SlimeEvolutions.Panel.Statistics.Experience
{
    public class ExperienceLogic : IActivatable
    {
        private ExperienceView experienceView;
        private bool isInit;


        private ExperienceInteractor ExpInteractor
        {
            get
            {
                return Game.GetInteractor<ExperienceInteractor>();
            }
        }


        public ExperienceLogic(ExperienceView expView)
        {
            experienceView = expView;
        }


        private void Init()
        {
            isInit = true;
            Game.OnGameInitializedEvent -= Init;
            Subscribe();
            UpdateMutagenText();
        }

        private void UpdateMutagenText()
        {
            UpdateMutagenText(ExpInteractor.Experience);
        }

        private void UpdateMutagenText(int exp)
        {
            int lvl = GetLvl();
            experienceView.Text.text = $"{lvl} ({exp % 50}/{lvl * 50})";
        }

        private int GetLvl()
        {
            return ExpInteractor.Experience / 50;
        }

        private void Subscribe()
        {
            ExpInteractor.DataUpdatedEvent += UpdateMutagenText;

        }

        private void Unsubscribe()
        {
            ExpInteractor.DataUpdatedEvent -= UpdateMutagenText;
        }
        public void OnEnable()
        {
            if (isInit)
            {
                Subscribe();
            }
            else
            {
                Game.OnGameInitializedEvent += Init;
            }
        }

        public void OnDisable()
        {
            if (isInit)
            {
                Unsubscribe();
            }
        }
    }
}
