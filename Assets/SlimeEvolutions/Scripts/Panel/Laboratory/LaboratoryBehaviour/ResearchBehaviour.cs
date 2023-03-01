using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using System;
using UnityEngine;

namespace SlimeEvolutions.Panel.Laboratory.Behaviours
{
    public class ResearchBehaviour : ILaboratoryBehaviour
    {
        private LaboratoryLogic labLogic;
        private bool isSubscribe;

        public void Enter(LaboratoryLogic laboratoryLogic)
        {
            labLogic = laboratoryLogic;
            Subscribe();
            ResearchSpaceUpdate();
            TimerStart();
            Debug.Log("ResearchBehaviour enter");
        }

        public void Exit()
        {
            Unsubscribe();
        }

        public void OnEnable()
        {
            UpdateTimerText();
            Subscribe();
            Debug.Log("ResearchBehaviour enable");
            ChangeBehaviour();
        }

        public void OnDisable()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            if (isSubscribe)
            {
                return;
            }
            TimerSubscribe();
            isSubscribe = true;
        }

        private void Unsubscribe()
        {
            if (!isSubscribe)
            {
                return;
            }
            TimerUnsubcribe();
            isSubscribe = false;
        }

        private void TimerStart()
        {
            float seconds = (float)(Game.GetInteractor<LaboratoryDataInteractor>().EndTimeResearch - DateTime.Now).TotalSeconds;
            labLogic.StartTimer(seconds);
            UpdateTimerText(seconds);
            TimerSubscribe();
        }

        private void TimerSubscribe()
        {
            if (labLogic.Timer is not null)
            {
                labLogic.Timer.OnTimerFinishedEvent += OnTimerFinished;
                labLogic.Timer.OnTimerFinishedEvent += labLogic.EndResearch;
                labLogic.Timer.OnTimerValueChangedEvent += labLogic.UpdateTimerText;
                Debug.Log("timer sub");
            }
        }

        private void TimerUnsubcribe()
        {
            if (labLogic.Timer is not null)
            {
                labLogic.Timer.OnTimerFinishedEvent -= OnTimerFinished;
                labLogic.Timer.OnTimerFinishedEvent -= labLogic.EndResearch;
                labLogic.Timer.OnTimerValueChangedEvent -= labLogic.UpdateTimerText;
                Debug.Log("timer unsub");
            }
        }

        public void OnTimerFinished()
        {
            labLogic.LaboratoryBehaviour.SetAfterResearchBehaviour();
        }

        private void ChangeBehaviour()
        {
                Debug.Log($"{Game.GetInteractor<LaboratoryDataInteractor>().EndTimeResearch} .... {DateTime.Now}");
                Debug.Log($"{Game.GetInteractor<LaboratoryDataInteractor>().EndTimeResearch < DateTime.Now}");
            if (Game.GetInteractor<LaboratoryDataInteractor>().EndTimeResearch < DateTime.Now)
            {
                labLogic.LaboratoryBehaviour.SetAfterResearchBehaviour();
            }
        }

        private void ResearchSpaceUpdate()
        {
            Slime researchingSlime = Game.GetInteractor<LaboratoryDataInteractor>().ResearchableSlime;
            labLogic.ResearchPlaceView.ResearchSpaceUpdate(this, researchingSlime);
        }

        private void UpdateTimerText(float seconds)
        {
            labLogic.UpdateTimerText(seconds);
        }

        private void UpdateTimerText()
        {
            float seconds = (float)(Game.GetInteractor<LaboratoryDataInteractor>().EndTimeResearch - DateTime.Now).TotalSeconds;
            UpdateTimerText(seconds);
        }

    }
}
