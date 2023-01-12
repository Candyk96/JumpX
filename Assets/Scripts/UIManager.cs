using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public Text PlayerHealthText;
    public Text ScoreText;
    public Text TimeText;
    public Text GameOverText;
    public Text CompletedText;
    public Text RestartText;
    private bool restart;

    private GameManager gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameManager.Instance;
        GameOverText.enabled = false;
        CompletedText.enabled = false;
        RestartText.enabled = false;
        restart = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (gameManager.Timer > 0f && !gameManager.isCompleted && !gameManager.isGameOver) // UI clock update
        {
            gameManager.Timer -= Time.deltaTime;
            UpdateLevelTimer(gameManager.Timer);
        }
        PlayerHealthText.text = "Health: " + gameManager.PlayerHealth;
        ScoreText.text = "Score: " + gameManager.Score;
        
        if (gameManager.isGameOver)
        {
            GameOverText.enabled = true;
            RestartText.enabled = true;
            restart = true;
        }
        if (gameManager.isCompleted)
        {
            CompletedText.enabled = true;
            RestartText.enabled = true;
            restart = true;
        }

        if (gameManager.outOfTime)
        {
            GameOverText.enabled = true;
            RestartText.enabled = true;
            restart = true;
            TimeText.text = "Time Remaining: 00:00";
        }

        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                gameManager.Score = 0;
            }
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
    public void UpdateLevelTimer(float totalSeconds) // UI clock update
    {
        int minutes = Mathf.FloorToInt(totalSeconds / 60f);
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);

        string formatedSeconds = seconds.ToString();

        if (seconds == 60)
        {
            seconds = 0;
            minutes += 1;
        }

        TimeText.text = "Time Remaining: " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }

}
