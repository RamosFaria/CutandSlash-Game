using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SavePlayerStats ()
    {
        string path = Path.Combine(Application.persistentDataPath + "/saves.a");
        BinaryFormatter formater = new BinaryFormatter();
        if(!Directory.Exists(Path.GetDirectoryName(path)))
        {
            
            Directory.CreateDirectory(Path.GetDirectoryName(path));
        }
        try
        {
            Debug.Log("Saved data to " + path);
            FileStream stream = new FileStream(path, FileMode.Create);

            GameDataToSave data = new GameDataToSave();

            formater.Serialize(stream, data);

            stream.Close();
        }
        catch
        {
            Debug.Log("Error to create");
        }
        
        

    }

    public static GameDataToSave LoadGameStats()
    {
        
        string path = Path.Combine(Application.persistentDataPath + "/saves.a");
        if (File.Exists(path))
        {
            try
            {
                
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                GameDataToSave data = formatter.Deserialize(stream) as GameDataToSave;

                stream.Close();

                return data;
            }
            catch
            {
                return null;
            }

        }
        else
        {
            
            return null;
        }

    }

    public static void DeleteSaveData()
    {
        string path = Path.Combine(Application.persistentDataPath + "/saves.a");

        if (File.Exists(path))
        {
            
            File.Delete(path);
            
            
        }
    }


}

[System.Serializable]
public class GameDataToSave
{
    public int PlayerMaxScore;
    public int PlayerTotalCoins;
    public int ChoosenPack;
    public int ChoosenTrail;
    public List<bool> PacksUnlocked = new List<bool>();
    public List<bool> TrailsUnlocked = new List<bool>();

    public GameDataToSave()
    {
        
        PlayerMaxScore = CurrentGameData.PlayerMaxScore;
        PlayerTotalCoins = CurrentGameData.PlayerTotalCoins;
        ChoosenPack = CurrentGameData.ChoosenPack;
        ChoosenTrail = CurrentGameData.ChoosenTrail;
        PacksUnlocked = CurrentGameData.PacksUnlocked;
        TrailsUnlocked = CurrentGameData.TrailsUnlocked;
        

    }

}