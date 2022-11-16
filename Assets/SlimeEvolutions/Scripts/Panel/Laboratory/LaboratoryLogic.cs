using Assets.Scripts;
using SlimeEvolutions.Architecture;
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Panel.Laboratory;
using SlimeEvolutions.Panel.Laboratory.Behaviours;
using System;
using System.Collections;

namespace SlimeEvolutions.Panel
{
    public class LaboratoryLogic : IActivatable
    {
        private LaboratoryView laboratoryView;
        private LaboratoryDataInteractor labInteract;
        private LaboratoryBehaviour labBehaviour;

        public LaboratoryBehaviour LaboratoryBehaviour => labBehaviour;
        public ResearchPlaceView ResearchPlaceView => laboratoryView.ResearchPlace;
        public BackButton BackButton => laboratoryView.BackButton;
        public double ResearchTimeInMinutes => laboratoryView.ResearchTimeInMinutes;

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

        private void SaveResearchableSlime()
        {
            LabInteract.SetResearchableSlime(this, GetResearchableSlime(), DateTime.Now.AddMinutes(ResearchTimeInMinutes));
            labInteract.SetStatusTake(false);
        }

        private void RemoveSlimeFromInventoryData()
        {
            SlimesInventory.RemoveSlime(this, GetResearchableSlime());
        }

        public delegate void AnyActionDelegate();
        public void StartTimer(AnyActionDelegate anyAction)
        {
            Coroutines.StartRoutine(StartTimerRoutine(anyAction));
        }

        public IEnumerator StartTimerRoutine(AnyActionDelegate anyAction)
        {
            while (!LabInteract.IsResearchEnd)
            {
                yield return null;
            }
            anyAction();
            EndResearch();
        }

        private void EndResearch()
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
