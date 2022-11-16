using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SlimeEvolutions.Architecture.Interactors.Instances
{
    public static class SlimesInventory
    {
        private static SlimeInteractor slimeInteractor;

        public static Slime[] Slimes { get { CheckInitialize(); return slimeInteractor.Slimes; } }
        public static bool IsInitialize { get; private set; }

        public static Action OnSlimeInteractorFacadeInitializedEvent;

        public static void Initialize(SlimeInteractor slimeInteractor)
        {
            SlimesInventory.slimeInteractor = slimeInteractor;
            IsInitialize = true;
            OnSlimeInteractorFacadeInitializedEvent?.Invoke();
        }

        public static void AddSlime(object sender, Slime slime)
        {
            CheckInitialize();
            slimeInteractor.AddSlime(sender, slime);
        }

        public static void RemoveSlime(object sender, Slime slime)
        {
            CheckInitialize();
            slimeInteractor.RemoveSlime(sender, slime);
        }

        public static void RemoveSlime(object sender, List<Slime> slimes)
        {
            CheckInitialize();
            slimeInteractor.RemoveSlime(sender, slimes);
        }

        public static bool SlimeExists(object sender, Slime slime)
        {
            CheckInitialize();
            return slimeInteractor.SlimeExists(sender, slime);
        }

        private static void CheckInitialize()
        {
            if (!IsInitialize)
                throw new NullReferenceException("SlimeInteractor is't initialize");
        }
    }
}
