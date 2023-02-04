using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;

namespace SlimeEvolutions.Panel.Statistics.Experience
{
    public class ExperienceLogic:IActivatable
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
            experienceView.Text.text = $"{ExpInteractor.Experience}";
        }

        private void UpdateMutagenText(int exp)
        {
            experienceView.Text.text = $"{exp}";
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
