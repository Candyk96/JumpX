using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {

    private static GameManager _instance;

    private GameManager()
    {

    }

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }

    public int Score { get; set; }
    public float PlayerHealth { get; set; }
    public int Completed { get; set; }
    public float Timer { get; set; }

    public bool isGameOver
    {
        get
        {
            return PlayerHealth <= 0f;
        }
    }

    public bool outOfTime
    {
        get
        {
            return Timer < 0f;
        }
    }

    public bool isCompleted
    {
        get 
        {
            return Completed >= 1;
        }
    }

}
