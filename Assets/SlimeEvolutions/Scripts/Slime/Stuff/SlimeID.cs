using SlimeEvolutions.Architecture.Interactors.Instances;
using System;
using System.Collections.Generic;

namespace SlimeEvolutions
{
    public class SlimeID
    {
        public int GetUniqueId()
        {
            List<int> idArray = LoadSlimesId();
            int id = 0;
            if (idArray == null)
            {
                return id;
            }
            while (idArray.Contains(id))
            {
                id++;
            }
            return id;
        }

        private List<int> LoadSlimesId()
        {
            return GetSlimeId(SlimesInventory.Slimes);
        }

        public List<int> GetSlimeId(IEnumerable<Slime> slimeArray)
        {
            List<int> result = new();
            if (slimeArray == null)
            {
                return result;
            }
            foreach (Slime slime in slimeArray)
            {
                result.Add(slime.Id);
            }
            return result;
        }
    }


}
