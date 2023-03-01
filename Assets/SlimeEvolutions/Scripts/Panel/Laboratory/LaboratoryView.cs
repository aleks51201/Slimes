using Assets.Scripts;
using SlimeEvolutions.Panel.Laboratory;
using UnityEngine;
using TMPro;
using SlimeEvolutions.Panel.Statistics.Experience;

namespace SlimeEvolutions.Panel
{
    public class LaboratoryView : MonoBehaviour
    {
        [SerializeField] private ResearchPlaceView researchPlaceView;
        [SerializeField] private BackButton backbutton;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private ExperienceView experienceView;
        [SerializeField] [Min(0)] private float researchTimeInMinutes;

        [Header("Words on the button")]
        [SerializeField] private string beforeResearch;
        [SerializeField] private string prefixTime;
        [SerializeField] private string suffixTime;
        [SerializeField] private string prefixCost;
        [SerializeField] private string suffixCost;
        [SerializeField] private string afterResearch;


        public ResearchPlaceView ResearchPlace => researchPlaceView;
        public BackButton BackButton => backbutton;
        public TextMeshProUGUI Text => text;
        public float ResearchTimeInMinutes => researchTimeInMinutes;
        public string BeforeResearch => beforeResearch;
        public string PrefixTime => prefixTime;
        public string SuffixTime=> suffixTime;
        public string PrefixCost=> prefixCost;
        public string SuffixCost=> suffixCost;
        public string AfterResearch => afterResearch;
        public int Lvl => experienceView.Lvl;


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
