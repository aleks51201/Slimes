﻿using Assets.Scripts;
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Panel.Laboratory;
using SlimeEvolutions.Panel.Laboratory.Behaviours;
using SlimeEvolutions.Timers;
using System;

namespace SlimeEvolutions.Panel
{
    public class LaboratoryLogic : IActivatable
    {
        private LaboratoryView laboratoryView;
        private LaboratoryDataInteractor labInteract;
        private LaboratoryBehaviour labBehaviour;
        private Timer timer;


        public LaboratoryBehaviour LaboratoryBehaviour => labBehaviour;
        public LaboratoryView LaboratoryView => laboratoryView;
        public ResearchPlaceView ResearchPlaceView => laboratoryView.ResearchPlace;
        public BackButton BackButton => laboratoryView.BackButton;
        public Timer Timer => timer;
        private LaboratoryDataInteractor LabInteract
        {
            get
            {
                if (labInteract is null)
                {
                    labInteract = Game.GetInteractor<LaboratoryDataInteractor>();
                }
                return labInteract;
            }
        }
        public float Seconds => laboratoryView.ResearchTimeInMinutes * 60;
        public double ResearchTimeInMinutes => laboratoryView.ResearchTimeInMinutes;


        public static Action StartResearchSlimeEvent;
        public static Action EndResearchSlimeEvent;


        public LaboratoryLogic(LaboratoryView laboratoryView)
        {
            this.laboratoryView = laboratoryView;
            labBehaviour = new(this);
            labBehaviour.SetBehaviourByDefault();
        }


        private Slime GetResearchableSlime()
        {
            return ResearchPlaceView.Slime;
        }

        private void SetTrueSlimeResearch(Slime slime)
        {
            slime.IsExplored = true;
        }

        public void StartResearch()
        {
            RemoveSlimeFromInventoryData();
            SaveResearchableSlime();
            StartResearchSlimeEvent?.Invoke();
        }

        public void StartTimer(float seconds)
        {
            timer = new(TimerTypes.OneSecTick, seconds);
            timer.Start();
        }

        private void SaveResearchableSlime()
        {
            LabInteract.SetResearchableSlime(this, GetResearchableSlime(), DateTime.Now.AddMinutes(ResearchTimeInMinutes));
            labInteract.SetStatusTake(false);
        }

        private void RemoveSlimeFromInventoryData()
        {
            SlimesInventory.RemoveSlime(this, GetResearchableSlime());
        }

        public void UpdateTimerText(float seconds)
        {
            var time = TimeSpan.FromSeconds(seconds);
            laboratoryView.Text.text = $"{time:mm}:{time:ss}";
        }

        public void UpdateTextOnButton(string str)
        {
            laboratoryView.Text.text = $"{str}";
        }

        public void EndResearch()
        {
            SetTrueSlimeResearch(LabInteract.ResearchableSlime);
            EndResearchSlimeEvent?.Invoke();
        }

        public void OnEnable()
        {
            labBehaviour.OnEnable();
        }

        public void OnDisable()
        {
            labBehaviour.OnDisable();
        }
    }
}
