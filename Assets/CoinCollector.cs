using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject rulesScreen;
    public GameObject winScreen;
    public GameObject loseScreen;
    private int score = 0;
    private int totalCoins = 10;
    public GameObject coinPrefab;
    public int coinsToSpawn = 10;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public float timeRemaining = 30f;
    public bool gameIsActive = false;
    
    void Start()
    {
        Time.timeScale = 0f;
        timerText.text = "Time: " + timeRemaining;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            float randomX = Random.Range(-8f, 8f);
            float randomY = Random.Range(-4f, 4f);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        if (gameIsActive)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Round(timeRemaining);

            if (timeRemaining <= 0)
            {
                gameIsActive = false;
                ShowLoseScreen();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            totalCoins--;
            score++;
            scoreText.text = "Score: " + score;
            Debug.Log("Coin collected! Score : " + score);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameIsActive = false;
            ShowLoseScreen();
        }
        if (totalCoins <= 0)
        {
            gameIsActive = false;
            ShowWinScreen();
        }
    }
    public void StartGame()
    {
        startScreen.SetActive(false);
        Time.timeScale = 1f;
        gameIsActive = true;
    }

    public void ShowRules()
    {
        startScreen.SetActive(false);
        rulesScreen.SetActive(true);
    }


    public void HideRules()
    {
        rulesScreen.SetActive(false);
        startScreen.SetActive(true);
    }

    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }
    public void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
    }
}
