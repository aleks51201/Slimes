using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;

namespace SlimeEvolutions.Panel.Statistics.Mutagen
{
    public class MutagenLogic : IActivatable
    {
        private MutagenView mutagenView;
        private bool isInit;


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


        private void Init()
        {
            isInit = true;
            Game.OnGameInitializedEvent -= Init;
            Subscribe();
        }

        private void UpdateMutagenText()
        {
            mutagenView.Text.text = $"{MutInteractor.Mutagen}";
        }

        private void UpdateMutagenText(int mut)
        {
            mutagenView.Text.text = $"{mut}";
        }

        private void Subscribe()
        {
            MutInteractor.DataUpdatedEvent += UpdateMutagenText;
        }

        private void Unsubcribe()
        {
            MutInteractor.DataUpdatedEvent -= UpdateMutagenText;
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
                Unsubcribe();
            }
        }
    }
}
