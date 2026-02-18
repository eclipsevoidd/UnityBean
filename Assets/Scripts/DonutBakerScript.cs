using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DonutBakerScript : MonoBehaviour
{
    public GameObject[] donutPrefabs;
    public float bakeInterval = 1.0f;
    public Transform ovenTransform;
    public float offset = 0.7f;

    [Header("UI Elements")]
    public Button bakeButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    private int score = 0;
    public float timeRemaining = 60f;
    private bool isGameRunning = false;
    private Coroutine bakingCoroutine;
    void Start()
    {
        Debug.Log("Skripts ir pamodies!"); // Ja šis neparādās, skripts nav pievienots nevienam objektam

        if (scoreText != null) scoreText.gameObject.SetActive(false);
        if (timerText != null) timerText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isGameRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerUI();
            }
            else
            {
                timeRemaining = 0;
                UpdateTimerUI();
                StopBaking();
            }
        }
    }

    [Header("Lives System")]
    public int lives = 3;
    public TextMeshProUGUI livesText;

    public void LoseLife()
    {
        lives--;
        if (livesText != null)
        {
            livesText.text = "Dzīvības: " + lives;
        }

        if (lives <= 0)
        {
            StopBaking();
            if (timerText != null) timerText.text = "SPĒLE BEIGUSIES!";
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = "Laiks: " + Mathf.CeilToInt(timeRemaining).ToString();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        if (scoreText != null) scoreText.text = "Punkti: " + score;
    }

    // StartBaking jābūt tikai VIENU reizi!
    public void StartBaking()
    {
        if (!isGameRunning)
        {
            isGameRunning = true;
            timeRemaining = 60f;
            score = 0;

            // Atjaunojam tekstus sākuma pozīcijā
            AddScore(0);
            UpdateTimerUI();

            // Paslēpjam pogu un parādām UI elementus
            if (bakeButton != null) bakeButton.gameObject.SetActive(false);
            if (scoreText != null) scoreText.gameObject.SetActive(true);
            if (timerText != null) timerText.gameObject.SetActive(true);

            bakingCoroutine = StartCoroutine(Bake());
        }
    }

    public void StopBaking()
    {
        isGameRunning = false;
        if (bakingCoroutine != null) StopCoroutine(bakingCoroutine);
        if (timerText != null) timerText.text = "Laiks beidzies!";
    }

    IEnumerator Bake()
    {
        while (isGameRunning)
        {
            float minPoz = ovenTransform.position.x - offset;
            float maxPoz = ovenTransform.position.x + offset;
            float randPoz = Random.Range(minPoz, maxPoz);
            Vector2 spawnPoz = new Vector2(randPoz, ovenTransform.position.y);

            int donutIndex = Random.Range(0, donutPrefabs.Length);
            GameObject newDonut = Instantiate(donutPrefabs[donutIndex], spawnPoz, Quaternion.identity, ovenTransform);
            Destroy(newDonut, 5.0f);

            yield return new WaitForSeconds(bakeInterval);
        }
    }
}