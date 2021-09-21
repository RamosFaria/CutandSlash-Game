using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI coinsText;
    [Header("Load Data")]
    [SerializeField] private TrailSelection trailSelection;
    [SerializeField] private PackSelection packSelection;

    private void Start()
    {
        
        
        

        CheckPoints();
    }


    private void CheckPoints()
    { 
       coinsText.text = "Coins: " + CurrentGameData.PlayerTotalCoins.ToString();
       scoreText.text = "Max Score: " + CurrentGameData.PlayerMaxScore.ToString();
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            SaveSystem.SavePlayerStats();
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            SaveSystem.DeleteSaveData();
        }
    }

    private void OnApplicationQuit()
    {
        SaveSystem.SavePlayerStats();
        //SaveSystem.DeleteSaveData();
    }
}
