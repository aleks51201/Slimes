using System.Collections.Generic;

namespace SlimeEvolutions.Architecture.Repositories.Instances
{
    public class SlimeRepository : Repository
    {
        private Storage storage;

        public List<Slime> Slimes { get; set; }

        public override void Initialize()
        {
            storage = new();
            Slimes = storage.Load().InventorySlimes;
        }

        public override void Save()
        {
            DataStruct data = storage.Load();
            data.InventorySlimes = Slimes;
            storage.Save(data);
        }
    }
}
