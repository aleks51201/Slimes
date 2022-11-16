using SlimeEvolutions.Lesson.Scene;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SlimeEvolutions.Architecture.Scene
{
    public abstract class SceneManagerBase
    {
        private protected Dictionary<string, SceneConfig> sceneConfigMap;

        public Scene Scene { get; private set; }
        public bool IsLoading { get; private set; }

        public Action<Scene> OnSceneLoadedEvent;

        public SceneManagerBase()
        {
            sceneConfigMap = new();
        }

        public abstract void InitializeSceneMap();

        public Coroutine LoadCurrentSceneAsync()
        {
            if (IsLoading)
            {
                throw new Exception("This scene is loading now");
            }
            string nameScene = SceneManager.GetActiveScene().name;
            SceneConfig config = sceneConfigMap[nameScene];
            return Coroutines.StartRoutine(LoadCurrenSceneRoutine(config));
        }

        public Coroutine LoadNewSceneAsync(string sceneName)
        {
            if (IsLoading)
            {
                throw new Exception("This scene is loading now");
            }
            SceneConfig config = sceneConfigMap[sceneName];
            return Coroutines.StartRoutine(LoadNewSceneRoutine(config));
        }

        private IEnumerator LoadCurrenSceneRoutine(SceneConfig config)
        {
            IsLoading = false;
            yield return Coroutines.StartRoutine(InitializeSceneRoutine(config));
            IsLoading = true;
            OnSceneLoadedEvent?.Invoke(Scene);
        }

        private IEnumerator LoadNewSceneRoutine(SceneConfig config)
        {
            IsLoading = false;
            yield return Coroutines.StartRoutine(LoadSceneRoutine(config));
            yield return Coroutines.StartRoutine(InitializeSceneRoutine(config));
            IsLoading = true;
            OnSceneLoadedEvent?.Invoke(Scene);
        }

        private IEnumerator LoadSceneRoutine(SceneConfig config)
        {
            AsyncOperation async = SceneManager.LoadSceneAsync(config.SceneName);
            async.allowSceneActivation = false;
            while (async.progress < 0.9f)
            {
                yield return null;
            }
            async.allowSceneActivation = true;
        }

        private IEnumerator InitializeSceneRoutine(SceneConfig config)
        {
            Scene = new(config);
            yield return Scene.InitializeAsync();
        }

        public T GetInteractor<T>() where T : Interactor
        {
            return Scene.GetInteractor<T>();
        }

        public T GetRepository<T>() where T : Repository
        {
            return Scene.GetRepository<T>();
        }
    }
}
