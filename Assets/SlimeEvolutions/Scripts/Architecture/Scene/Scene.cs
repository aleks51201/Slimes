using SlimeEvolutions.Architecture.Interactors;
using SlimeEvolutions.Architecture.Repositories;
using System.Collections;
using UnityEngine;

namespace SlimeEvolutions.Architecture.Scene
{
    public class Scene
    {
        private RepositoryBase repositoriesBase;
        private InteractorsBase interactorsBase;
        private SceneConfig sceneConfig;

        public Scene(SceneConfig config)
        {
            sceneConfig = config;
            repositoriesBase = new(config);
            interactorsBase = new(config);
        }

        public Coroutine InitializeAsync()
        {
            return Coroutines.StartRoutine(InitializeRoutine());
        }

        private IEnumerator InitializeRoutine()
        {
            repositoriesBase.CreateAllRepositories();
            interactorsBase.CreateAllInteractors();
            yield return null;
            repositoriesBase.SendOnCreateAllRepositories();
            interactorsBase.SendOnCreateAllInteractors();
            yield return null;
            repositoriesBase.InitializeAllRepositories();
            interactorsBase.InitializeAllInteractors();
            yield return null;
            repositoriesBase.SendOnStartAllRepositories();
            interactorsBase.SendOnStartAllInteractors();
            yield return null;
        }

        public T GetRepository<T>() where T : Repository
        {
            return repositoriesBase.GetRepositories<T>();
        }

        public T GetInteractor<T>() where T : Interactor
        {
            return interactorsBase.GetInteractor<T>();
        }
    }
}
