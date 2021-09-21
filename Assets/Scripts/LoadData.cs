using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    [SerializeField] private TrailSelection trailSelection;
    [SerializeField] private PackSelection packSelection;

    private void Start()
    {
        if (SaveSystem.LoadGameStats() != null)
        {
            CurrentGameData.SetNewData(SaveSystem.LoadGameStats());
            Debug.Log("Loaded");
            packSelection.currentPackSelected = CurrentGameData.ChoosenPack;
            CurrentGameData.packSelected = packSelection.packs[CurrentGameData.ChoosenPack];

            for (int i = 0; i < CurrentGameData.PacksUnlocked.Count; i++)
            {
                packSelection.packs[i].Unlocked = CurrentGameData.PacksUnlocked[i];
            }

            Debug.Log(CurrentGameData.ChoosenTrail);

            trailSelection.currentTrailSelected = CurrentGameData.ChoosenTrail;
            trailSelection.blade.bladeTrailPrefab = trailSelection.trailsColors[CurrentGameData.ChoosenTrail].Trail;
            

            for (int i = 0; i < CurrentGameData.TrailsUnlocked.Count; i++)
            {
                trailSelection.trailsColors[i].Unlocked = CurrentGameData.TrailsUnlocked[i];
            }

            
        }

        else
        {
            Debug.Log("NotLoaded");
            CurrentGameData.packSelected = packSelection.packs[0];
            CurrentGameData.ChoosenPack = packSelection.currentPackSelected;

            for (int i = 0; i < packSelection.packs.Count; i++)
            {
                CurrentGameData.PacksUnlocked.Add(packSelection.packs[i].Unlocked);
            }

            
            
            CurrentGameData.ChoosenTrail = trailSelection.currentTrailSelected;

            for (int i = 0; i < trailSelection.trailsColors.Count; i++)
            {
                CurrentGameData.TrailsUnlocked.Add(trailSelection.trailsColors[i].Unlocked);
            }
            
        }



        Debug.Log(CurrentGameData.packSelected);
        Debug.Log(CurrentGameData.ChoosenTrail);
    }

}
