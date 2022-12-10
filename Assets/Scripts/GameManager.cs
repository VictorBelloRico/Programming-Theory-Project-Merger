using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] GameObject mainScreen;
    [SerializeField] TextMeshProUGUI scoreText;
    private int score;

    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI finalScoreText;

    public bool isGameActive;
    public int time = 30;
    [SerializeField] TextMeshProUGUI timeText;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        InvokeRepeating("Countdown", 0f, 1.0f);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void UpdateScore(int s)
    {
        score += s;
        scoreText.text = "Score: " + score;
    }
    public void Countdown()
    {
        if (time == 0)
        {
            GameOver();
        }
        timeText.text = "Time: " + time;
        time--;
    }
    public void GameOver()
    {
        isGameActive = false;
        finalScoreText.text = "Score: " + score;
        mainScreen.gameObject.SetActive(false);
        gameOverScreen.gameObject.SetActive(true);
    }
}
