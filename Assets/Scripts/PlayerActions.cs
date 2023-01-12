using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    private GameManager gameManager;

    // Use this for initialization
    // Start the game with following values
    void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.PlayerHealth = 100f;
        gameManager.Timer = 180f;
        gameManager.Completed = 0;
    }

    // Update is called once per frame
    // Check if game has ended
    void Update()
    {
        if (gameManager.isGameOver)
        {
            this.gameObject.SetActive(false);
            SoundManagerScript.PlaySound("you_lose");
        }

        if (gameManager.outOfTime)
        {
            this.gameObject.SetActive(false);
            SoundManagerScript.PlaySound("you_lose");
        }

        if (gameManager.isCompleted)
        {
            this.gameObject.SetActive(false);
            SoundManagerScript.PlaySound("you_win");
        }
    }

}
