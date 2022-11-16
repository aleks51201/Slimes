using SlimeEvolutions.Architecture.Scene;
using System;
using System.Collections.Generic;

namespace SlimeEvolutions.Architecture.Interactors
{
    public class InteractorsBase
    {
        private Dictionary<Type, Interactor> interactorsMap;
        private SceneConfig sceneConfig;

        public InteractorsBase(SceneConfig config)
        {
            sceneConfig = config;
        }

        public void CreateAllInteractors()
        {
            interactorsMap = sceneConfig.CreateAllInteractors();
        }

        public void SendOnCreateAllInteractors()
        {
            foreach (Interactor interactor in interactorsMap.Values)
            {
                interactor.OnCreate();
            }
        }

        public void InitializeAllInteractors()
        {
            foreach (Interactor interactor in interactorsMap.Values)
            {
                interactor.Initialize();
            }
        }

        public void SendOnStartAllInteractors()
        {
            foreach (Interactor interactor in interactorsMap.Values)
            {
                interactor.OnStart();
            }
        }

        public T GetInteractor<T>() where T : Interactor
        {
            return (T)interactorsMap[typeof(T)];
        }
    }
}
