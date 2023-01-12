using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeHealthPickup : MonoBehaviour {

    private GameManager gameManager;
    public float l_HealthBonus = 50f;

    // Use this for initialization
    void Start () {
        gameManager = GameManager.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // if player hits, pick up if health is less than 100

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "GroundCheck")
        {
            if (gameManager.PlayerHealth >= 100f)
            {
                Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
            }
            else if (gameManager.PlayerHealth > 50f && gameManager.PlayerHealth < 100f)
            {
                SoundManagerScript.PlaySound("l_health");
                gameManager.PlayerHealth += (100f - gameManager.PlayerHealth);
                Destroy(gameObject);
            }
            else
            {
                SoundManagerScript.PlaySound("l_health");
                gameManager.PlayerHealth += this.l_HealthBonus;
                Destroy(gameObject);
            }
        }

        if (collision.collider.tag == "Ghost")
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
        }
    }
}
