using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaHealthPickup : MonoBehaviour {

    private GameManager gameManager;
    public float m_HealthBonus = 100f;

    // Use this for initialization
    void Start () {
        gameManager = GameManager.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // if player hits, pick up if health is less than 200

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "GroundCheck")
        {
            if (gameManager.PlayerHealth == 200f)
            {
                Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
            }
            else if (gameManager.PlayerHealth > 100f && gameManager.PlayerHealth < 200f)
            {
                SoundManagerScript.PlaySound("m_health");
                gameManager.PlayerHealth += (200f - gameManager.PlayerHealth);
                Destroy(gameObject);
            }
            else
            {
                SoundManagerScript.PlaySound("m_health");
                gameManager.PlayerHealth += this.m_HealthBonus;
                Destroy(gameObject);
            }
        }

        if (collision.collider.tag == "Ghost")
        {
            Physics2D.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider2D>());
        }
    }
}
