using SlimeEvolutions.Architecture.CrossData;
using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeEvolutions.Panel.Crossing.CrossTimer
{
    public class TimerLogic : IActivatable
    {
        private TimerView timerView;


        private CrossingSpaceData CrossingSpaceData => Game.GetInteractor<CrossingSpaceInteractor>().CrossingSpaces[timerView.ID];


        public TimerLogic(TimerView timerView)
        {
            this.timerView = timerView;
        }

        
        public void OnEnable()
        {
        }

        public void OnDisable()
        {
        }
    }
}
