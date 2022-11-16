using System;
using System.Collections.Generic;

namespace SlimeEvolutions.Architecture
{
    public class DataStruct
    {
        public List<Slime> InventorySlimes { get; set; }
        public DateTime LastDateTime { get; set; }
        public LaboratoryData LaboratoryData { get; set; }
        public int Experience{ get; set; }
        public int Mutagen { get; set; }
    }
}
