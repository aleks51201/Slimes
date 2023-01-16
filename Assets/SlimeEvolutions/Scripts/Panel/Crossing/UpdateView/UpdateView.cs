using SlimeEvolutions.Architecture.CrossData;
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SlimeEvolutions.Panel.Crossing
{
    public class UpdateView
    {
        private CrossingSpaceData crossingSpaceData;


        public UpdateView()
        {

        }


        public void Initialize(int id)
        {
            crossingSpaceData = Game.GetInteractor<CrossingSpaceInteractor>().CrossingSpaces[id];
        }

        private void Upadate()
        {

        }
    }
}
