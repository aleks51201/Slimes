using SlimeEvolutions.Architecture.Repositories.Instances;
using SlimeEvolutions.Architecture.Scene;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SlimeEvolutions.Architecture.Interactors.Instances
{
    public class SlimeInteractor : Interactor
    {
        private SlimeRepository slimeRepository;

        public Slime[] Slimes => slimeRepository.Slimes.ToArray();

        public static Action OnDataChangedEvent;

        public override void OnCreate()
        {
            slimeRepository = Game.GetRepository<SlimeRepository>();
        }

        public override void Initialize()
        {
            SlimesInventory.Initialize(this);
        }

        public void AddSlime(object sender, Slime slime)
        {
            CheckSlime(sender, slime);
            slimeRepository.Slimes.Add(slime);
            slimeRepository.Save();
            OnDataChangedEvent?.Invoke();
        }

        public void RemoveSlime(object sender, Slime slime)
        {
            CheckSlime(sender, slime);
            foreach (Slime sl in slimeRepository.Slimes)
            {
                if (slime.Id == sl.Id)
                {
                    slimeRepository.Slimes.Remove(sl);
                    break;
                }
            }
            slimeRepository.Save();
            OnDataChangedEvent?.Invoke();
        }

        public void RemoveSlime(object sender, List<Slime> slimes)
        {
            foreach (Slime slime in slimes)
            {
                RemoveSlime(sender, slime);
            }
        }

        public bool SlimeExists(object sender, Slime slime)
        {
            CheckSlime(sender, slime);
            foreach (Slime sl in slimeRepository.Slimes)
            {
                if (slime.Id == sl.Id)
                {
                    return true;
                }
            }
            return false;
        }

        private void CheckSlime(object sender, Slime slime)
        {
            if (slime == null)
                throw new NullReferenceException($"Slime {slime} is null, sender {sender}");
        }
    }
}
