using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Stuff;

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
            if(lvl == 0)
            {
                experienceView.Text.text = $"{lvl} ({exp % experienceView.LvlMultiplier}/{experienceView.LvlMultiplier})";
                return;
            }
            experienceView.Text.text = $"{lvl} ({exp - GetProgressionExp(lvl)}/{experienceView.LvlMultiplier * lvl})";
        }

        private int GetLvl()
        {
            return ProgressionCalculator.CalcTotalLvlForExp(ExpInteractor.Experience, experienceView.LvlMultiplier);
        }

        private int GetProgressionExp(int lvl)
        {
            return ProgressionCalculator.CalcTotalExpForLvl(1, lvl, experienceView.LvlMultiplier);
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
