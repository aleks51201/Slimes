using Assets.Scripts;
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
            SetTrueSlimeResearch(GetResearchableSlime());
            SaveResearchableSlime();
            DiscardMutagen();
            StartResearchSlimeEvent?.Invoke();
        }

        public void StartTimer(float seconds)
        {
            timer = new(TimerTypes.OneSecTick, seconds);
            timer.Start();
        }

        private void DiscardMutagen()
        {
            Game.GetInteractor<MutagenInteractor>().SpendMutagen(CalcMutagenCost());
        }

        private void SaveResearchableSlime()
        {
            LabInteract.SetResearchableSlime(this, GetResearchableSlime(), DateTime.Now.AddSeconds(GetResearchableSlime().Lvl*30));
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

        public int CalcMutagenCost()
        {
            return laboratoryView.Lvl * 3;
        }

        public void SaveExpAfterResearch()
        {
            var exp = (15 + laboratoryView.Lvl * 0.3) - ((laboratoryView.Lvl - LabInteract.ResearchableSlime.Lvl) * 0.3);
            if (exp < 0)
            {
                exp = 0;
            }
            Game.GetInteractor<ExperienceInteractor>().AddExperience((int)exp);
        }

        public void EndResearch()
        {
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
