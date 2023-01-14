namespace SlimeEvolutions.Architecture.Repositories.Instances
{
    public class CrossingPlaceRepository : Repository
    {
        private Storage storage;

        public CrossingData crossingData { get; set; }

        public override void Initialize()
        {
            storage = new();
            crossingData = storage.Load().CrossingData;
        }

        public override void Save()
        {
            DataStruct dataStruct = storage.Load();
            dataStruct.CrossingData = crossingData;
            storage.Save(dataStruct);
        }
    }
}
