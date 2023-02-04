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

        public void OnEnable()
        {
        }

        public void OnDisable()
        {
        }
    }
}
