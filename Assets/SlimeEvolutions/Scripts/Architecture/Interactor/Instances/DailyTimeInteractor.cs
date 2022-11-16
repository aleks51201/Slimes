using SlimeEvolutions.Architecture.Repositories.Instances;
using SlimeEvolutions.Architecture.Scene;
using System;

namespace SlimeEvolutions.Architecture.Interactors.Instances
{
    public class DailyTimeInteractor : Interactor
    {
        private DailyTimeRepository dailyTimeRepository;

        public DateTime DailyTime => dailyTimeRepository.DailyTime;

        public override void OnCreate()
        {
            dailyTimeRepository = Game.GetRepository<DailyTimeRepository>();
        }

        public void SetTime(DateTime dateTime)
        {
            dailyTimeRepository.DailyTime = dateTime;
            dailyTimeRepository.Save();
        }
    }
}
