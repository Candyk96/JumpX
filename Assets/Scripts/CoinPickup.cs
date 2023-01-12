using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    public int Score = 5;
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
        if (collision.collider.tag == "Player" || collision.collider.tag == "GroundCheck") // if hits player, adds points and destroys the coin
        {
            SoundManagerScript.PlaySound("bell_01");
            gameManager.Score += this.Score;
            Destroy(gameObject);           
        }

        if (collision.collider.tag == "Ghost")
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
            
        }
    }
}
