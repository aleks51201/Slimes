using SlimeEvolutions.Architecture.Repositories.Instances;
using SlimeEvolutions.Architecture.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeEvolutions.Architecture.Interactors.Instances
{
    public class MutagenInteractor : Interactor
    {
        private MutagenRepository mutagenRepository;

        public int Mutagen=> mutagenRepository.Mutagen;

        public override void OnCreate()
        {
            mutagenRepository= Game.GetRepository<MutagenRepository>();
        }

        public void AddMutagen(int mut)
        {
            if (mut< 0)
            {
                throw new ArgumentOutOfRangeException("mutagen can't be negative");
            }
            mutagenRepository.Mutagen += mut;
        }

        public void SpendMutagen(int mut)
        {
            if (mut< 0)
            {
                throw new ArgumentOutOfRangeException("mutagen can't be negative");
            }
            if (!EnoughMutagen(mut))
            {
                throw new ArgumentOutOfRangeException("mutagen is not enough");
            }
            mutagenRepository.Mutagen -= mut;
        }

        public bool EnoughMutagen(int mut)
        {
            return mutagenRepository.Mutagen >= mut;
        }
    }
}
