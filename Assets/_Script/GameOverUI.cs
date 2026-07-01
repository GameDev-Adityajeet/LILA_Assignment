using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TMP_Text finalScoreText;
    public Button restartButton;

    void Start()
    {
        gameOverPanel.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);

        GameState.Instance.OnGameOver += ShowGameOver;
    }

    void OnDestroy()
    {
        if (GameState.Instance == null) return;
        GameState.Instance.OnGameOver -= ShowGameOver;
    }

    void ShowGameOver()
    {
        gameOverPanel.SetActive(true);

        int finalMoney = GameState.Instance.money;
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (finalMoney > highScore)
        {
            PlayerPrefs.SetInt("HighScore", finalMoney);
            PlayerPrefs.Save();
            finalScoreText.text = "Final Money: $" + finalMoney + "\n<color=#FFD700>NEW BEST!</color>";
        }
        else
        {
            int difference = highScore - finalMoney;
            finalScoreText.text = "Final Money: $" + finalMoney + "\nBest: $" + highScore + "  ($" + difference + " short)";
        }

        AudioManager.Instance.PlayGameOver();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}