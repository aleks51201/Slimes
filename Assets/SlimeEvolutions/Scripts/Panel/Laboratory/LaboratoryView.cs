using Assets.Scripts;
using SlimeEvolutions.Panel.Laboratory;
using UnityEngine;

namespace SlimeEvolutions.Panel
{
    public class LaboratoryView : MonoBehaviour
    {
        [SerializeField] private ResearchPlaceView researchPlaceView;
        [SerializeField] [Min(0)] private double researchTimeInMinutes;
        [SerializeField] private BackButton backbutton;

        public ResearchPlaceView ResearchPlace => researchPlaceView;
        public double ResearchTimeInMinutes => researchTimeInMinutes;
        public BackButton BackButton => backbutton;

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
