using SlimeEvolutions.Lesson.Scene;
using System;
using System.Collections;


namespace SlimeEvolutions.Lesson.Architecture.Banks
{
    public static class Game
    {
        public static SceneManagerBase SceneManager { get; private set; }

        public static Action OnGameInitializedEvent;

        public static void Run()
        {
            SceneManager = new SceneManagerExample();
            Coroutines.StartRoutine(InitializeGameRoutine());
        }

        private static IEnumerator InitializeGameRoutine()
        {
            SceneManager.InitSceneMap();
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
