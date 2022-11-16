using System;

namespace SlimeEvolutions.Architecture.Repositories.Instances
{
    public class DailyTimeRepository : Repository
    {
        private Storage storage;

        public DateTime DailyTime { get; set; }

        public override void Initialize()
        {
            storage = new();
            DailyTime = storage.Load().LastDateTime;
        }

        public override void Save()
        {
            DataStruct data = storage.Load();
            data.LastDateTime = DailyTime;
            storage.Save(data);
        }
    }
}
