using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SlimeEvolutions.Panel
{
    public class InfoPanelView:MonoBehaviour
    {
        private InfoPanelLogic infopanelLogic;


        private void Awake()
        {
            infopanelLogic = new(this);
        }
    }
}
