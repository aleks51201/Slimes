using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

namespace SlimeEvolutions.Panel.Crossing.CrossTimer
{
    public class TimerView: MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timerText;

        private TimerLogic timerLogic;
        private int id;


        public TextMeshProUGUI TimerText => timerText;
        public int ID => id;

        
        private void Awake()
        {
            timerLogic = new(this);
            id = GetComponentInParent<HoldCrossingPlaceView>().ID;
        }

        private void OnEnable()
        {
            timerLogic.OnEnable();
        }

        private void OnDisable()
        {
            timerLogic.OnDisable();
        }
    }
}
