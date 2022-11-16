using SlimeEvolutions.Lesson.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace SlimeEvolutions.Lesson.Scene
{
    public abstract class SceneManagerBase
    {
        public Scene Scene { get; private set; }
        public bool IsLoading { get; private set; }

        public Action<Scene> OnSceneLoadedEvent;

        protected Dictionary<string, SceneConfig> sceneConfigMap;

        public SceneManagerBase()
        {
            sceneConfigMap = new();
        }

        public abstract void InitSceneMap();

        public Coroutine LoadCurrentSceneAsync()
        {
            if (IsLoading)
            {
                throw new Exception($"this scene is loading now");
            }
            string sceneName = SceneManager.GetActiveScene().name;
            SceneConfig config = sceneConfigMap[sceneName];
            return Coroutines.StartRoutine(LoadCurrentSceneRoutine(config));
        }

        private IEnumerator LoadCurrentSceneRoutine(SceneConfig config)
        {
            IsLoading = true;
            yield return Coroutines.StartRoutine(InitializeSceneRoutine(config));
            IsLoading = false;
            OnSceneLoadedEvent?.Invoke(Scene);
        }

        public Coroutine LoadNewSceneAsync(string sceneName)
        {
            if (IsLoading)
            {
                throw new Exception($"{sceneName} this scene is loading now");
            }
            SceneConfig config = sceneConfigMap[sceneName];
            return Coroutines.StartRoutine(LoadNewSceneRoutine(config));
        }

        private IEnumerator LoadNewSceneRoutine(SceneConfig config)
        {
            IsLoading = true;
            yield return Coroutines.StartRoutine(LoadSceneRoutine(config));
            yield return Coroutines.StartRoutine(InitializeSceneRoutine(config));
            IsLoading = false;
            OnSceneLoadedEvent?.Invoke(Scene);
        }

        private IEnumerator LoadSceneRoutine(SceneConfig sceneConfig)
        {
            var async = SceneManager.LoadSceneAsync(sceneConfig.SceneName);
            async.allowSceneActivation = false;
            while (async.progress < 0.9f)
            {
                yield return null;
            }
            async.allowSceneActivation = true;
        }

        private IEnumerator InitializeSceneRoutine(SceneConfig sceneConfig)
        {
            Scene = new(sceneConfig);
            yield return Scene.InitializeAsync();
        }

        public T GetRepository<T>() where T : Repository
        {
            return Scene.GetRepository<T>();
        }

        public T GetInteractor<T>() where T : Interactor
        {
            return Scene.GetInteractor<T>();
        }
    }
}
