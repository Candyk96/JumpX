using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPointAction : MonoBehaviour {

    private GameManager gameManager;

    // Use this for initialization
    void Start () {
        gameManager = GameManager.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "GroundCheck") // if player falls out of the map, health goes to 0
        {
            gameManager.PlayerHealth = 0;
        }
    }
}
