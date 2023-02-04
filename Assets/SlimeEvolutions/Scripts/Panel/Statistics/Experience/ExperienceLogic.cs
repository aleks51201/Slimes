using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;

namespace SlimeEvolutions.Panel.Statistics.Experience
{
    public class ExperienceLogic:IActivatable
    {
        private ExperienceView experienceView;


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

        private void UpdateMutagenText()
        {
            experienceView.Text.text = $"{ExpInteractor.Experience}";
        }

        private void UpdateMutagenText(int exp)
        {
            experienceView.Text.text = $"{exp}";
        }

        public void OnEnable()
        {
            ExpInteractor.DataUpdatedEvent += UpdateMutagenText;
            Game.OnGameInitializedEvent += UpdateMutagenText;
        }

        public void OnDisable()
        {
            ExpInteractor.DataUpdatedEvent += UpdateMutagenText;
            Game.OnGameInitializedEvent -= UpdateMutagenText;
        }
    }
}
