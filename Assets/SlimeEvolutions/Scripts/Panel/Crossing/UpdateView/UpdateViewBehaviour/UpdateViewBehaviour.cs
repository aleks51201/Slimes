using System;
using System.Collections.Generic;

namespace SlimeEvolutions.Panel.Crossing.Update.Behaviours
{
    public class UpdateViewBehaviour:IActivatable
    {
        private Dictionary<Type, IUpdateViewBehaviour> behavioursMap;
        private IUpdateViewBehaviour currentBehaviour;
        private LaboratoryLogic laboratoryLogic;

        public UpdateViewBehaviour(LaboratoryLogic laboratoryLogic)
        {
            this.laboratoryLogic = laboratoryLogic;
            InitializeBehaviour();
        }

        private void InitializeBehaviour()
        {
            behavioursMap = new();
            behavioursMap[typeof(MainBehaviour)] = new MainBehaviour();
            behavioursMap[typeof(CorrectInformationBehaviour)] = new CorrectInformationBehaviour();
            behavioursMap[typeof(IncorrectIformationBehaviour)] = new IncorrectIformationBehaviour();
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
            SetBehaviour(GetBehaviour<CorrectInformationBehaviour>());
        }

        public void SetAfterResearchBehaviour()
        {
            SetBehaviour(GetBehaviour<IncorrectIformationBehaviour>());
        }
    }
}
