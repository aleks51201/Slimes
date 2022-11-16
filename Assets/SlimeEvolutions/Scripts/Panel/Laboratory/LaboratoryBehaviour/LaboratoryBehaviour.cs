using System;
using System.Collections.Generic;

namespace SlimeEvolutions.Panel.Laboratory.Behaviours
{
    public class LaboratoryBehaviour:IActivatable
    {
        private Dictionary<Type, ILaboratoryBehaviour> behavioursMap;
        private ILaboratoryBehaviour currentBehaviour;
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
            behavioursMap[typeof(ResearchBehaviour)] = new ResearchBehaviour();
            behavioursMap[typeof(AfterResearchBehaviour)] = new AfterResearchBehaviour();
        }

        private void SetBehaviour(ILaboratoryBehaviour newBehaviour)
        {
            if (currentBehaviour is not null)
            {
                currentBehaviour.Exit();
            }
            currentBehaviour = newBehaviour;
            currentBehaviour.Enter(laboratoryLogic);
        }

        private ILaboratoryBehaviour GetBehaviour<T>() where T : ILaboratoryBehaviour
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
            SetBehaviour(GetBehaviour<ResearchBehaviour>());
        }

        public void SetAfterResearchBehaviour()
        {
            SetBehaviour(GetBehaviour<AfterResearchBehaviour>());
        }
    }
}
