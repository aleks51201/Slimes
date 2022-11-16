using System;
using System.Collections.Generic;

namespace SlimeEvolutions.Architecture.Scene
{
    public abstract class SceneConfig
    {
        public abstract Dictionary<Type, Repository> CreateAllRepositories();
        public abstract Dictionary<Type, Interactor> CreateAllInteractors();

        public abstract string SceneName { get; }

        public void CreateRepository<T>(Dictionary<Type, Repository> repositoriesMap) where T : Repository, new()
        {
            repositoriesMap[typeof(T)] = new T();
        }

        public void CreateInteractor<T>(Dictionary<Type, Interactor> interactorsMap) where T : Interactor, new()
        {
            interactorsMap[typeof(T)] = new T();
        }
    }
}
