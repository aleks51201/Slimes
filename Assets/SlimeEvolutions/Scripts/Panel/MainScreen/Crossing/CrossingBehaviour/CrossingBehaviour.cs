using System;
using System.Collections.Generic;

namespace SlimeEvolutions.Panel.Crossing.Behaviour
{
    public class CrossingBehaviour : IActivatable
    {
        private Dictionary<Type, ICrossingBehaviour> behaviourMap;
        private ICrossingBehaviour currentBehaviour;
        private CrossPlaceLogic crossPlaceLogic;

        public CrossingBehaviour(CrossPlaceLogic crossPlaceLogic)
        {
            this.crossPlaceLogic = crossPlaceLogic;
            InitializeBehaviour();
            SetBehaviourByDefault();
        }

        private void InitializeBehaviour()
        {
            behaviourMap = new();
            behaviourMap[typeof(MainBehaviour)] = new MainBehaviour();
        }

        private void SetBehaviour<T>() where T : ICrossingBehaviour
        {
            if (currentBehaviour != null)
            {
                currentBehaviour.Exit();
            }
            currentBehaviour = GetBehaviour<T>();
            currentBehaviour.Enter(crossPlaceLogic);
        }

        private ICrossingBehaviour GetBehaviour<T>() where T : ICrossingBehaviour
        {
            return behaviourMap[typeof(T)];
        }

        private void SetBehaviourByDefault()
        {
            SetMainBehaviour();
        }

        private void SetMainBehaviour()
        {
            SetBehaviour<MainBehaviour>();
        }

        public void OnEnable()
        {
            currentBehaviour.OnEnable();
        }

        public void OnDisable()
        {
            currentBehaviour.OnDisable();
        }
    }
}
