namespace SlimeEvolutions.Architecture.Repositories.Instances
{
    public class LaboratoryDataRepository : Repository
    {
        private Storage storage;

        public LaboratoryData LabData { get; set; }

        public override void Initialize()
        {
            storage = new();
            LabData = storage.Load().LaboratoryData;
        }

        public override void Save()
        {
            DataStruct dataStruct = storage.Load();
            dataStruct.LaboratoryData = LabData;
            storage.Save(dataStruct);
        }
    }
}
