using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlimeEvolutions.Panel
{
    public class InfoPanelLogic:IActivatable
    {
        private InfoPanelView infoPanel;


        public InfoPanelLogic(InfoPanelView infoPanelView)
        {
            infoPanel = infoPanelView;
        }


        public void OnEnable()
        {
        }

        public void OnDisable()
        {
        }
    }
}
