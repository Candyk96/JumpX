using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalHealthPickup : MonoBehaviour {

    private GameManager gameManager;
    public float n_HealthBonus = 25f;

    // Use this for initialization
    void Start () {
        gameManager = GameManager.Instance;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)  // if player hits, pick up if health is less than 100
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "GroundCheck")
        {
            if (gameManager.PlayerHealth >= 100f)
            {
                Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
            }
            else if (gameManager.PlayerHealth > 75f && gameManager.PlayerHealth < 100f)
            {
                SoundManagerScript.PlaySound("n_health");
                gameManager.PlayerHealth += (100f - gameManager.PlayerHealth);
                Destroy(gameObject);
            }
            else
            {
                SoundManagerScript.PlaySound("n_health");
                gameManager.PlayerHealth += this.n_HealthBonus;
                Destroy(gameObject);
            }
            
        }

        if (collision.collider.tag == "Ghost")
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
        }
    }
}
