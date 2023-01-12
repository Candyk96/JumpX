using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallHealthPickup : MonoBehaviour {

    private GameManager gameManager;
    public float s_HealthBonus = 5f;

	// Use this for initialization
	void Start () {
        gameManager = GameManager.Instance;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision) // if player hits, pick up
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "GroundCheck")
        {
            if (gameManager.PlayerHealth == 200f)
            {
                Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
            }
            else if (gameManager.PlayerHealth > 195f && gameManager.PlayerHealth < 200f)
            {
                SoundManagerScript.PlaySound("s_health");
                gameManager.PlayerHealth += (200f - gameManager.PlayerHealth);
                Destroy(gameObject);
            }
            else
            {
                SoundManagerScript.PlaySound("s_health");
                gameManager.PlayerHealth += this.s_HealthBonus;
                Destroy(gameObject);
            }
        }

        if (collision.collider.tag == "Ghost")
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
        }
    }
}
