using SlimeEvolutions.Architecture.Scene.Instances;
using System;
using System.Collections;

namespace SlimeEvolutions.Architecture.Scene
{
    public static class Game
    {
        public static SceneManagerBase SceneManager { get; private set; }

        public static Action OnGameInitializedEvent;

        public static void Run()
        {
            SceneManager = new NewSceneManager();
            Coroutines.StartRoutine(InitializeGame());
        }

        private static IEnumerator InitializeGame()
        {
            SceneManager.InitializeSceneMap();
            yield return SceneManager.LoadCurrentSceneAsync();
            OnGameInitializedEvent?.Invoke();
        }

        public static T GetInteractor<T>() where T : Interactor
        {
            return SceneManager.GetInteractor<T>();
        }

        public static T GetRepository<T>() where T : Repository
        {
            return SceneManager.GetRepository<T>();
        }
    }
}
