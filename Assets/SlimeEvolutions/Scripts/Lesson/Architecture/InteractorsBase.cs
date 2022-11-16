using SlimeEvolutions.Lesson.Scene;
using System;
using System.Collections.Generic;

namespace SlimeEvolutions.Lesson.Architecture
{
    public class InteractorsBase
    {
        private Dictionary<Type, Interactor> interactorsMap;
        private SceneConfig sceneConfig;

        public InteractorsBase(SceneConfig sceneConfig)
        {
            this.sceneConfig = sceneConfig;
        }

        public void CreateAllInteractors()
        {
            interactorsMap = sceneConfig.CreateAllInteractors();
        }

        public void SendOnCreateToAllInteractors()
        {
            var allInteractors = interactorsMap.Values;
            foreach (var interactors in allInteractors)
            {
                interactors.OnCreate();
            }
        }

        public void InitializeAllInteractors()
        {
            var allInteractors = interactorsMap.Values;
            foreach (var interactors in allInteractors)
            {
                interactors.Initialize();
            }
        }

        public void SendOnStartToAllInteractors()
        {
            var allInteractors = interactorsMap.Values;
            foreach (var interactors in allInteractors)
            {
                interactors.OnStart();
            }
        }

        public T GetInteractor<T>() where T : Interactor
        {
            var type = typeof(T);
            return (T)interactorsMap[type];
        }
    }
}
