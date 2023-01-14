using SlimeEvolutions.Architecture.CrossData;
using SlimeEvolutions.Architecture.Repositories.Instances;
using SlimeEvolutions.Architecture.Scene;
using System;
using System.Collections.Generic;

namespace SlimeEvolutions.Architecture.Interactors.Instances
{
    public class CrossingSpaceInteractor : Interactor
    {
        private CrossingPlaceRepository crossRepos;
        private int countSlots;


        public List<CrossingSpaceData> CrossingSpaces => crossRepos.crossingData.CrossingSpaces;
        public int CountSlots
        {
            get
            {
                return countSlots;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("The number of slots can't be less than one");
                }
                countSlots = value;
            }
        }


        public static Action OnDataChangedEvent;


        public override void OnCreate()
        {
            crossRepos = Game.GetRepository<CrossingPlaceRepository>();
        }

        public override void OnStart()
        {
            CreateCrossingData();
            CreateSpacesList();
        }

        private void CreateCrossingData()
        {
            if (crossRepos.crossingData is not null)
            {
                return;
            }
            crossRepos.crossingData = new();
            crossRepos.Save();
        }

        public void CreateSpacesList()
        {
            if (crossRepos.crossingData.CrossingSpaces is not null)
            {
                return;
            }
            crossRepos.crossingData.CrossingSpaces = new();
            for (int i = 0; i < countSlots; i++)
            {
                crossRepos.crossingData.CrossingSpaces.Add(new CrossingSpaceData(true));
            }
            crossRepos.Save();
        }

        public void SetCrossingSpaceData(int id, CrossingSpaceData crossingSpaceData)
        {
            crossRepos.crossingData.CrossingSpaces[id] = crossingSpaceData;
            crossRepos.Save();
            OnDataChangedEvent?.Invoke();
        }

        public void SetStatusTaken(int id)
        {
            crossRepos.crossingData.CrossingSpaces[id].HasBeenSlimeTaken = true;
            crossRepos.Save();
        }

        public bool AreThereAnySlotsAvailable()
        {
            for (int i = 0; i < countSlots; i++)
            {
                return IsSlotEmpty(CrossingSpaces[i]);
            }
            return false;
        }

        private bool IsSlotEmpty(CrossingSpaceData crossingSpaceData)
        {
            if (crossingSpaceData is null)
            {
                return true;
            }
            if (crossingSpaceData.HasBeenSlimeTaken)
            {
                return true;
            }
            return false;
        }

        public int GetEmptySlotId()
        {
            if (!AreThereAnySlotsAvailable())
            {
                throw new Exception("Can't get slot id because there are no free slots");
            }
            int result = 0;
            foreach (CrossingSpaceData crossingSpaceData in CrossingSpaces)
            {
                if (IsSlotEmpty(crossingSpaceData))
                {
                    return result;
                }
                result++;
            }
            return result;
        }
    }
}
