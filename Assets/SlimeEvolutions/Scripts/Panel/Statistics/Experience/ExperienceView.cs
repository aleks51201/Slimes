using TMPro;
using UnityEngine;

namespace SlimeEvolutions.Panel.Statistics.Experience
{
    public class ExperienceView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [Header("Balance")]
        [SerializeField] private int lvlMultiplier;

        private ExperienceLogic experienceLogic;


        public TextMeshProUGUI Text => text;
        public int LvlMultiplier => lvlMultiplier;


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
