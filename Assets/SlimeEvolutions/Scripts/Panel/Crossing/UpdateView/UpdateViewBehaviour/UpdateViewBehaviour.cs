using System;
using System.Collections.Generic;

namespace SlimeEvolutions.Panel.Crossing.Update.Behaviours
{
    public class UpdateViewBehaviour:IActivatable
    {
        private Dictionary<Type, IUpdateViewBehaviour> behavioursMap;
        private IUpdateViewBehaviour currentBehaviour;
        private UpdateView updateView;

        public UpdateViewBehaviour(UpdateView updateView)
        {
            this.updateView = updateView;
            InitializeBehaviour();
        }

        private void InitializeBehaviour()
        {
            behavioursMap = new();
            behavioursMap[typeof(MainBehaviour)] = new MainBehaviour();
            behavioursMap[typeof(CorrectInformationBehaviour)] = new CorrectInformationBehaviour();
            behavioursMap[typeof(IncorrectInformationBehaviour)] = new IncorrectInformationBehaviour();
            behavioursMap[typeof(TimeAvailableBehaviour)] = new TimeAvailableBehaviour();
            behavioursMap[typeof(TimeIsNotAvailableBehaviour)] = new TimeIsNotAvailableBehaviour();
        }

        private void SetBehaviour(IUpdateViewBehaviour newBehaviour)
        {
            if (currentBehaviour is not null)
            {
                currentBehaviour.Exit();
            }
            currentBehaviour = newBehaviour;
            currentBehaviour.Enter(updateView);
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

        public void SetCorrectInformationBehaviour()
        {
            SetBehaviour(GetBehaviour<CorrectInformationBehaviour>());
        }

        public void SetIncorrectInformationBehaviour()
        {
            SetBehaviour(GetBehaviour<IncorrectInformationBehaviour>());
        }

        public void SetTimeAvailableBehaviour()
        {
            SetBehaviour(GetBehaviour<TimeAvailableBehaviour>());
        }

        public void SetTimeIsNotAvailableBehaviour()
        {
            SetBehaviour(GetBehaviour<TimeIsNotAvailableBehaviour>());
        }
    }
}
