using SlimeEvolutions.Lesson.Architecture;
using SlimeEvolutions.Lesson.Architecture.Banks;
using System;
using System.Collections.Generic;


namespace SlimeEvolutions.Lesson.Scene
{
    public class SceneConfigExample : SceneConfig
    {
        public const string SCENE_NAME = "";

        public override string SceneName => SCENE_NAME;

        public override Dictionary<Type, Interactor> CreateAllInteractors()
        {
            Dictionary<Type, Interactor> interactorsMap = new();
            CreateInteractor<BankInteractor>(interactorsMap);
            return interactorsMap;
        }

        public override Dictionary<Type, Repository> CreateAllRepositories()
        {
            Dictionary<Type, Repository> repositoriesMap = new();
            CreateRepository<BankRepository>(repositoriesMap);
            return repositoriesMap;
        }
    }
}
