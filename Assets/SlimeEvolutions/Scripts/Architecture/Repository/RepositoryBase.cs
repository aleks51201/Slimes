using SlimeEvolutions.Architecture.Scene;
using System;
using System.Collections.Generic;

namespace SlimeEvolutions.Architecture.Repositories
{
    public class RepositoryBase
    {
        private Dictionary<Type, Repository> repositoriesMap;
        private SceneConfig sceneConfig;

        public RepositoryBase(SceneConfig config)
        {
            sceneConfig = config;
        }

        public void CreateAllRepositories()
        {
            repositoriesMap = sceneConfig.CreateAllRepositories();
        }

        public void SendOnCreateAllRepositories()
        {
            foreach (Repository repository in repositoriesMap.Values)
            {
                repository.OnCreate();
            }
        }

        public void InitializeAllRepositories()
        {
            foreach (Repository repository in repositoriesMap.Values)
            {
                repository.Initialize();
            }
        }

        public void SendOnStartAllRepositories()
        {
            foreach (Repository repository in repositoriesMap.Values)
            {
                repository.OnStart();
            }
        }

        public T GetRepositories<T>() where T : Repository
        {
            return (T)repositoriesMap[typeof(T)];
        }
    }
}
