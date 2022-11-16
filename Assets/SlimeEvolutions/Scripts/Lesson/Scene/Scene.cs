using SlimeEvolutions.Lesson.Architecture;
using System.Collections;
using UnityEngine;


namespace SlimeEvolutions.Lesson.Scene
{
    public class Scene
    {
        private InteractorsBase interactorsBase;
        private RepositoriesBase repositoriesBase;
        private SceneConfig sceneConfig;

        public Scene(SceneConfig sceneConfig)
        {
            this.sceneConfig = sceneConfig;
            interactorsBase = new(sceneConfig);
            repositoriesBase = new(sceneConfig);
        }

        public Coroutine InitializeAsync()
        {
            return Coroutines.StartRoutine(InitializeRoutine());
        }

        private IEnumerator InitializeRoutine()
        {
            interactorsBase.CreateAllInteractors();
            repositoriesBase.CreateAllRepositories();
            yield return null;

            interactorsBase.SendOnCreateToAllInteractors();
            repositoriesBase.SendOnCreateToAllRepositories();
            yield return null;

            interactorsBase.InitializeAllInteractors();
            repositoriesBase.InitializeAllRepositories();
            yield return null;

            interactorsBase.SendOnStartToAllInteractors();
            repositoriesBase.SendOnStartToAllRepositories();
            yield return null;
        }

        public T GetRepository<T>() where T : Repository
        {
            return repositoriesBase.GetRepository<T>();
        }

        public T GetInteractor<T>() where T : Interactor
        {
            return interactorsBase.GetInteractor<T>();
        }
    }
}
