using System;
using System.Collections.Generic;

namespace SlimeEvolutions.Architecture
{
    public class LaboratoryData
    {
        public Slime ResearchableSlime { get; set; }
        public DateTime StartTimeResearch { get; set; }
        public DateTime EndTimeResearch { get; set; }
        public bool HasBeenSlimeTaken { get; set; }
    }
}
