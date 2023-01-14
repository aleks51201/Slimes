using System;

namespace SlimeEvolutions.Architecture.CrossData
{
    public class CrossingSpaceData
    {
        private Slime[] slimes = new Slime[2];


        public Slime[] Slimes
        {
            get
            {
                return slimes;
            }
            set
            {
                if (value.Length == 2)
                {
                    slimes = value;
                }
            }
        }
        public Slime LSlime { get; set; }
        public Slime RSlime { get; set; }
        public Slime ResultSlime { get; set; }
        public DateTime StartTimeCrossing { get; set; }
        public DateTime EndTimeCrossing { get; set; }
        public bool HasBeenSlimeTaken { get; set; }


        public CrossingSpaceData()
        {

        }

        public CrossingSpaceData(bool hasBeenSlimeTaken)
        {
            HasBeenSlimeTaken = hasBeenSlimeTaken;
        }

        public CrossingSpaceData(Slime lSlime, Slime rSlime, DateTime starTime, DateTime endTime)
        {
            SlimeIdCheck(lSlime, rSlime);
            TimeCheck(starTime, endTime);
            LSlime= lSlime;
            RSlime = rSlime;
            StartTimeCrossing = starTime;
            EndTimeCrossing = endTime;
            HasBeenSlimeTaken = false;
        }

        public CrossingSpaceData(Slime lSlime, Slime rSlime, Slime resultSlime, DateTime starTime, DateTime endTime)
        {
            SlimeIdCheck(lSlime, rSlime);
            TimeCheck(starTime, endTime);
            LSlime= lSlime;
            RSlime = rSlime;
            ResultSlime = resultSlime;
            StartTimeCrossing = starTime;
            EndTimeCrossing = endTime;
            HasBeenSlimeTaken = false;
        }


        private void SlimeIdCheck(Slime lSlime, Slime rSlime)
        {
            if (lSlime.Id == rSlime.Id)
            {
                throw new ArgumentException("Slimes can't be the same");
            }
        }

        private void TimeCheck(DateTime starTime, DateTime endTime)
        {
            if(endTime < starTime)
            {
                throw new ArgumentException("The end time expires before the start time");
            }
        }
    }
}
