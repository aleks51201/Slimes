using SlimeEvolutions.Panel.Crossing.Update;
using UnityEngine;

namespace SlimeEvolutions.Panel.Info.SlimePlace
{
    public class SlimePlaceUpdater : MonoBehaviour
    {
        [SerializeField] private GameObject cellPrefab;


        private void UpdateView()
        {
            CleanView();
            AddCell(GetComponentInParent<InfoPanelView>().Slime);
        }

        private void CleanView()
        {
            var clean = new CleanCell();
            clean.Clean(this.gameObject);
        }
        private void AddCell(Slime slime)
        {

            var fill = new FillingCell(cellPrefab);
            fill.AddCell(this.transform, slime);
        }

        private void OnEnable()
        {
            UpdateView();
        }

        private void OnDisable()
        {

        }
    }
}
