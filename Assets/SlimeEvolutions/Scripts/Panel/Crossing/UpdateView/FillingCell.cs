using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SlimeEvolutions.Panel.Crossing.UpdateView
{
    public class FillingCell
    {
        private Slime lSlime;
        private Slime rSlime;
        private Slime centralSlime;


        public FillingCell(Slime lSlime, Slime rSlime, Slime centralSlime)
        {
            this.lSlime = lSlime;
            this.rSlime = rSlime;
            this.centralSlime = centralSlime;
        }
    }
}
