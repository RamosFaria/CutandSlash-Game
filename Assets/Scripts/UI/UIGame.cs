using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIGame : MonoBehaviour
{

    
    [HideInInspector]public int score;
    private int coins;
    
    [Header("UI Assigment")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _gameOverScreen;

    [HideInInspector]
    public int Strike;
    public static UIGame Instance { get; private set; }
    private void Awake()
    {
        Actions.StrikeHandler += StrikeAmountChanged;
        Actions.GameOver += SaveStats;
        Instance = this;
        score = 0;
        Strike = 0;
        _scoreText.text = "Score: " + score;
        Time.timeScale = 1;
    }

    private void OnDisable()
    {
        Actions.StrikeHandler -= StrikeAmountChanged;
        Actions.GameOver -= SaveStats;
    }

    
    public void AddScore()
    {
        score += 1;
        _scoreText.text = "Score: " + score;
        
    }

    public void EarnCoins()
    {
        int randomCoinValue = Random.Range(2, 5);
        coins += randomCoinValue;
        
    }

    public void StrikeAmountChanged()
    {
        Strike += 1;
        if(Strike >= 3)
        {
            Actions.GameOver();
        }
    }

    public void SaveStats()
    {
        //if(score >= SaveManager.Instance.activeSave.maxScore)
        //{
        //    SaveManager.Instance.activeSave.maxScore = score;
        //}
        //SaveManager.Instance.activeSave.coins += coins;
        //SaveManager.Instance.SaveGame();
        //SaveManager.Instance.Load();
    }
    public void PauseButton()
    {
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
    }

    public void ResetScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SaveStats();
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
        SaveStats();
    }
}
