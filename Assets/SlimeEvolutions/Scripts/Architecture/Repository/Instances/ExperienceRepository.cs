namespace SlimeEvolutions.Architecture.Repositories.Instances
{
    public class ExperienceRepository : Repository
    {
        private Storage storage;


        public int Experience { get; set; }


        public override void Initialize()
        {
            storage = new();
            Experience = storage.Load().Experience;
        }

        public override void Save()
        {
            DataStruct data = storage.Load();
            data.Experience = Experience;
            storage.Save(data);
        }
    }
}
