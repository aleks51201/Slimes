using SlimeEvolutions.Architecture.CrossData;
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Panel.Crossing.Update.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SlimeEvolutions.Panel.Crossing
{
    public class UpdateView: IActivatable
    {
        private UpdateViewBehaviour updateViewBehaviour;
        private CrossingSpaceData crossingSpaceData;


        public CrossingSpaceData CrossingSpaceData => crossingSpaceData;


        public UpdateView()
        {

        }


        public void Initialize(int id)
        {
            crossingSpaceData = Game.GetInteractor<CrossingSpaceInteractor>().CrossingSpaces[id];
            updateViewBehaviour.SetBehaviourByDefault();
        }

        private void Upadate()
        {

        }

        public void OnEnable()
        {
            updateViewBehaviour.OnEnable();
        }

        public void OnDisable()
        {
            updateViewBehaviour.OnDisable();
        }
    }
}
