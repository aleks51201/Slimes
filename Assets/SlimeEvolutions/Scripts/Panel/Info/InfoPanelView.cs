using System;
using UnityEngine;

namespace SlimeEvolutions.Panel
{
    public class InfoPanelView:MonoBehaviour
    {
        private InfoPanelLogic infopanelLogic;
        private Slime slime;


        public Slime Slime
        {
            get
            {
                return slime;
            }
            set
            {
                if(value is null)
                {
                    throw new ArgumentException("Slime can't be null");
                }
                slime = value;
            }
        }


        private void Awake()
        {
            infopanelLogic = new(this);
        }

        private void OnEnable()
        {
            infopanelLogic.OnEnable();
        }

        private void OnDisable()
        {
            infopanelLogic.OnDisable();
        }
    }
}
