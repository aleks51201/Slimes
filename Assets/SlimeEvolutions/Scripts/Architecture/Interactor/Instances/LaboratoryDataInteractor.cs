using SlimeEvolutions.Architecture.Repositories.Instances;
using SlimeEvolutions.Architecture.Scene;
using System;

namespace SlimeEvolutions.Architecture.Interactors.Instances
{
    public class LaboratoryDataInteractor : Interactor
    {
        private LaboratoryDataRepository labRepos;

        public Slime ResearchableSlime => labRepos.LabData.ResearchableSlime;
        public DateTime StartTimeResearch => labRepos.LabData.StartTimeResearch;
        public DateTime EndTimeResearch => labRepos.LabData.EndTimeResearch;
        public bool IsResearchEnd
        {
            get
            {
                return EndTimeResearch < DateTime.Now;
            }
        }
        public bool HasBeenSlimeTaken 
        {
            get
            {
                if(ResearchableSlime is null)
                {
                    return true;
                }
                return labRepos.LabData.HasBeenSlimeTaken;
            }
        }

        public override void OnCreate()
        {
            labRepos = Game.GetRepository<LaboratoryDataRepository>();
        }

        public void SetResearchableSlime(object sender, Slime slime, DateTime EndTimeResearch)
        {
            if (!IsResearchEnd)
            {
                throw new Exception("Can't save new slime research, previous research is not finished yet");
            }
            labRepos.LabData.ResearchableSlime = slime;
            labRepos.LabData.StartTimeResearch = DateTime.Now;
            labRepos.LabData.EndTimeResearch = EndTimeResearch;
            labRepos.Save();
            SetStatusTake(false);
        }

        public void SetStatusTake(bool hasBeenTaken)
        {
            labRepos.LabData.HasBeenSlimeTaken = hasBeenTaken;
            labRepos.Save();
        }

    }
}
