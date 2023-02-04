using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;

namespace SlimeEvolutions.Panel.Statistics.Mutagen
{
    public class MutagenLogic:IActivatable
    {
        public MutagenView mutagenView;


        private MutagenInteractor MutInteractor
        {
            get
            {
                return Game.GetInteractor<MutagenInteractor>();
            }
        }


        public MutagenLogic(MutagenView mutagenView)
        {
            this.mutagenView = mutagenView;
        }


        private void UpdateMutagenText()
        {
            mutagenView.Text.text = $"{MutInteractor.Mutagen}";
        }

        private void UpdateMutagenText(int mut)
        {
            mutagenView.Text.text = $"{mut}";
        }

        public void OnEnable()
        {
            MutInteractor.DataUpdatedEvent += UpdateMutagenText;
            Game.OnGameInitializedEvent += UpdateMutagenText;
        }

        public void OnDisable()
        {
            MutInteractor.DataUpdatedEvent -= UpdateMutagenText;
            Game.OnGameInitializedEvent -= UpdateMutagenText;
        }
    }
}
