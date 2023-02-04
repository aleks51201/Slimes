using TMPro;
using UnityEngine;

namespace SlimeEvolutions.Panel.Statistics.Experience
{
    public class ExperienceView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        private ExperienceLogic experienceLogic;


        public TextMeshProUGUI Text => text;


        private void Awake()
        {
            experienceLogic = new(this);
        }

        private void OnEnable()
        {
            experienceLogic.OnEnable();
        }

        private void OnDisable()
        {
            experienceLogic.OnDisable();
        }
    }
}
