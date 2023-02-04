using SlimeEvolutions.Architecture.Repositories.Instances;
using SlimeEvolutions.Architecture.Scene;
using System;

namespace SlimeEvolutions.Architecture.Interactors.Instances
{
    public class ExperienceInteractor : Interactor
    {
        private ExperienceRepository experienceRepository;


        public int Experience => experienceRepository.Experience;


        public Action<int> DataUpdatedEvent;


        public override void OnCreate()
        {
            experienceRepository = Game.GetRepository<ExperienceRepository>();
        }

        public void AddExperience(int exp)
        {
            if (exp < 0)
            {
                throw new ArgumentOutOfRangeException("exp can't be negative");
            }
            experienceRepository.Experience += exp;
            experienceRepository.Save();
            DataUpdatedEvent?.Invoke(Experience);
        }
    }
}
