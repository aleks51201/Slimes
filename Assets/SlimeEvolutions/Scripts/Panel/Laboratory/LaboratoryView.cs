using Assets.Scripts;
using SlimeEvolutions.Panel.Laboratory;
using UnityEngine;
using TMPro;

namespace SlimeEvolutions.Panel
{
    public class LaboratoryView : MonoBehaviour
    {
        [SerializeField] private ResearchPlaceView researchPlaceView;
        [SerializeField] [Min(0)] private float researchTimeInMinutes;
        [SerializeField] private BackButton backbutton;
        [SerializeField] private TextMeshProUGUI text;

        [Header("Words on the button")]
        [SerializeField] private string beforeResearch;


        public ResearchPlaceView ResearchPlace => researchPlaceView;
        public float ResearchTimeInMinutes => researchTimeInMinutes;
        public BackButton BackButton => backbutton;
        public TextMeshProUGUI Text => text;


        private LaboratoryLogic laboratoryLogic;


        private void Awake()
        {
            laboratoryLogic = new(this);
        }

        private void OnEnable()
        {
            laboratoryLogic.OnEnable();
        }

        private void OnDisable()
        {
            laboratoryLogic.OnDisable();
        }
    }
}
