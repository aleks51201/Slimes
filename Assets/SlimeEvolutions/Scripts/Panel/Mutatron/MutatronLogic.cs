using SlimeEvolutions.Architecture.Interactors.Instances;
using SlimeEvolutions.Inventory;
using SlimeEvolutions.Panel.Mutatron;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SlimeEvolutions.Panel
{
    public class MutatronLogic
    {
        private GameObject mutatron;
        private List<Slime> slimeArray;

        public static Action<int> OnAddSlimeToArrayEvent;
        public static Action OnRemoveSlimeFromSavedDataEvent;

        public MutatronLogic(GameObject mutatron)
        {
            this.mutatron = mutatron;
            slimeArray = new();
            InventoryButtonLogic.OnInventoryButtonClickEvent += OnInventoryButtonClick;
            RecycleButtonLogic.OnRecycleButtonClickEvent += OnRecycleButtonClick;
        }

        private void AddSlimeToArray(Slime slime)
        {
            List<int> slimeIds = new SlimeID().GetSlimeId(slimeArray);
            if (slimeIds.Contains(slime.Id))
            {
                RemoveSlimeFromArray(slime, slimeArray);
                OnAddSlimeToArrayEvent?.Invoke(CalcMutagen());
                return;
            }
            slimeArray.Add(slime);
            OnAddSlimeToArrayEvent?.Invoke(CalcMutagen());
        }

        private void RemoveSlimesFromSavedData()
        {
            if (SlimesInventory.Slimes == null)
                return;
            SlimesInventory.RemoveSlime(this, slimeArray);
            slimeArray = new();
        }

        private void RemoveSlimeFromArray(Slime excludeSlime, List<Slime> storageSlimeArray)
        {
            for (int i = 0; i < storageSlimeArray.Count; i++)
            {
                if (storageSlimeArray[i].Id == excludeSlime.Id)
                {
                    storageSlimeArray.RemoveAt(i);
                    return;
                }
            }
        }

        private void RemoveSlimesFromArray(List<Slime> excludeSlimeArrayFromStorage, List<Slime> storageSlimeArray )
        {
            foreach (Slime slime in excludeSlimeArrayFromStorage)
            {
                RemoveSlimeFromArray(slime, storageSlimeArray);
            }
        }

        private int CalcMutagen()
        {
            int mutagen = 0;
            foreach (Slime slime in slimeArray)
            {
                mutagen += slime.Lvl * 10;
            }
            return mutagen;
        }

        private void OnInventoryButtonClick(Slime slime)
        {
            if (!mutatron.activeSelf)
            {
                return;
            }
            AddSlimeToArray(slime);
        }

        private void OnRecycleButtonClick()
        {
            RemoveSlimesFromSavedData();
            OnRemoveSlimeFromSavedDataEvent?.Invoke();
        }

    }
}
