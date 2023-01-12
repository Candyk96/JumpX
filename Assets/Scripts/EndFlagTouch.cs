using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFlagTouch : MonoBehaviour {

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
        if (collision.collider.tag == "Player" || collision.collider.tag == "GroundCheck") // if player touches, map is completed
        {
            gameManager.Completed = 1;
        }

        if (collision.collider.tag == "Ghost")
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
        }
    }
}
