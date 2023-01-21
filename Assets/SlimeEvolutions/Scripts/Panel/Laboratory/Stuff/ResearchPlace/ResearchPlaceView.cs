using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Architecture.Scene;
using SlimeEvolutions.Inventory;
using SlimeEvolutions.InventoryCell;
using System;
using UnityEngine;

namespace SlimeEvolutions.Panel.Laboratory
{
    public class ResearchPlaceView : MonoBehaviour
    {
        [SerializeField] private GameObject buttonPrefab;

        private Slime slime;
        private LaboratoryDataInteractor labInteract;

        public Slime Slime
        {
            get => slime;
            set
            {
                slime = value ?? throw new NullReferenceException($"{value} is null. Slime can't be null");
            }
        }

        private LaboratoryDataInteractor LabInteract
        {
            get
            {
                if (labInteract is null)
                {
                    labInteract = Game.GetInteractor<LaboratoryDataInteractor>();
                }
                return labInteract;
            }
        }

        public void ResearchSpaceUpdate(object sender, Slime slime)
        {
            ClearSpace();
            this.slime = slime;
            CreateCell(Instantiate(buttonPrefab, this.transform), slime);
        }

        private void CreateCell(GameObject newCell, Slime slime)
        {
            newCell.GetComponentInChildren<CellView>().Slime = slime;
        }

        public void ClearSpace()
        {
            var researchPlaceButtonView = gameObject.GetComponentInChildren<ResearchPlaceButtonView>();
            if (researchPlaceButtonView != null)
            {
                Destroy(researchPlaceButtonView.gameObject);
            }
            slime = null;
        }
    }
}
