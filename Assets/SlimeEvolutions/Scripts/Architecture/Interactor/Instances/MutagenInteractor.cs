using SlimeEvolutions.Architecture.Repositories.Instances;
using SlimeEvolutions.Architecture.Scene;
using System;

namespace SlimeEvolutions.Architecture.Interactors.Instances
{
    public class MutagenInteractor : Interactor
    {
        private MutagenRepository mutagenRepository;


        public int Mutagen => mutagenRepository.Mutagen;


        public Action<int> DataUpdatedEvent;


        public override void OnCreate()
        {
            mutagenRepository = Game.GetRepository<MutagenRepository>();
        }

        public void AddMutagen(int mut)
        {
            if (mut < 0)
            {
                throw new ArgumentOutOfRangeException("mutagen can't be negative");
            }
            mutagenRepository.Mutagen += mut;
            mutagenRepository.Save();
            DataUpdatedEvent?.Invoke(Mutagen);
        }

        public void SpendMutagen(int mut)
        {
            if (mut < 0)
            {
                throw new ArgumentOutOfRangeException("mutagen can't be negative");
            }
            if (!EnoughMutagen(mut))
            {
                throw new ArgumentOutOfRangeException("mutagen is not enough");
            }
            mutagenRepository.Mutagen -= mut;
            mutagenRepository.Save();
            DataUpdatedEvent?.Invoke(Mutagen);
        }

        public bool EnoughMutagen(int mut)
        {
            return mutagenRepository.Mutagen >= mut;
        }
    }
}
