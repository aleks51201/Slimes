using System;
using System.Collections.Generic;

namespace SlimeEvolutions.Panel.Crossing.Update.Behaviours
{
    public class LaboratoryBehaviour:IActivatable
    {
        private Dictionary<Type, IUpdateViewBehaviour> behavioursMap;
        private IUpdateViewBehaviour currentBehaviour;
        private LaboratoryLogic laboratoryLogic;

        public LaboratoryBehaviour(LaboratoryLogic laboratoryLogic)
        {
            this.laboratoryLogic = laboratoryLogic;
            InitializeBehaviour();
        }

        private void InitializeBehaviour()
        {
            behavioursMap = new();
            behavioursMap[typeof(MainBehaviour)] = new MainBehaviour();
            behavioursMap[typeof(SecondBehaviour)] = new SecondBehaviour();
            behavioursMap[typeof(ThirdBehaviour)] = new ThirdBehaviour();
        }

        private void SetBehaviour(IUpdateViewBehaviour newBehaviour)
        {
            if (currentBehaviour is not null)
            {
                currentBehaviour.Exit();
            }
            currentBehaviour = newBehaviour;
            currentBehaviour.Enter(laboratoryLogic);
        }

        private IUpdateViewBehaviour GetBehaviour<T>() where T : IUpdateViewBehaviour
        {
            return behavioursMap[typeof(T)];
        }
        public void OnEnable()
        {
            currentBehaviour.OnEnable();
        }

        public void OnDisable()
        {
            currentBehaviour.OnDisable();
        }

        public void SetBehaviourByDefault()
        {
            SetMainBehaviour();
        }

        public void SetMainBehaviour()
        {
            SetBehaviour(GetBehaviour<MainBehaviour>());
        }

        public void SetResearchBehaviour()
        {
            SetBehaviour(GetBehaviour<SecondBehaviour>());
        }

        public void SetAfterResearchBehaviour()
        {
            SetBehaviour(GetBehaviour<ThirdBehaviour>());
        }
    }
}
