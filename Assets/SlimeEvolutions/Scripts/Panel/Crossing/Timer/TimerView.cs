using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SlimeEvolutions.Panel.Crossing.Timer
{
    public class TimerView: MonoBehaviour
    {
        private TimerLogic timerLogic;


        private void Awake()
        {
            timerLogic = new();
        }

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }
    }
}
