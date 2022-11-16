using SlimeEvolutions.Lesson.Scene;
using System;
using System.Collections.Generic;

namespace SlimeEvolutions.Lesson.Architecture
{
    public class RepositoriesBase
    {

        private Dictionary<Type, Repository> repositoriesMap;
        private SceneConfig sceneConfig;

        public RepositoriesBase(SceneConfig sceneConfig)
        {
            this.sceneConfig = sceneConfig;
        }

        public void CreateAllRepositories()
        {
            repositoriesMap = sceneConfig.CreateAllRepositories();
        }

        public void SendOnCreateToAllRepositories()
        {
            var allRepositories = repositoriesMap.Values;
            foreach (var repositories in allRepositories)
            {
                repositories.OnCreate();
            }
        }

        public void InitializeAllRepositories()
        {
            var allRepositories = repositoriesMap.Values;
            foreach (var repositories in allRepositories)
            {
                repositories.Initialize();
            }
        }

        public void SendOnStartToAllRepositories()
        {
            var allRepositories = repositoriesMap.Values;
            foreach (var repositories in allRepositories)
            {
                repositories.OnStart();
            }
        }

        public T GetRepository<T>() where T : Repository
        {
            var type = typeof(T);
            return (T)repositoriesMap[type];
        }
    }
}
