using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Repositories.Instances;
using System;
using System.Collections.Generic;

namespace SlimeEvolutions.Architecture.Scene
{
    public class NewConfig : SceneConfig
    {
        public const string SCENE_NAME = "MainScene";
        public override string SceneName => SCENE_NAME;

        public override Dictionary<Type, Repository> CreateAllRepositories()
        {
            Dictionary<Type, Repository> repositoriesMap = new();
            CreateRepository<SlimeRepository>(repositoriesMap);
            CreateRepository<DailyTimeRepository>(repositoriesMap);
            CreateRepository<LaboratoryDataRepository>(repositoriesMap);
            CreateRepository<ExperienceRepository>(repositoriesMap);
            CreateRepository<MutagenRepository>(repositoriesMap);
            return repositoriesMap;
        }

        public override Dictionary<Type, Interactor> CreateAllInteractors()
        {
            Dictionary<Type, Interactor> interactorsMap = new();
            CreateInteractor<SlimeInteractor>(interactorsMap);
            CreateInteractor<DailyTimeInteractor>(interactorsMap);
            CreateInteractor<LaboratoryDataInteractor>(interactorsMap);
            CreateInteractor<ExperienceInteractor>(interactorsMap);
            CreateInteractor<MutagenInteractor>(interactorsMap);
            return interactorsMap;
        }
    }
}
