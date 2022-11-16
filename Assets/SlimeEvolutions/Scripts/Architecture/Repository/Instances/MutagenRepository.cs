using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeEvolutions.Architecture.Repositories.Instances
{
    public class MutagenRepository : Repository
    {
        private Storage storage;

        public int Mutagen{ get; set; }

        public override void Initialize()
        {
            storage = new();
            Mutagen= storage.Load().Mutagen;
        }

        public override void Save()
        {
            DataStruct data = storage.Load();
            data.Mutagen = Mutagen;
            storage.Save(data);
        }
    }
}
