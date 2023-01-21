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
        [SerializeField] private string afterResearch;


        public ResearchPlaceView ResearchPlace => researchPlaceView;
        public BackButton BackButton => backbutton;
        public TextMeshProUGUI Text => text;
        public float ResearchTimeInMinutes => researchTimeInMinutes;
        public string BeforeResearch => beforeResearch;
        public string AfterResearch => afterResearch;


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
