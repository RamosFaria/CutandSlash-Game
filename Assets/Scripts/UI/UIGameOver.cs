using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI maxScore;

    [SerializeField] private TextMeshProUGUI score;

    [SerializeField] private GameObject gameOverScreen;

    private void Start()
    {
        
        Actions.GameOver += ActivateGameOverScreen;
    }

    private void OnDisable()
    {
        Actions.GameOver -= ActivateGameOverScreen;
    }

    private void ActivateGameOverScreen()
    {
        
        gameOverScreen.SetActive(true);

        if(UIGame.Instance.score > CurrentGameData.PlayerMaxScore)
        {
            CurrentGameData.PlayerMaxScore = UIGame.Instance.score;
        }

        maxScore.text = "Max Score: " + CurrentGameData.PlayerMaxScore;
        score.text = "Score: " + UIGame.Instance.score;

        Time.timeScale = 0;
    }


}
