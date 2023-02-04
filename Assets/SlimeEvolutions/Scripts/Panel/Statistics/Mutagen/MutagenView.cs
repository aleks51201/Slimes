﻿using TMPro;
using UnityEngine;

namespace SlimeEvolutions.Panel.Statistics.Mutagen
{
    public class MutagenView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        private MutagenLogic mutagenLogic;


        public TextMeshProUGUI Text => text;


        private void Awake()
        {
            mutagenLogic = new(this);
        }
    }
}
