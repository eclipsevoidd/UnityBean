using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("stati")]
    public int score = 0;
    public int lives = 3;
    public float timeRemaining = 60f;
    private bool isGameOver = false;

    [Header("UI Elementi")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel;

    void Awake() { instance = this; }

    void Update()
    {
        if (!isGameOver)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateUI();
            }
            else { GameOver(); }
        }
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;
        score += amount;
        UpdateUI();
    }

    public void LoseLife()
    {
        if (isGameOver) return;
        lives--;
        UpdateUI();
        if (lives <= 0) GameOver();
    }

    void UpdateUI() // autofill kods
    {
        scoreText.text = $"Punkti: {score}";
        livesText.text = $"Dzīvības: {lives}";
        timerText.text = $"Laiks: {Mathf.CeilToInt(timeRemaining)}";
    }

    void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        if(gameOverPanel != null) gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}