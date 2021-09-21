using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public static class CurrentGameData
{
    public static int PlayerMaxScore { get; set; }
    public static int PlayerTotalCoins { get; set; }
    public static int ChoosenPack { get; set; }
    public static int ChoosenTrail { get; set; }

    public static List<bool> PacksUnlocked = new List<bool>();
    public static List<bool> TrailsUnlocked = new List<bool>();

    public static Packs packSelected { get; set; }
    public static void SetNewData(GameDataToSave newGameData)
    {
       
        PlayerMaxScore = newGameData.PlayerMaxScore;
        PlayerTotalCoins = newGameData.PlayerTotalCoins;
        ChoosenPack = newGameData.ChoosenPack;
        ChoosenTrail = newGameData.ChoosenTrail;
        PacksUnlocked = newGameData.PacksUnlocked;
        TrailsUnlocked = newGameData.TrailsUnlocked;
    }

}
